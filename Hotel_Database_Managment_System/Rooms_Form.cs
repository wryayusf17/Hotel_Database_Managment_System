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
    public partial class Rooms_Form : Form
    {
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=hotel;";
        MySqlCommand commandDatabase;
        MySqlConnection databaseConnection;
        String roomType = "";
        public Rooms_Form()
        {
            InitializeComponent();
            databaseConnection = new MySqlConnection(connectionString);
            databaseConnection.Open();
            getData();
        }
        void getData()
        {
            clear();
            String query = "select id,room_type,description,tprice,location from rooms";
            
            commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader = commandDatabase.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), reader.GetValue(4).ToString());
            }
            reader.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "insert into rooms (room_type,description,tprice,location)" +
                " values ('" + roomType + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "')";
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
        
        void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                dataGridView1.Rows.RemoveAt(i);
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Rows[e.RowIndex].Cells[1] != null)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString().Equals(Single.Text.ToString()))
                {
                    Single.Checked = true;
                }
                else
                {
                    Double.Checked = true;
                }
                textBox2.SelectedText = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String sql = "update rooms set `room_type`='"+roomType.ToString()+"',`description`='"+textBox2.Text+"',`tprice`='"+textBox3.Text+"',`location`='"+textBox4.Text+"' where id = "+int.Parse(textBox1.Text.ToString()) +"";
            commandDatabase = new MySqlCommand(sql, databaseConnection);
            commandDatabase.ExecuteNonQuery();
            MessageBox.Show("updated");
            getData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                
                String sql = "delete from rooms where id = " + int.Parse(textBox1.Text.ToString()) + "";
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

        private void Single_CheckedChanged(object sender, EventArgs e)
        {
            if (Single.Checked)
            {
                roomType = Single.Text.ToString();
                Single.Checked = true;
                Double.Checked = false;
            }
        }

        private void Double_CheckedChanged(object sender, EventArgs e)
        {
            if (Double.Checked)
            {
                roomType = Double.Text.ToString();
                Single.Checked = false;
                Double.Checked = true;
            }
        }
    }
}
