using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace CRUDOperation
{
    public partial class Form2 : Form
    {

        SqlConnection con = new SqlConnection("Data Source=OFFICE-PC;Initial Catalog=Test;Integrated Security=True");
                  
        public Form2()
        {
            InitializeComponent();
        }

        public void Form2_Load(object sender, EventArgs e)
        {
            label5.Text = Login.SetValueForText1;
            
        }  
        
      
        private void insert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=OFFICE-PC;Initial Catalog=Test;Integrated Security=True");
            SqlCommand cmd;
            con.Open();

            int reg = (int)Convert.ToInt32(reg_no.Text);

            string s = "insert into stu_info(name,reg_no,qualification) values (@name,@reg,@qua)";
            cmd = new SqlCommand(s, con);
            cmd.Parameters.AddWithValue("@name", name.Text);
            cmd.Parameters.AddWithValue("@reg", reg);
            cmd.Parameters.AddWithValue("@qua", qualification.Text);

            cmd.CommandType = CommandType.Text;
            int i = cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Inserted ");
            ClearData();
            data();
        }

        private void update_Click(object sender, EventArgs e)
        {

            update();
        }

        //Clear Data  
        private void ClearData()
        {
            name.Text = "";
            reg_no.Text = "";
            qualification.Text = "";
       }
        
        //private void button17_Click(object sender, EventArgs e)
        //{
        //    string user_id = dataGridView1.CurrentRow.Cells["USER_ID"].Value.ToString();
        //    if (conn.State == ConnectionState.Closed)
        //    {
        //        conn.Open();
        //    }

        //    OracleCommand orcs = conn.CreateCommand();
        //    orcs.CommandType = CommandType.Text;
        //    orcs.CommandText = "delete from biometric_user where user_id = '" + user_id + "' ";
        //    orcs.ExecuteNonQuery();
        //    MessageBox.Show("Record Deleted");
        //    loadData();
        //    conn.Close();
        //}

        //private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        //{
        //    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
        //    {
        //        string id = row.Cells[0].Value.ToString();
        //        string name = row.Cells[1].Value.ToString();
        //        string registration = row.Cells[2].Value.ToString();
        //        string qualification = row.Cells[3].Value.ToString();
        //        MessageBox.Show(id);
        //        MessageBox.Show(name);
               
        //    }

        
             private void btn_Delete_Click_1(object sender, EventArgs e)
        {
                
                string id = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                
                SqlCommand cmd;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string s = "delete from stu_info where id=@id";
                cmd = new SqlCommand(s, con);
               
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!");
                update_Click(sender,e);
                data();

                
            

        }

             public void update() {

                 string id = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                 string name = dataGridView1.CurrentRow.Cells["name"].Value.ToString();
                 string reg_no = dataGridView1.CurrentRow.Cells["reg_no"].Value.ToString();
                 string qualification = dataGridView1.CurrentRow.Cells["qualification"].Value.ToString();
                 SqlCommand cmd;
                 if (con.State == ConnectionState.Closed)
                 {
                     con.Open();
                 }
                 string s = "update stu_info set name=@name,reg_no=@reg_no,qualification=@qualification where id=@id";
                 cmd = new SqlCommand(s, con);
                 cmd.Parameters.AddWithValue("@id", id);
                 cmd.Parameters.AddWithValue("@name", name);
                 cmd.Parameters.AddWithValue("@reg_no", reg_no);
                 cmd.Parameters.AddWithValue("@qualification", qualification);
                 cmd.ExecuteNonQuery();
                 MessageBox.Show("Record Updated Successfully");
                 con.Close();
                 data();
             
             
             
             }

             private void Form1_Load(object sender, EventArgs e)
             {
                 data();
                

             }

        public void data()
        {
            SqlConnection con = new SqlConnection("Data Source=OFFICE-PC;Initial Catalog=Test;Integrated Security=True");
            SqlCommand cmd;

            try
            {
                string s = "select * from stu_info";

                cmd = new SqlCommand(s, con);
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;

                DataTable dt = new DataTable();

                da.Fill(dt);

                BindingSource bsource = new BindingSource();

                bsource.DataSource = dt;

                dataGridView1.DataSource = bsource;

            }

            catch (Exception ec)
            {

                MessageBox.Show(ec.Message);

            }
        
        }


        }



    }


