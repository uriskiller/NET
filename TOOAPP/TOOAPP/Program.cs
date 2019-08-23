using System;
using System.Data;
using System.Diagnostics;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace TODOAPP
{
    public class Program
    {

        public static void Main()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            string connStr = "server=localhost;user=root;database=basdb;port=3306;password=12354";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                Console.WriteLine("Introduce el ID");
                String id = Console.ReadLine();
                string sql = "SELECT * FROM cargonet_pagos WHERE ID=" + id;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    Console.WriteLine("Fetch data");
                    while (rdr.Read())
                    {
                        Console.WriteLine(" ID:" + rdr[0] + "\n Folio: " + rdr[3] + "\n Total: " + rdr[11]);
                    }
                }
                else
                {
                    Console.WriteLine("There aren't data");
                }
                rdr.Close();








            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
        }

    }

}
