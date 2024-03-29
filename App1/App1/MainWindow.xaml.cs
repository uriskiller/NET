﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace App1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
        }

        public void execute(String sql)
        {
            string connStr = "server=localhost;user=root;database=basdb;port=3306;password=12354";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {

                    while (rdr.Read())
                    {
                        Label1.Content = " ID:" + rdr[0] + "\n Folio: " + rdr[3] + "\n Total: " + rdr[11];
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("There aren't data");
                    Label1.Content = "";
                }
                txt.Text = "";

                rdr.Close();








            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }

            conn.Close();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(txt.Text) || string.IsNullOrWhiteSpace(txt.Text))
            {
                System.Windows.MessageBox.Show("The 'ID' can't be empty");

            }
            else
            {
                String sql = "SELECT * FROM cargonet_pagos WHERE ID=" + txt.Text;
                execute(sql);
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            Window1 l = new Window1();
            l.Show();
            this.Close();

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(txt.Text) || string.IsNullOrWhiteSpace(txt.Text))
            {
                System.Windows.MessageBox.Show("The 'ID' can't be empty");

            }
            else
            {
                String sql = "DELETE FROM cargonet_pagos WHERE ID=" + txt.Text;
                execute(sql);
            }
        }
    }
}
