using System;
using System.Data.SQLite;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace HxH
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        #region Обработчики событий

        // Обработчик нажатия на кнопку "Выход"
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Обработчик нажатия на кнопку "Зарегистрироваться"
        private void RegistrButton_Click(object sender, EventArgs e)
        {
            // Открываем соединение с базой данных
            SQLiteConnection DB = new SQLiteConnection("Data Source=sqlhxh.db");
            DB.Open();
            // Получаем значения полей ввода
            string email = emailField.Text;
            string password = passwordField.Text;
            string phone = phoneFieldBox1.Text;
            {

                // Формируем и выполняем запрос на добавление нового пользователя в базу данных
                SQLiteConnection con = new SQLiteConnection("Data Source=sqlhxh.db;version=3;");
                con.Open();
                string query = "INSERT INTO users (email, password, phone) VALUES ('" + email + "','" + password + "','" + phone + "')";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                // Закрываем соединение с базой данных и открываем форму входа

            }
            Hide();
            Login newForm = new Login();
            newForm.Show();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            // Обработчик нажатия на кнопку "Назад"
            Hide();
            Login newForm = new Login();
            newForm.Show();
        }
        


        #endregion

        string GenerateRandomPassword(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void AddBut_Click(object sender, EventArgs e)
        {
            SQLiteConnection DB = new SQLiteConnection("Data Source=sqlhxh.db");
            DB.Open();
            Random random = new Random();

            string[] randomReg = { "950", "999", "912", "918", "909", "904", "963", "952" };
            int recordsToInsert = 5;

            for (int i = 0; i < recordsToInsert; i++)
            {
                string RanPass = GenerateRandomPassword(8);
                string RanEmail = $"{GenerateRandomPassword(6)}@gmail.com";
                string RanPN = "+7" + "(" + randomReg[random.Next(randomReg.Length)] + ")" + GRPH(7);

                SQLiteCommand commandInsert = new SQLiteCommand($"INSERT INTO Users (phone, password, email, role)" +
                    $" VALUES ('{RanPN}', '{RanPass}','{RanEmail}' , '')", DB);
                _ = commandInsert.ExecuteNonQueryAsync();
            }
            DelBut.Visible = true;
            AddBut.Visible = false;
        }
        string GRPH(int length)
        {
            const string chars = "0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private SQLiteConnection DB;

        private async void DelBut_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection DB = new SQLiteConnection("Data Source=sqlhxh.db"))
            {
                await DB.OpenAsync();

                using (SQLiteCommand commandDelete = new SQLiteCommand("DELETE FROM users WHERE ID IN (SELECT ID FROM users ORDER BY ID DESC LIMIT 5)", DB))
                {
                    _ = await commandDelete.ExecuteNonQueryAsync();
                }
            }

            DelBut.Visible = false;
            AddBut.Visible = true;
        }
    }
}
