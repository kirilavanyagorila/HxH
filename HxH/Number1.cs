using System;
using System.Windows.Forms;

namespace HxH
{
    public partial class Number1 : Form
    {
        public Number1()
        {
            InitializeComponent();
        }

        #region Обработчики событий
        // Обработчик нажатия на надпись "Отели"
        private void MainMenu_Click(object sender, EventArgs e)
        {
            Hide();
            Hotels newForm = new Hotels();
            newForm.Show();
        }
        // Обработчик нажатия на кнопку "Выход"
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        // Обработчик нажатия на кнопку "Назад"
        private void BackButton_Click(object sender, EventArgs e)
        {
            Hide();
            Hotels newForm = new Hotels();
            newForm.Show();
        }
        // Обработчик нажатия на кнопку "Забронировать"
        private void BookingButton_Click(object sender, EventArgs e)
        {
            Hide();
            Booking newForm = new Booking();
            newForm.Show();
        }
        // Обработчик нажатия на изображение (не используется)
        #endregion
    }
}
