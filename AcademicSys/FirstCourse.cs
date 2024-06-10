using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AcademicSys
{
    public partial class FirstCourse : Form
    {
        private object db;

        public static int ChoosenId;

        public FirstCourse()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Close();
        }



        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        public void SetLabel18Text(string text)
        {
            //label18.Text = text; // установка текста label18
        }

        private void FirstCourse_Load(object sender, EventArgs e)
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
                string query = "SELECT lecture_name FROM lecture WHERE id = 1";

                // Выполнение команды и получение данных
                string lectureName = db.ExecuteQuery(query);

                // Вставка данных в элемент управления label5
                label5.Text = lectureName;

                // Открытие подключения
                db.openConnection();

                // Создание команды SQL
                string query1 = "SELECT lecture_name FROM lecture WHERE id = 2";

                // Выполнение команды и получение данных
                string lectureName1 = db.ExecuteQuery(query1);

                // Вставка данных в элемент управления label5
                label6.Text = lectureName1;

                // Открытие подключения
                db.openConnection();

                // Создание команды SQL
                string query2 = "SELECT lecture_name FROM lecture WHERE id = 3";

                // Выполнение команды и получение данных
                string lectureName2 = db.ExecuteQuery(query2);

                // Вставка данных в элемент управления label5
                label7.Text = lectureName2;

                // Открытие подключения
                db.openConnection();

                // Создание команды SQL
                string query3 = "SELECT lecture_name FROM lecture WHERE id = 4";

                // Выполнение команды и получение данных
                string lectureName3 = db.ExecuteQuery(query3);

                // Вставка данных в элемент управления label5
                label8.Text = lectureName3;

                // Открытие подключения
                db.openConnection();

                // Создание команды SQL
                string query4 = "SELECT lecture_name FROM lecture WHERE id = 5";

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

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChoosenId = 1;

            this.Hide();
            CourseForm courseForm = new CourseForm();
            courseForm.ShowDialog();
            this.Close();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChoosenId = 1;

            this.Hide();
            Grades1 grades1 = new Grades1();
            grades1.ShowDialog();
            this.Show();
            //this.Close();

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChoosenId = 2;

            this.Hide();
            Grades1 grades2 = new Grades1();
            grades2.ShowDialog();
            this.Show();
            //this.Close();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChoosenId = 3;

            this.Hide();
            Grades1 grades3 = new Grades1();
            grades3.ShowDialog();
            this.Show();
            //this.Close();

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChoosenId = 4;

            this.Hide();
            Grades1 grades4 = new Grades1();
            grades4.ShowDialog();
            this.Show();
            //this.Close();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChoosenId = 5;

            this.Hide();
            Grades1 grades5 = new Grades1();
            grades5.ShowDialog();
            this.Show();
            //this.Close();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
