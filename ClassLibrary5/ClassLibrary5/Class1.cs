using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ClassLibrary5
{
    public class Class1
    {
        private const String SERVER = "127.0.0.1";
        private const String DATABASE = "tut_db";
        private const String UID = "root";
        private const String PASSWORD = "Root";
        private static MySqlConnection dbConn;

        public static int addnum(int a, int b)
        {
            int c = a + b;
            return c;
        }
        public static string sayhi(string a)
        {
            return "Hello World!" + a;
        }
        public static List<string> ReadDB(Boolean r)
        {
            List<string> user = new List<string>();
            if (r == true)
            {                
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                builder.Server = SERVER;
                builder.UserID = UID;
                builder.Password = PASSWORD;
                builder.Database = DATABASE;
                String connString = builder.ToString();
                builder = null;
                dbConn = new MySqlConnection(connString);
                String query = "Select * from users";
                MySqlCommand cmd = new MySqlCommand(query, dbConn);
                dbConn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    String username = reader["username"].ToString();
                    user.Add(username);
                }
                reader.Close();
                dbConn.Close();
            }
            return user;
        }
        public static void InsertDB(Boolean r, string A, string B)
        {
            List<string> rec = new List<string>();
            if (r == true)
            {
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                builder.Server = SERVER;
                builder.UserID = UID;
                builder.Password = PASSWORD;
                builder.Database = DATABASE;
                String connString = builder.ToString();
                builder = null;
                dbConn = new MySqlConnection(connString);
                String query = string.Format("Insert into users (username, password) VALUES ('{0}','{1}')", A, B);
                MySqlCommand cmd = new MySqlCommand(query, dbConn);
                dbConn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
                dbConn.Close();
            }
        }
    }
}
