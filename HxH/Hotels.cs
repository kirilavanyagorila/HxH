using System;
using System.Windows.Forms;

namespace HxH
{
    public partial class Hotels : Form
    {
        public Hotels()
        {
            InitializeComponent();
        }

        #region Обработчики событий

        // Обработчик нажатия на кнопку "Выход"
        private void exit_button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        // Обработчик нажатия на кнопку "Забронировать номер 1"
        private void HotelButton1_Click(object sender, EventArgs e)
        {
            Hide();
            Number1 newForm = new Number1();
            newForm.Show();
        }
        // Обработчик нажатия на кнопку "Забронировать номер 2"
        private void HotelButton2_Click(object sender, EventArgs e)
        {
            Hide();
            Number2 newForm = new Number2();
            newForm.Show();
        }
        // Обработчик нажатия на кнопку "Забронировать номер 3"
        private void HotelButton3_Click(object sender, EventArgs e)
        {
            Hide();
            Number3 newForm = new Number3();
            newForm.Show();
        }
        // Обработчик нажатия на надпись "Отели"
        private void label1_Click(object sender, EventArgs e)
        {
            Hide();
            Hotels newForm = new Hotels();
            newForm.Show();
        }
        // Обработчик нажатия на кнопку "Контакты"
        private void ContactsButton_Click(object sender, EventArgs e)
        {
            Hide();
            Contact newForm = new Contact();
            newForm.Show();
        }
        // Обработчик нажатия на кнопку "Информация"
        private void InfoButton_Click(object sender, EventArgs e)
        {
            Hide();
            Info newForm = new Info();
            newForm.Show();
        }
        // Обработчик нажатия на кнопку "Добавить отель" (для администратора)
        private void AddButton_Click(object sender, EventArgs e)
        {
            Hide();
            AdminForm newForm = new AdminForm();
            newForm.Show();
        }
        #endregion
    }
}
