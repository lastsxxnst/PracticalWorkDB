using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AcademicSys
{
    public partial class ThirdForm : Form
    {
        public ThirdForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CourseForm courseForm = new CourseForm();
            courseForm.ShowDialog();
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Close();
        }

        private void ThirdForm_Load(object sender, EventArgs e)
        {
            // Создание подключения к базе данных
            string connectionString = "Server=127.0.0.1;Port=3306;Database=faculty;Uid=mysql;Pwd=mysql;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            DB db = new DB();

            try
            {
                // Открытие подключения
                db.openConnection();

                // Создание команды SQL
                string query = "SELECT lecture_name FROM lecture WHERE id = 11";

                // Выполнение команды и получение данных
                string lectureName = db.ExecuteQuery(query);

                // Вставка данных в элемент управления label5
                label5.Text = lectureName;

                // Открытие подключения
                db.openConnection();

                // Создание команды SQL
                string query1 = "SELECT lecture_name FROM lecture WHERE id = 12";

                // Выполнение команды и получение данных
                string lectureName1 = db.ExecuteQuery(query1);

                // Вставка данных в элемент управления label5
                label6.Text = lectureName1;

                // Открытие подключения
                db.openConnection();

                // Создание команды SQL
                string query2 = "SELECT lecture_name FROM lecture WHERE id = 13";

                // Выполнение команды и получение данных
                string lectureName2 = db.ExecuteQuery(query2);

                // Вставка данных в элемент управления label5
                label7.Text = lectureName2;

                // Открытие подключения
                db.openConnection();

                // Создание команды SQL
                string query3 = "SELECT lecture_name FROM lecture WHERE id = 14";

                // Выполнение команды и получение данных
                string lectureName3 = db.ExecuteQuery(query3);

                // Вставка данных в элемент управления label5
                label8.Text = lectureName3;

                // Открытие подключения
                db.openConnection();

                // Создание команды SQL
                string query4 = "SELECT lecture_name FROM lecture WHERE id = 15";

                // Выполнение команды и получение данных
                string lectureName4 = db.ExecuteQuery(query4);

                // Вставка данных в элемент управления label5
                label10.Text = lectureName4;

            }
            catch (Exception ex)
            {
                // Обработка исключений
                MessageBox.Show("There's been an error: " + ex.Message);
            }
            finally
            {
                // Закрытие подключения
                db.closeConnection();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
