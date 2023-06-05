using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CompanyManagementApplikation.Classes;
using MySql.Data.MySqlClient;

namespace CompanyManagementApplikation.Backend
{
    class Database
    {
        private string connectionData; 
        
        public Database()
        {
            //The connection data is stored encoded in a seperate file, which is not included in this repo due to security concerns.
            StreamReader streamReader = new StreamReader(AppContext.BaseDirectory + "config");
            connectionData = Decode.DecodeStringToBase64(streamReader.ReadToEnd());
        }

        public void ExecuteQuery(string query)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionData))
                {
                    MySqlCommand command = new MySqlCommand(query);
                    command.Connection = connection;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }

        public Task<List<User>> GetUsers()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionData))
                {
                    return Task.Factory.StartNew(() =>
                    {
                        string query = "SELECT * FROM employees";
                        MySqlCommand command = new MySqlCommand(query);
                        command.Connection = connection;
                        List<User> users = new List<User>();

                        MySqlDataReader dataReader;

                        connection.Open();
                        dataReader = command.ExecuteReader();

                        while (dataReader.Read())
                        {
                            if (dataReader.IsDBNull(7))
                            {
                                continue;
                            }
                            users.Add(new User(dataReader.GetString(1), dataReader.GetString(2), dataReader.GetDecimal(3), dataReader.GetString(4), DateTime.Parse(dataReader.GetString(5)), dataReader.GetString(6), dataReader.GetString(7), dataReader.GetString(8)) { Id = dataReader.GetInt32(0)});
                        }

                        connection.Close();
                        return users;
                    });
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }

        public async Task<bool> CheckLogIn(string usernameClear, string passwordClear)
        {
            List<User> users = await GetUsers();

            foreach (User user in users)
            {
                if (user.Username == usernameClear && user.Password == Hash.CreateMD5(passwordClear))
                {
                    return true;
                }
            }

            return false;
        }
    }
}