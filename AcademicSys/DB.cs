using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AcademicSys
{
    internal class DB
    {
        MySqlConnection connection = new MySqlConnection("server=127.0.0.1;port=3306;username=mysql;password=mysql;database=faculty");

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }

        public string ExecuteQuery(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            string result = "";
            if (reader.Read())
            {
                result = reader[0].ToString();
            }
            reader.Close();
            return result;
        }
    }
}
