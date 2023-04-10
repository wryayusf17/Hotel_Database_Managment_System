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
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
        }

        private void Main_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rooms_Form manageRF = new Rooms_Form();
            manageRF.ShowDialog();
        }

        private void guestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Guest_Form manageGF = new Guest_Form();
            manageGF.ShowDialog();
        }

        private void bookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Booking_Form manageBF = new Booking_Form();
            manageBF.ShowDialog();
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payment_Form managePF = new Payment_Form();
            managePF.ShowDialog();
        }

        private void restaurantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Restaurant_Form manageRF = new Restaurant_Form();
            manageRF.ShowDialog();
        }

        private void poolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pool_Form managePF = new Pool_Form();
            managePF.ShowDialog();
        }

        private void gymToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gym_Form manageGF = new Gym_Form();
            manageGF.ShowDialog();
        }
    }
}
 