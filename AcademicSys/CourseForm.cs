using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AcademicSys
{
    public partial class CourseForm : Form
    {
        private string connectionString = @"Data Source=(127.0.0.1:3306);Initial Catalog=faculty;Integrated Security=True";
        public CourseForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load()
        {
            string loginUser = "";
            DB db  = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `student` WHERE `login` = @uL", db.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                //label4.Text += reader["login"].ToString();
               // label4.Text += reader["first_name"].ToString();
                //label4.Text += reader["last_name"].ToString();
            }
                
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FirstCourse firstCourse = new FirstCourse();
            firstCourse.ShowDialog();
            this.Close();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            SecondCourse secondCourse = new SecondCourse();
            secondCourse.ShowDialog();
            this.Close();
        }

        private void thirdCourse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            ThirdForm thirdForm = new ThirdForm();
            thirdForm.ShowDialog();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void labelLastName_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_2(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Events eventsForm = new Events();
            eventsForm.ShowDialog();
            this.Close();
        }
    }
}
