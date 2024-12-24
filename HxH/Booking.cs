using System;
using System.Data.SQLite;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace HxH
{
    public partial class Booking : Form
    {
        public Booking()
        {
            InitializeComponent();
        }

        #region Обработчики событий
        // Обработчик нажатия на кнопку "Выход"
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        // Обработчик нажатия на кнопку "Оплатить"
        private void BuyButton_Click(object sender, EventArgs e)

        {
            // Получаем значения полей ввода
            string surname = surnameField.Text;
            string number = numberField.Text;
            string cvc = cvvField.Text;
            string date = dateField.Text;
            string date1 = date1Field.Text;
            {
                // Создаем соединение с базой данных SQLite
                SQLiteConnection con = new SQLiteConnection("Data Source=sqlhxh.db;version=3;");
                con.Open();
                // Формируем и выполняем запрос на добавление записи в таблицу "cards
                string query = "INSERT INTO cards (surname, numbercard, cvv, date, date1) VALUES ('" + surname + "' ,' " + number + "', '" + cvc + "', '" + date + "', ' " + date1 + "')";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.ExecuteNonQuery();
                // Закрываем соединение с базой данных
                con.Close();
                // Переходим на форму "Спасибо за бронирование"
                Hide();
                Spasibo spasibo = new Spasibo();
                spasibo.Show();
            }
        }
        // Обработчик нажатия на кнопку "Назад"
        private void BackButton_Click(object sender, EventArgs e)
        {
            Hide();
            Hotels newForm = new Hotels();
            newForm.Show();
        }
        // Обработчик изменения текста поля "Номер карты"
        private void numberField_TextChanged(object sender, EventArgs e)
        {
            // Форматируем введенный номер карты, разделяя его на группы по 4 цифры
            string text = numberField.Text.Replace(" ", "");
            if (text.Length > 0)
            {
                StringBuilder newText = new StringBuilder(text);
                for (int i = 4; i < newText.Length; i += 5)
                {
                    newText.Insert(i, " ");
                }
                numberField.Text = newText.ToString();
                numberField.SelectionStart = newText.Length;
            }
        }
        // Форматируем введенный номер карты, разделяя его на группы по 4 цифры
        private void cvvField_TextChanged(object sender, EventArgs e)
        {
            cvvField.MaxLength = 3;
        }
        // Обработчик изменения текста поля "Дата окончания действия карты (месяц)"
        private void dateField_TextChanged(object sender, EventArgs e)
        {
            dateField.MaxLength = 2;
        }
        // Обработчик изменения текста поля "Дата окончания действия карты (год)"
        private void date1Field_TextChanged(object sender, EventArgs e)
        {
            date1Field.MaxLength = 2;
        }
        // Обработчик ввода символов в поле "Фамилия"
        private void surnameField_KeyPress(object sender, KeyPressEventArgs e)
        {
            // проверяем, что нажатый символ является латинской буквой или пробелом
            if (!((e.KeyChar >= 'a' && e.KeyChar <= 'z') ||
                  (e.KeyChar >= 'A' && e.KeyChar <= 'Z') ||
                  e.KeyChar == ' ' ||
                  e.KeyChar == 8 /* Backspace */ ||
                  e.KeyChar == 127 /* Delete */ ))
            {
                // блокируем ввод других символов
                e.Handled = true;
            }
        }
        #endregion

        private void MainMenu_Click(object sender, EventArgs e)
        {
            Hide();
            Hotels newForm = new Hotels();
            newForm.Show();
        }


        private void AddBut_Click(object sender, EventArgs e)
        {
            SQLiteConnection DB = new SQLiteConnection("Data Source=sqlhxh.db");
            DB.Open();
            var randomName = File.ReadAllLines("randomNameSurname\\name.txt");
            Random random = new Random();

            string[] randomReg = { "950", "999", "912", "918", "909", "904", "963", "952" };
            var randomSurName = File.ReadAllLines("randomNameSurname\\surname.txt");
            int recordsToInsert = 5;

            for (int i = 0; i < recordsToInsert; i++)
            {
                string RanName = randomName[random.Next(randomName.Length)] + randomSurName[random.Next(randomSurName.Length)];
                string RanCVV = GRC(3);
                string RanC =  GRC(7);
                string RanD = GRC(2);
                string RanD1 = GRC(2);

                SQLiteCommand commandInsert = new SQLiteCommand($"INSERT INTO cards  (surname, numbercard ,cvv, date, date1)" +
                    $" VALUES ('{RanName}','{RanC}', '{RanCVV}', '{RanD}', '{RanD1}')", DB);
                _ = commandInsert.ExecuteNonQueryAsync();
            }
            DelBut.Visible = true;
            AddBut.Visible = false;
        }
        string GRC(int length)
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

                    using (SQLiteCommand commandDelete = new SQLiteCommand("DELETE FROM cards WHERE ID IN (SELECT ID FROM cards ORDER BY ID DESC LIMIT 5)", DB))
                    {
                        _ = await commandDelete.ExecuteNonQueryAsync();
                    }
                }

                DelBut.Visible = false;
                AddBut.Visible = true;
        }
    }
}

