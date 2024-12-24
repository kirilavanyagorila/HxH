using System;
using System.Windows.Forms;

namespace HxH
{
    public partial class Spasibo : Form
    {
        public Spasibo()
        {
            InitializeComponent();
        }

        #region Обработчики событий
        // Обработчик нажатия на кнопку "Выход"
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        // Обработчик нажатия на кнопку "Вернуться в главное меню"
        private void BackMainMenuButton_Click(object sender, EventArgs e)
        {
            Hide();
            Hotels newForm = new Hotels();
            newForm.Show();
        }
        // Обработчик нажатия на надпись "Выбрать другой отель"
        private void MainMenu_Click(object sender, EventArgs e)
        {
            Hide();
            Hotels newForm = new Hotels();
            newForm.Show();
        }
        #endregion
    }
}
