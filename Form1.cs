using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjectDAD
{
    public partial class Form1 : Form
    {

        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\PUBLIC PC\Desktop\ASG\sharanya\DAD\ProjectDAD\ProjectDAD\smartmovers.mdf;Integrated Security=True");
        SqlCommand command;


        public Form1()
        {
            InitializeComponent();
        }

        private void openconnection()
        {
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

        }

        private void closeconnection()
        {
            if(connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public void executequery(string query)
        {
            try
            {
                openconnection();
                command = new SqlCommand(query, connection);

                if(command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Successfully saved!!!");
                }
                else
                {
                    MessageBox.Show("Saved unsuccessfull!!!");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closeconnection();
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            string updatequery = "update customer set cusid=" + txtid.Text + ",cusname='" + txtname.Text + "',type='" + txttype.Text + "' where cusid=" + txtid.Text + "";
            executequery(updatequery);
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            string deletequery = "delete from customer where cusid="+txtid.Text+"";
            executequery(deletequery);
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
           
            string insertQuery = "insert into customer(cusid,cusname,type) values ("+txtid.Text+",'"+txtname.Text+"','"+txttype.Text+"')";
            executequery(insertQuery);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
