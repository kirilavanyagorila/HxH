using System;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HxH
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        #region Обработчики событий

        private void registrbutton_Click(object sender, EventArgs e)
        {
            SQLiteConnection DB = new SQLiteConnection("Data Source=sqlhxh.db");
            DB.Open();
            string HotelName = hotelName.Text;
            string Description = description.Text;
            string Number = number.Text;
            string Estimation = estimation.Text;
            string Price = price.Text;
            try
            {
                SQLiteConnection con = new SQLiteConnection("Data Source=sqlhxh.db;version=3;");
                con.Open();
                string query = "INSERT INTO product (HotelName, Description, Number, Estimation, Price) VALUES ('" + HotelName + "' ,' " + Description + "', '" + Number + "', '" + Estimation + "', ' " + Price + "')";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Отель добавлен в базу данных");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при добавлении отеля в базу данных: " + ex.Message);
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        private void CopyButton_Click(object sender, EventArgs e)
        {
            {
                string sourceFilePath = "sqlhxh.db";

                string destinationFolderPath = "SaveDB";

                string fileName = Path.GetFileName(sourceFilePath);
                string destinationFilePath = Path.Combine(destinationFolderPath, fileName);

                try
                {
                    File.Copy(sourceFilePath, destinationFilePath, true);
                    MessageBox.Show("База данных успешно скопированна", "Успех");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при копировании базы данных: " + ex.Message, "Ошибка");
                }
            }
        }

        private void MainButton_Click(object sender, EventArgs e)
        {
            {
                Hide();
                Hotels newForm = new Hotels();
                newForm.Show();
            }
        }  
    }
}
