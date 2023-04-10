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
    public partial class Guest_Form : Form
    {
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=hotel;";
        MySqlCommand commandDatabase;
        MySqlConnection databaseConnection;
        String marridstatuse = "";
        String gender = "";
        public Guest_Form()
        {
            InitializeComponent();
            databaseConnection = new MySqlConnection(connectionString);
            databaseConnection.Open();
            
            getData();
        }
        void getData()
        {
            clear();
            String query = "SELECT `Guest Id`, `First Name`, `Middle Name`, `Last Name`, `Title`, `Email`, `phone`, `Address`, `City`, `Country`, `Room No`, `Gender`, `Maritid Status`, `Passport No`, `Booking id`, `Notes` FROM `guest`";

            commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader = commandDatabase.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(),
                    reader.GetValue(3).ToString(), reader.GetValue(4).ToString(), reader.GetValue(5).ToString(),
                    reader.GetValue(6).ToString(), reader.GetValue(7).ToString(),
                     reader.GetValue(8).ToString(),
                     reader.GetValue(9).ToString(),
                     reader.GetValue(10).ToString(),
                     reader.GetValue(11).ToString(),
                     reader.GetValue(12).ToString(),
                     reader.GetValue(13).ToString(),
                     reader.GetValue(14).ToString(),
                     reader.GetValue(15).ToString());
            }
            reader.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*try
            {*/

                string query = "INSERT INTO `guest`( `First Name`, `Middle Name`, `Last Name`, `Title`, `Email`, `phone`, `Address`, `City`, `Country`, `Room No`, `Gender`, `Maritid Status`, `Passport No`, `Booking id`, `Notes`) " +
                    "VALUES ('" + textBox2.Text.ToString() + "'," +
                    "'" + textBox3.Text.ToString() + "'," +
                    "'" + textBox4.Text.ToString() + "'," +
                    "'" + textBox5.Text.ToString() + "'," +
                    "'" + textBox6.Text.ToString() + "'," +
                    "'" + textBox7.Text.ToString() + "'," +
                    "'" + textBox8.Text.ToString() + "'," +
                    "'" + textBox9.Text.ToString() + "'," +
                    "'" + textBox10.Text.ToString() + "'," +
                    "'" + textBox11.Text.ToString() + "'," +
                    "'" + gender.ToString() + "'," +
                    "'" + marridstatuse.ToString() + "'," +
                    "'" + textBox12.Text.ToString() + "'," +
                    "'" + textBox13.Text.ToString() + "'," +
                    "'" + textBox14.Text.ToString() + "')";
                // Prepare the connection

                commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.ExecuteNonQuery();
             
                MessageBox.Show("Inserted");
            getData();
            /*}
            catch (Exception)
            {
                MessageBox.Show("we have a problme");
            }*/
        }

        private void clear()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.Rows.RemoveAt(i);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String sql = "UPDATE `guest` SET " +
                "`First Name`='"+ textBox2.Text.ToString() + "'," +
                "`Middle Name`='" + textBox3.Text.ToString() + "'," +
                "`Last Name`='" + textBox4.Text.ToString() + "'," +
                "`Title`='" + textBox5.Text.ToString() + "'," +
                "`Email`='" + textBox6.Text.ToString() + "'," +
                "`phone`='" + textBox7.Text.ToString() + "'," +
                "`Address`='" + textBox8.Text.ToString() + "'," +
                "`City`='" + textBox9.Text.ToString() + "'," +
                "`Country`='" + textBox10.Text.ToString() + "'," +
                "`Room No`='" + textBox11.Text.ToString() + "'," +
                "`Gender`='" + gender.ToString() + "'," +
                "`Maritid Status`='" + marridstatuse.ToString() + "'," +
                "`Passport No`='" + textBox12.Text.ToString() + "'," +
                "`Booking id`='" + textBox13.Text.ToString() + "'," +
                "`Notes`='" + textBox14.Text.ToString() + "' " +
                "WHERE `Guest Id`= "+int.Parse(textBox1.Text.ToString())+"";
            commandDatabase = new MySqlCommand(sql, databaseConnection);
            commandDatabase.ExecuteNonQuery();
            MessageBox.Show("updated");
            getData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length>0)
            {
                String sql = "delete from `guest` where  `Guest Id`= " + int.Parse(textBox1.Text.ToString()) + "";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[1] != null)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                textBox10.Text =dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                textBox11.Text =dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                if (dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString().Equals(male.Text.ToString()))
                {
                    male.Checked = true;
                    fmale.Checked = false;
                }
                else
                {
                    fmale.Checked = true;
                    male.Checked = false;
                }

                if (dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString().Equals(marrid.Text.ToString()))
                {
                    marrid.Checked = true;
                    nomarrid.Checked = false;
                }
                else
                {
                    nomarrid.Checked = true;
                    marrid.Checked = false;
                }
                
                textBox12.Text = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
                textBox13.Text = dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString();
                textBox14.Text = dataGridView1.Rows[e.RowIndex].Cells[15].Value.ToString();
            }
                

        }

        private void male_CheckedChanged(object sender, EventArgs e)
        {
            if (male.Checked)
            {
                gender = male.Text.ToString();
                male.Checked = true;
                fmale.Checked = false;
            }
            
        }

        private void fmale_CheckedChanged(object sender, EventArgs e)
        {
            if (fmale.Checked)
            {
                gender = fmale.Text.ToString();
                fmale.Checked = true;
                male.Checked = false;
            }
        }

        private void marrid_CheckedChanged(object sender, EventArgs e)
        {
            if (marrid.Checked)
            {
                marridstatuse = marrid.Text.ToString();
                marrid.Checked = true;
                nomarrid.Checked = false;
            }
        }

        private void nomarrid_CheckedChanged(object sender, EventArgs e)
        {
            if (nomarrid.Checked)
            {
                marridstatuse = nomarrid.Text.ToString();
                nomarrid.Checked = true;
                marrid.Checked = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }       
}           
