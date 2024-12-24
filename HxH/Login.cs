using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace HxH
{
    public partial class Login : Form
    {
        public Login()
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
        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            Hide();
            Registration newForm = new Registration();
            newForm.Show();
        }
        // Обработчик нажатия на кнопку "Войти"
        private void EnterButton_Click(object sender, EventArgs e)
        {
            if (email.Text.Trim() == "" && password.Text.Trim() == "")
            {
                MessageBox.Show("заполните поля ниже");
            }
            else
            {
                // Формируем запрос для проверки наличия пользователя в базе данных
                string query = "SELECT * FROM users WHERE email = @email AND password = @password";
                SQLiteConnection conn = new SQLiteConnection("Data Source=sqlhxh.db;Version=3;");
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                // Добавляем параметры в запрос для безопасности
                cmd.Parameters.AddWithValue("@email", email.Text);
                cmd.Parameters.AddWithValue("@password", password.Text);
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                // Если пользователь найден, открываем новую форму "Hotels"

                if (dt.Rows.Count > 0)
                {
                    this.Hide();
                    Hotels hotels = new Hotels();
                    hotels.Show();
                }
                else
                {
                    // Иначе выводим сообщение об ошибке
                    MessageBox.Show("неверный логин или пороль");
                    return;
                }

            }

        }

        // Обработчик наведения курсора на надпись "Зарегистрироваться"

        private void RegistrationButton_MouseEnter(object sender, EventArgs e)
        {
            RegistrationButton.ForeColor = System.Drawing.Color.Blue;
        }

        // Обработчик ухода курсора с надписи "Зарегистрироваться"

        private void RegistrationButton_MouseLeave(object sender, EventArgs e)
        {
            RegistrationButton.ForeColor = this.ForeColor;
        }

        // Обработчик потери фокуса поля "Email"
        private void email_Leave(object sender, EventArgs e)
        {
            // Проверяем, что введенный адрес является адресом Gmai
            if (!email.Text.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Пожалуйста, введите правильный адрес электронной почты Gmail.");
                email.Focus();
            }
        }
        #endregion
    }
}
