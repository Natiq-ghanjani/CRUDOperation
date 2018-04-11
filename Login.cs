using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace CRUDOperation
{
    public partial class Login : Form
        
    {
        public static string SetValueForText1 = "";  

       
        SqlConnection con = new SqlConnection("Data Source=OFFICE-PC;Initial Catalog=Test;Integrated Security=True");
        public Login()
        {
            
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void username_Leave(object sender, EventArgs e)
        {
            if (username.Text != "")
            {


                if (!Regex.IsMatch(username.Text, @"^[a-zA-Z]+$"))
                {
                    errorProvider1.SetError(username, "Only use alphabates");
                }
                else
                {

                    errorProvider1.Clear();
                }
            }
            
        }

        public void loginbtn_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection con = new SqlConnection(@"Data Source=OFFICE-PC;Initial Catalog=Test;Integrated Security=True"))
            {
                
                SqlCommand cmd = new SqlCommand("select * from Users where username like @username and password = @password;");
                cmd.Parameters.AddWithValue("@username", username.Text);
                cmd.Parameters.AddWithValue("@password", password.Text);
                cmd.Connection = con;
                con.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();

                bool loginSuccessful = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

                if (loginSuccessful)
                {
                    SetValueForText1 = username.Text;
                    MessageBox.Show("Login Successful!");
                    MessageBox.Show(SetValueForText1);
                    this.Hide();
                    new Form2().Show();
                    
                }
                else
                {
                    MessageBox.Show("Invalid Credentials.");
                    password.Text = "";
                }
            }


           
        }
    }
}
