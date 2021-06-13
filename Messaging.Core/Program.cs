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

namespace Messaging.Core
{
    class Program
    {
        static void Main(string[] args)
        {
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
