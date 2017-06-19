using System;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;

namespace JTorrent
{
    public static class DbManager
    {
        private static SqlConnection conn;
        private static SqlCommand command;

        public static ArrayList files;
        public static ArrayList users;

        static DbManager()
        {   
            string connectionString =
                ConfigurationManager.ConnectionStrings["JTorrentConnectionString"].ToString();
            conn = new SqlConnection(connectionString);
        }
       
        public static void Update()
        {
            files = getFilesFromDb();
            users = getUsersFromDb();
        }

        public static ArrayList getUsersFromDb()
        {
            ArrayList list = new ArrayList();
            string query = string.Format("SELECT * FROM Users");

            try
            {
                command = new SqlCommand("", conn);
                command.CommandText = query;
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt16(0);
                    string username = reader.GetString(1);
                    string password = reader.GetString(2);
                    string registrationDate = Convert.ToString(reader.GetDateTime(3));

                    DbUser mDbUser = new DbUser(id, username, password, registrationDate);
                    list.Add(mDbUser);
                }
            }
            finally
            {
                conn.Close();
            }

            return list;
        }

        public static ArrayList getFilesFromDb()
        {
            ArrayList list = new ArrayList();
            string query = string.Format("SELECT * FROM Files");

            try
            {
                command = new SqlCommand("", conn);
                command.CommandText = query;
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int idFile = reader.GetInt16(0);
                    string filename = reader.GetString(1);
                    long dimension = (long) reader.GetInt64(2);
                    string username = reader.GetString(3);

                    DbFile mDbFile = new DbFile(idFile, filename, dimension, username);
                    list.Add(mDbFile);
                }
            }
            finally
            {
                conn.Close();
            }

            return list;
        }

        public static ArrayList filterFilesFromDb(string criteria)
        {
            ArrayList list = new ArrayList();
            string query = "SELECT * FROM Files where filename like '%'+ @criteria + '%'";

            try
            {
                command = new SqlCommand("", conn);
                command.CommandText = query;
                command.Parameters.AddWithValue("@criteria", criteria);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int idFile = reader.GetInt16(0);
                    string filename = reader.GetString(1);
                    long dimension = (long) reader.GetInt64(2);
                    string user = reader.GetString(3);

                    DbFile mDbFile = new DbFile(idFile, filename, dimension, user);
                    list.Add(mDbFile);
                }
            }
            finally
            {
                conn.Close();
            }

            return list;
        }
        public static void createUser(string username, string password)
        {
            string query = "INSERT INTO Users VALUES(@id, @username, @password, @registration_date)";

            try
            {
                command = new SqlCommand("", conn);
                command.CommandText = query;
                command.Parameters.AddWithValue("@id", users.Count + 1);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@registration_date", DateTime.Today);
                conn.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }
        public static void uploadFile(string path, long size, string username)
        {
            string query = "INSERT INTO Files VALUES(@id, @filename, @dimension, @username)";

            try
            {
                command = new SqlCommand("", conn);
                command.CommandText = query;
                command.Parameters.AddWithValue("@id", files.Count + 1);
                command.Parameters.AddWithValue("@filename", path);
                command.Parameters.AddWithValue("@dimension", size);
                command.Parameters.AddWithValue("@username", username);
                conn.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
