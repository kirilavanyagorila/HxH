using System;
using System.Windows.Forms;
using System.Management;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using System.Text;

namespace HxH
{
    public partial class Contact : Form
    {

        public Contact()
        {
            InitializeComponent();
        }

        #region Обработчики событий
        // Обработчик нажатия на кнопку "Информация"
        private void InfoButton_Click(object sender, EventArgs e)
        {
            Hide();
            Info newForm = new Info();
            newForm.Show();
        }
        // Обработчик нажатия на надпись "Отели"
        private void MainMenu_Click(object sender, EventArgs e)
        {
            Hide();
            Hotels newForm = new Hotels();
            newForm.Show();
        }

        // Обработчик нажатия на кнопку "Отправить" (отправка сообщения в Telegram)
        private async void SendButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем значения полей ввода
                string email = EmailBox.Text;
                string subject = SubjectBox.Text;
                string messageText = MessageBox.Text;
                string message = $"От: {email}\nТема: {subject}\n\n{messageText}";
                // Проверяем, что все поля заполнены
                if (email != string.Empty
                && subject != string.Empty
                && messageText != string.Empty)
                {
                    // Создаем экземпляр бота Telegram и отправляем сообщение
                    TelegramBotClient bot = new TelegramBotClient("6143986248:AAGclbM_ncOcYiBHKxX3acZMJr1j4DNzVQs");
                    await bot.SendTextMessageAsync(chatId: "1952854418", text: message);
                    System.Windows.Forms.MessageBox.Show("Сообщение отправлено", "Контакты", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Введите данные", "Контакты", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ApiRequestException ex)
            {
                System.Windows.Forms.MessageBox.Show("Сообщение не отправлено", "Контакты", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Обработчик нажатия на кнопку "Назад"
        private void BackButton_Click(object sender, EventArgs e)
        {
            Hide();
            Hotels newForm = new Hotels();
            newForm.Show();
        }
        // Обработчик нажатия на ссылку "VK"
        // Обработчик нажатия на ссылку "Telegram"
        private void TelegramLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://t.me/HxH_hotel_helper_bot");
            TelegramLink.Links[0].Visited = true;
        }
        // Обработчик нажатия на кнопку "Выход"
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        // Обработчик нажатия на ссылку "VK"
        private void VKLink_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://vk.com/public221149493");
        }
        #endregion


        private void ConfigButton_Click(object sender, EventArgs e)
        {
            Config.ConfigPc();
            ConfigInfo.Text = Config.GetConfigInfo();
        }
    }
}

