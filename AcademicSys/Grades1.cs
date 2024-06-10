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
    public partial class Grades1 : Form
    {
        private object firstCourse;

        public Grades1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        public string CurrentUserLogin { get; set; } // Добавьте это свойство

        private void Grades1_Load(object sender, EventArgs e)
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=faculty;Uid=mysql;Pwd=mysql;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            DB db = new DB();

            try
            {
                // Открытие подключения
                db.openConnection();

                // Создание команды SQL
                string query = "SELECT s.first_name, s.last_name, g.name, gr.PW, gr.PP, gr.EX FROM student AS s JOIN groups g ON s.group_id = g.id JOIN grades gr ON s.id = gr.student_id WHERE s.login = @uL AND gr.lecture_id = @aL";
                MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = LoginForm.CurrentUserLogin; // Используйте свойство CurrentUserLogin из LoginForm
                command.Parameters.Add("@aL", MySqlDbType.Int32).Value = FirstCourse.ChoosenId; // Используйте свойство CurrentUserLogin из LoginForm

                // Выполнение команды и получение данных
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string firstName = reader["first_name"].ToString();
                    string lastName = reader["last_name"].ToString();
                    string group = reader["name"].ToString();
                    int PW = Convert.ToInt32(reader["PW"]);
                    int PP = Convert.ToInt32(reader["PP"]);
                    int EX = Convert.ToInt32(reader["EX"]);

                    // Расчет общего балла
                    double totalScore = 0.3 * PW + 0.2 * PP + 0.5 * EX;

                    // Округление общего балла до ближайшего целого числа
                    int finalAssessment = (int)Math.Round(totalScore, MidpointRounding.AwayFromZero);

                    label13.Text = firstName + " " + lastName; // Обновление текста метки
                    label12.Text = group; // Обновление текста метки с названием группы

                    if (PW == 0) labelPW.Text = "";
                    else labelPW.Text = PW.ToString(); // Обновление текста метки с оценкой 

                    if (PP == 0) labelPP.Text = "";
                    else labelPP.Text = PP.ToString(); // Обновление текста метки с оценкой 

                    if (EX == 0) labelEX.Text = "";
                    else labelEX.Text = EX.ToString(); // Обновление текста метки с оценкой 

                    if (totalScore == 0) label14.Text = "";
                    else label14.Text = totalScore.ToString(); // Обновление текста метки с оценкой 

                    if (finalAssessment == 0) label20.Text = "";
                    else label20.Text = finalAssessment.ToString(); // Обновление текста метки с оценкой 
                }

                reader.Close();

                // Создание команды SQL для получения имени лектора
                string lecturerQuery = "SELECT l.first_name, l.last_name FROM lecturers l JOIN lecture_lecturers ll ON l.id = ll.lecturer_id WHERE ll.lecture_id = @lectureId";
                MySqlCommand lecturerCommand = new MySqlCommand(lecturerQuery, db.GetConnection());
                lecturerCommand.Parameters.Add("@lectureId", MySqlDbType.Int32).Value = FirstCourse.ChoosenId; // Замените 1 на ID лекции

                // Выполнение команды и получение данных
                MySqlDataReader lecturerReader = lecturerCommand.ExecuteReader();

                if (lecturerReader.Read())
                {
                    string lecturerFirstName = lecturerReader["first_name"].ToString();
                    string lecturerLastName = lecturerReader["last_name"].ToString();

                    label10.Text = lecturerFirstName + " " + lecturerLastName; // Обновление текста метки с именем лектора
                }
                else
                {
                    label10.Text = "Lecturer not found";
                }

                lecturerReader.Close();

                string announcementQuery = "SELECT a.description FROM announcements a WHERE a.id = 1";
                MySqlCommand announcementCommand = new MySqlCommand(announcementQuery, db.GetConnection());
                announcementCommand.Parameters.Add("@announcementId", MySqlDbType.Int32).Value = 1; // Замените 1 на ID объявления

                // Выполнение команды и получение данных
                MySqlDataReader announcementReader = announcementCommand.ExecuteReader();

                if (announcementReader.Read())
                {
                    string announcementDescription = announcementReader["description"].ToString();

                    label16.Text = announcementDescription; // Обновление текста метки с объявлением
                }
                else
                {
                    label16.Text = "Announcement not found";
                }

                announcementReader.Close();

                string classroomQuery = "SELECT c.room_number FROM classrooms c WHERE c.lecture_id = @lectureId";
                MySqlCommand classroomCommand = new MySqlCommand(classroomQuery, db.GetConnection());
                classroomCommand.Parameters.Add("@lectureId", MySqlDbType.Int32).Value = FirstCourse.ChoosenId; // Замените на ID лекции

                // Выполнение команды и получение данных
                MySqlDataReader classroomReader = classroomCommand.ExecuteReader();

                if (classroomReader.Read())
                {
                    string classroomRoom_Number = classroomReader["room_number"].ToString();

                    label23.Text = classroomRoom_Number; // Обновление текста метки с именем классрума
                }
                else
                {
                    label23.Text = "Classroom not found";
                }

                classroomReader.Close();
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

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            //FirstCourse firstCourse = new FirstCourse();
            //firstCourse.ShowDialog();

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }

        private void label15_Click_1(object sender, EventArgs e)
        {

        }

        private void label16_Click_1(object sender, EventArgs e)
        {

        }
    }
}
