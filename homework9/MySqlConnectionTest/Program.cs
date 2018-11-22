using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MySqlConnectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            String connetStr = "Database=ordersdata;Data Source=localhost;User Id=root;Password=w100220;port=3306";
            MySqlConnection conn = new MySqlConnection(connetStr);
            try
            {
                conn.Open();
                Console.WriteLine("已经建立连接");

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
