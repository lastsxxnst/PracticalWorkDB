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
    public partial class Grades2 : Form
    {
        public Grades2()
        {
            InitializeComponent();
        }

        public string CurrentUserLogin { get; set; } // Добавьте это свойство

        private void Grades2_Load(object sender, EventArgs e)
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
                string query = "SELECT s.first_name, s.last_name, g.name, gr.PW, gr.PP, gr.EX FROM student s JOIN groups g ON s.group_id = g.id JOIN grades gr ON s.id = gr.student_id WHERE s.login = @uL";
                MySqlCommand command = new MySqlCommand(query, db.GetConnection());
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = LoginForm.CurrentUserLogin; // Используйте свойство CurrentUserLogin из LoginForm

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
                    label15.Text = PW.ToString(); // Обновление текста метки с оценкой PW
                    label16.Text = PP.ToString(); // Обновление текста метки с оценкой PP
                    label19.Text = EX.ToString(); // Обновление текста метки с оценкой EX
                    label14.Text = totalScore.ToString();
                    label20.Text = finalAssessment.ToString(); // Обновление текста метки с округленным общим баллом
                }

                reader.Close();

                // Создание команды SQL для получения имени лектора
                string lecturerQuery = "SELECT l.first_name, l.last_name FROM lecturers l JOIN lecture_lecturers ll ON l.id = ll.lecturer_id WHERE ll.lecture_id = @lectureId";
                MySqlCommand lecturerCommand = new MySqlCommand(lecturerQuery, db.GetConnection());
                lecturerCommand.Parameters.Add("@lectureId", MySqlDbType.Int32).Value = 3; // Замените 1 на ID лекции

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
    }
}
