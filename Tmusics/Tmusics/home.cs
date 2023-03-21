using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tmusics
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Studentdetails Studet = new Studentdetails();
            Studet.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Teacher teacher = new Teacher();
            teacher.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Instruments inst = new Instruments();
            inst.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Class clas = new Class();
            clas.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Instrumentrent instrent = new Instrumentrent();
            instrent.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Payment pay = new Payment();
            pay.Show();
        }
    }
}
