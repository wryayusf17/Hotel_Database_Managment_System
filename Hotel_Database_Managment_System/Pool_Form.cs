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
    public partial class Pool_Form : Form
    {
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=hotel;";
        MySqlConnection databaseConnection;
        public Pool_Form()
        {
            InitializeComponent();
            databaseConnection = new MySqlConnection(connectionString);
            databaseConnection.Open();
            getData();

        }
        void getData()
        {
            try
            {
                String sql = "SELECT * FROM `pool`";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, databaseConnection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception)
            {


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "INSERT INTO `pool`( `RoomId`, `ReservationId`, `Hours`, `Date`, `Payment`) " +
                    "VALUES ('" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', '" + textBox5.Text + "')";
                MySqlCommand cmd = new MySqlCommand(sql, databaseConnection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("inserted ");
                getData();
                clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show("bbura hallayak haya ");
                MessageBox.Show(ex.ToString());
            }
        }
        void clear()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                dateTimePicker1.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString());
                textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception)
            {


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                string sql = "UPDATE `pool` SET `RoomId`='" + textBox2.Text + "',`ReservationId`='" + textBox3.Text + "',`Hours`='" + textBox4.Text + "'," +
                   "`Date`='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "',`Payment`='" + textBox5.Text + "' WHERE GuestId = " + int.Parse(textBox1.Text) + "";
                MySqlCommand cmd = new MySqlCommand(sql, databaseConnection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated ");
                getData();
                clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length > 0)
                {
                    string sql = "DELETE FROM `pool` WHERE GuestId = " + int.Parse(textBox1.Text.ToString()) + "";
                    MySqlCommand cmd = new MySqlCommand(sql, databaseConnection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("deleted ");
                    getData();
                    clear();
                }
                else
                    MessageBox.Show("pleas select item ");
            }
            catch (Exception)
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("everything is saved ");
        }
    }
}
