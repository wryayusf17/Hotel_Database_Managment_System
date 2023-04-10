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
    public partial class Restaurant_Form : Form
    {
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=hotel;";
        MySqlConnection databaseConnection;
        

        public Restaurant_Form()
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
                String sql = "SELECT * FROM `restaurant`";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, databaseConnection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception)
            {

                
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                if (radioButton1.Text.ToString() == dataGridView1.CurrentRow.Cells[3].Value.ToString())
                    radioButton1.Checked = true;
                else if (radioButton2.Text.ToString() == dataGridView1.CurrentRow.Cells[3].Value.ToString())
                    radioButton2.Checked = true;
                else if (radioButton3.Text.ToString() == dataGridView1.CurrentRow.Cells[3].Value.ToString())
                    radioButton3.Checked = true;
                else if (radioButton4.Text.ToString() == dataGridView1.CurrentRow.Cells[3].Value.ToString())
                    radioButton4.Checked = true;
                textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                dateTimePicker1.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString());
                textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            }
            catch (Exception)
            {

                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length > 0)
                {
                    string food = "";
                    if (radioButton1.Checked)
                        food = radioButton1.Text.ToString();
                    else if (radioButton2.Checked)
                        food = radioButton2.Text.ToString();
                    else if (radioButton3.Checked)
                        food = radioButton3.Text.ToString();
                    else if (radioButton4.Checked)
                        food = radioButton4.Text.ToString();
                    string sql = "UPDATE `restaurant` SET `RoomId`='" + textBox2.Text.ToString() + "',`OrderId`='" + textBox3.Text.ToString() + "',`FoodItems`='" + food + "'," +
                   "`Quantitay`='" + textBox4.Text.ToString() + "',`Date`='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "',`Price`='" + textBox5.Text.ToString() + "' WHERE GuestId = " + textBox1.Text.ToString() + "";
                    MySqlCommand cmd = new MySqlCommand(sql, databaseConnection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Updated ");
                    getData();
                    clear();
                }
                else
                    MessageBox.Show("there is nothing for update");
            }
            catch (Exception)
            {
                MessageBox.Show("sorry something is wrong ");
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string food = "";
                if (radioButton1.Checked)
                    food = radioButton1.Text.ToString();
                else if (radioButton2.Checked)
                    food = radioButton2.Text.ToString();
                else if (radioButton3.Checked)
                    food = radioButton3.Text.ToString();
                else if (radioButton4.Checked)
                    food = radioButton4.Text.ToString();
                string sql = "INSERT INTO `restaurant`( `RoomId`, `OrderId`, `FoodItems`, `Quantitay`, `Date`, `Price`) " +
                    "VALUES ('" + textBox2.Text + "', '" + textBox3.Text + "','" + food + "', '" + textBox4.Text + "', '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', '" + textBox5.Text + "')";
                MySqlCommand cmd = new MySqlCommand(sql,databaseConnection);
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length > 0)
                {
                    string sql = "DELETE FROM `restaurant` WHERE GuestId = " + int.Parse(textBox1.Text.ToString()) + "";
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
            MessageBox.Show("every thing is saved");
        }
    }
}
