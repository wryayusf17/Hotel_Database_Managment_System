using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Database_Managment_System
{
    public partial class Payment_Form : Form
    {
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=hotel;";
        MySqlCommand commandDatabase;
        MySqlConnection databaseConnection;
        public Payment_Form()
        {
            InitializeComponent();
            databaseConnection = new MySqlConnection(connectionString);
            databaseConnection.Open();
            getData();
        }
        void getData()
        {
            String query = "SELECT `paymentId`, `GuestId`, `RoomId`, `PaymentDate`, `Pricepernight`, `Priceperiod`, `BookingId`, `Totalamount` FROM `payment` ";

            commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader = commandDatabase.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(),
                    reader.GetValue(3).ToString(), reader.GetValue(4).ToString(), reader.GetValue(5).ToString(),
                    reader.GetValue(6).ToString(), reader.GetValue(7).ToString());
            }
            reader.Close();
            clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string query = "INSERT INTO `payment`(`GuestId`, `RoomId`, `PaymentDate`, `Pricepernight`, `Priceperiod`, `BookingId`, `Totalamount`) " +
                    "VALUES ('" + textBox2.Text.ToString() + "'," +
                    "'" + textBox3.Text.ToString() + "'," +
                    "'" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'," +
                    "'" + textBox4.Text.ToString() + "'," +
                    "'" + textBox5.Text.ToString() + "'," +
                    "'" + textBox6.Text.ToString() + "'," +
                    "'" + textBox7.Text.ToString() + "')";
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
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.Rows.RemoveAt(i);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            String sql = "UPDATE `payment` SET " +
                "`GuestId`='"+textBox2.Text.ToString()+"'," +
                "`RoomId`='" + textBox3.Text.ToString() + "'," +
                "`PaymentDate`='"+dateTimePicker1.Value.ToString("yyyy-MM-dd")+"'," +
                "`Pricepernight`='" + textBox4.Text.ToString() + "'," +
                "`Priceperiod`='" + textBox5.Text.ToString() + "'," +
                "`BookingId`='" + textBox6.Text.ToString() + "'," +
                "`Totalamount`='" + textBox7.Text.ToString() + "'" +
                " WHERE `paymentId`= "+int.Parse(textBox1.Text.ToString())+"";
            commandDatabase = new MySqlCommand(sql, databaseConnection);
            commandDatabase.ExecuteNonQuery();
            MessageBox.Show("updated");
            getData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[1] != null)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                dateTimePicker1.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length>0)
            {
                String sql = "DELETE FROM `payment` where  `paymentId`= " + textBox1.Text.ToString() + "";
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
