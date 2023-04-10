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
    public partial class Booking_Form : Form
    {
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=hotel;";
        MySqlCommand commandDatabase;
        MySqlConnection databaseConnection;
        public Booking_Form()
        {
            InitializeComponent();
            databaseConnection = new MySqlConnection(connectionString);
            databaseConnection.Open();
            getData();
        }
        void getData()
        {
            clear();
            String query = "SELECT `Booking Id`, `Guest Id`, `Room Id`, `Booking Date`, `Status`, `Chack In`, `Chack Out`, `Days range` FROM `booking`";

            commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader = commandDatabase.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), 
                    DateTime.Parse(reader.GetValue(3).ToString()).ToString("yyyy-MM-dd"), reader.GetValue(4).ToString(), DateTime.Parse(reader.GetValue(5).ToString()).ToString("yyyy-MM-dd"),
                    DateTime.Parse(reader.GetValue(6).ToString()).ToString("yyyy-MM-dd"), reader.GetValue(7).ToString());
            }
            reader.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                string query = "INSERT INTO `booking`( `Guest Id`, `Room Id`, `Booking Date`, `Status`, `Chack In`, `Chack Out`, `Days range`) " +
                    "VALUES ('"+ textBoxGuestId.Text.ToString() + "'," +
                    "'"+ textBoxRoomId.Text.ToString() + "'," +
                    "'"+ dateTimePickerBookingDate.Value.ToString("yyyy-MM-dd") + "'," +
                    "'"+ textBoxStatus.Text.ToString() + "'," +
                    "'"+ dateTimePickerCheckIn.Value.ToString("yyyy-MM-dd") + "'," +
                    "'" + dateTimePickerCheckOut.Value.ToString("yyyy-MM-dd") + "'," +
                    "'"+ textBoxDaysRange.Text.ToString() + "')";
                // Prepare the connection

                commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.ExecuteNonQuery();
                getData();


                MessageBox.Show("Inserted");
            }
            catch (Exception)
            {
                MessageBox.Show("we have a problme");
            }
        }

        private void clear()
        {
            textBoxBookingId.Text = "";
                 textBoxGuestId.Text = "";
            textBoxRoomId.Text = "";
                 textBoxStatus.Text = "";
          
                textBoxDaysRange.Text = "";
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.Rows.RemoveAt(i);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex] != null)
            {
                
                textBoxBookingId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBoxGuestId.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBoxRoomId.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                dateTimePickerBookingDate.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                textBoxStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                dateTimePickerCheckIn.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                dateTimePickerCheckOut.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
                textBoxDaysRange.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String sql = "UPDATE `booking` SET " +
                "`Guest Id`='"+ textBoxGuestId.Text.ToString() + "'," +
                "`Room Id`='"+ textBoxRoomId.Text.ToString() + "'," +
                "`Booking Date`='"+ dateTimePickerBookingDate.Value.ToString("yyyy-MM-dd") + "'," +
                "`Status`='"+ textBoxStatus.Text.ToString() + "'," +
                "`Chack In`='"+dateTimePickerCheckIn.Value.ToString("yyyy-MM-dd") + "'," +
                "`Chack Out`='"+dateTimePickerCheckOut.Value.ToString("yyyy-MM-dd") + "'," +
                "`Days range`='"+textBoxDaysRange.Text.ToString()+"'" +
                " WHERE `Booking Id` = "+int.Parse(textBoxBookingId.Text.ToString())+"";
            commandDatabase = new MySqlCommand(sql, databaseConnection);
            commandDatabase.ExecuteNonQuery();
            MessageBox.Show("updated");
            getData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBoxBookingId.Text.Length > 0)
            {
            String sql = "delete from booking where `Booking Id` = " + int.Parse(textBoxBookingId.Text.ToString()) + "";
            commandDatabase = new MySqlCommand(sql, databaseConnection);
            commandDatabase.ExecuteNonQuery();
            MessageBox.Show("deleted");
                getData();
            }
            
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Every things save ");
        }
    }
}

    
       
        

  
    

 
    

  