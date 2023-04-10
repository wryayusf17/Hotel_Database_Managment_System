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

namespace Hotel_Database_Managment_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=hotel;";

        public void login()
        {
            string query = "SELECT * FROM users WHERE username='" + textBoxUsername.Text + "' AND password='" + textBoxPassword.Text + "'";
            // Prepare the connection
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MessageBox.Show("Login to Main_form");
                        Main_Form mform = new Main_Form();
                        mform.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Oops! Something went wrong. Please try again later.");

                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login();
        }
    }
}
