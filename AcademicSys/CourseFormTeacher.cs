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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AcademicSys
{
    public partial class CourseFormTeacher : Form
    {

        private MySqlConnection connection;

        public CourseFormTeacher()
        {
            InitializeComponent();
            string connectionString = "Server=127.0.0.1;Port=3306;Database=faculty;Uid=mysql;Pwd=mysql;";
            connection = new MySqlConnection(connectionString);

            // Открытие подключения
            connection.Open();

            // Заполните выпадающие списки данными из базы данных
            //FillGroupDropdown();
            //FillGradeTypeDropdown();
        }

        /*private void FillGroupDropdown()
        {
            // Заполните выпадающий список группами из базы данных
            string query = "SELECT id, name FROM Groups";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();

            comboBox3.Items.Clear(); // Очистите comboBox3 перед заполнением
            while (reader.Read())
            {
                comboBox3.Items.Add(new { Id = reader.GetInt32("id"), Name = reader.GetString("name") });
            }

            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "Id";

            reader.Close();
        }

        private void FillStudentDropdown(int groupId)
        {
            // Заполните выпадающий список студентами из выбранной группы
            string query = "SELECT first_name, last_name FROM Student WHERE group_id = @groupId";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add("@groupId", MySqlDbType.Int32).Value = groupId;
            MySqlDataReader reader = command.ExecuteReader();

            comboBox2.Items.Clear(); // Очистите comboBox2 перед заполнением
            while (reader.Read())
            {
                comboBox2.Items.Add(reader["first_name"].ToString() + " " + reader["last_name"].ToString());
            }

            reader.Close();
        }

        private void FillLectureDropdown(int groupId)
        {
            // Заполните выпадающий список лекциями учителя, который ведет у выбранной группы
            string query = "SELECT lecture_name FROM Lecture WHERE id IN (SELECT lecture_id FROM LecturerGroupLectures WHERE group_id = @groupId)";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add("@groupId", MySqlDbType.Int32).Value = groupId;
            MySqlDataReader reader = command.ExecuteReader();

            comboBox4.Items.Clear(); // Очистите comboBox4 перед заполнением
            while (reader.Read())
            {
                comboBox4.Items.Add(reader["lecture_name"].ToString());
            }

            reader.Close();
        }

        private void FillGradeTypeDropdown()
        {
            // Заполните выпадающий список типами оценок (PP, PW, EX)
            comboBox1.Items.Clear(); // Очистите comboBox1 перед заполнением
            comboBox1.Items.Add("PW");
            comboBox1.Items.Add("PP");
            comboBox1.Items.Add("EX");
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Когда выбрана группа, заполните список студентов и список лекций
            var selectedGroup = (dynamic)comboBox3.SelectedItem;
            int selectedGroupId = selectedGroup.Id;
            FillStudentDropdown(selectedGroupId);
            FillLectureDropdown(selectedGroupId); 
        }
        */
        private void button3_Click(object sender, EventArgs e)
        {
            // Получите выбранные значения
            //var selectedGroup = (dynamic)comboBox3.SelectedItem;
            //int selectedGroupId = selectedGroup.Id;
            //string selectedStudent = comboBox2.SelectedItem.ToString();
            //string selectedGradeType = comboBox1.SelectedItem.ToString();
            //int selectedGrade = Convert.ToInt32(textBox1.Text);

            // Сохраните оценку в базе данных
            //string query = "UPDATE Grades SET " + selectedGradeType + " = @grade WHERE student_id = (SELECT id FROM Student WHERE first_name = @firstName AND last_name = @lastName AND group_id = @groupId)";
            //MySqlCommand command = new MySqlCommand(query, connection);
            //command.Parameters.Add("@grade", MySqlDbType.Int32).Value = selectedGrade;
            //command.Parameters.Add("@firstName", MySqlDbType.VarChar).Value = selectedStudent.Split(' ')[0];
            //command.Parameters.Add("@lastName", MySqlDbType.VarChar).Value = selectedStudent.Split(' ')[1];
            //command.Parameters.Add("@groupId", MySqlDbType.Int32).Value = selectedGroupId;
            //command.ExecuteNonQuery();

            //MessageBox.Show("Оценка успешно сохранена");
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox11.Text = label24.Text;
            textBox11.Visible = true;
            button6.Visible = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            label24.Text = textBox11.Text;

            string connectionString = "Server=127.0.0.1;Port=3306;Database=faculty;Uid=mysql;Pwd=mysql;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            DB db = new DB();

            try
            {
                // Открытие подключения
                db.openConnection();

                // Создание команды SQL
                string lecturerQuery = "UPDATE announcements SET description = @desc WHERE id = 1";
                MySqlCommand updateAnnouncement = new MySqlCommand(lecturerQuery, db.GetConnection());
                updateAnnouncement.Parameters.Add("@desc", MySqlDbType.VarChar).Value = textBox11.Text;

                // Выполнение команды
                updateAnnouncement.ExecuteNonQuery();
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

            textBox11.Visible = false;
            button6.Visible = false;
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
