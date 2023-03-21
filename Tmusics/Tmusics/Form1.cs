using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tmusics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Enter the username");
            }
            else if(textBox2.Text=="")
            {
                MessageBox.Show("Enter the password");
            }
            else
            {
                try
                {
                    SqlConnection conn = new SqlConnection("Data Source=DESKTOP-39MKE60\\MSSQLSERVER01;Initial Catalog=Tmusics;Integrated Security=True"); 
                    SqlCommand cmd = new SqlCommand("Select * from login where username = @username and password = @password",conn);
                    cmd.Parameters.AddWithValue("@username",textBox1.Text);
                    cmd.Parameters.AddWithValue("@password",textBox2.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable(); 
                    da.Fill(dt);
                    if(dt.Rows.Count>0)
                    {
                        this.Hide();
                        home hom = new home();
                        hom.Show();
                        MessageBox.Show("login successfull");
                    }
                    else
                    {
                        MessageBox.Show("Incorrect username or password");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
        }
    }
}
