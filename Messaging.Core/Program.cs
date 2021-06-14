using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Messaging.Core.Models;

using Microsoft.IdentityModel.JsonWebTokens;

namespace Messaging.Core
{
    class Program
    {
        void addUserSleepDataToDB(string user_id, string sleep_data_id, string sleep_data, MySqlConnection con)
        {
            string query = "INSERT INTO tbl_user_sleep_data";
            query += "VALUES (@user_id, @sleep_data_id, @sleep_data)";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@user_id", user_id);
            cmd.Parameters.AddWithValue("@sleep_data_id", sleep_data_id);
            cmd.Parameters.AddWithValue("@sleep_data", sleep_data);
        }

        static void Main(string[] args)
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri("ampq://admin:medical-pass@77.55.208.10:5672");
            string exchange = "";
            string queue = "Smartwatch";
            string rKey = "";
            string type = "";
            bool d = true;

            RabbitConfiguration rmqConnection = new RabbitConfiguration(factory, exchange, rKey, type, d, queue);

            Console.WriteLine("");

            try
            {
                string connectionString = "server=77.55.208.10;port=3306;uid=michals;pwd=michals-pass;database=industry4medical;charset=utf8";
                MySqlConnection con = new MySqlConnection(connectionString);

                con.Open();
                Console.WriteLine("Connection is: " + con.State.ToString() + Environment.NewLine);

                MySqlCommand command = con.CreateCommand();

                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM tbl_user";

                MySqlDataReader rd = command.ExecuteReader();

                con.Close();
                Console.WriteLine("Connection is: " + con.State.ToString() + Environment.NewLine);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message.ToString());
            }
        }
    }
}
