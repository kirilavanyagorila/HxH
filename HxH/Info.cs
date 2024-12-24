using System;
using System.Windows.Forms;

namespace HxH
{
    public partial class Info : Form
    {
        public Info()
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
        // Обработчик нажатия на кнопку "Контакты"
        private void ContactsButton_Click(object sender, EventArgs e)
        {
            Hide();
            Contact newForm = new Contact();
            newForm.Show();
        }
        // Обработчик нажатия на кнопку "Выход"
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        // Обработчик нажатия на кнопку "Информация"
        private void InfoButton_Click(object sender, EventArgs e)
        {
            Hide();
            Info newForm = new Info();
            newForm.Show();
        }
        #endregion

      
        
    }
}
