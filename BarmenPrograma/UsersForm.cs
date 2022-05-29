using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace BarmenPrograma
{
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asd\Documents\Cafedb.mdf;Integrated Security=True;Connect Timeout=30");
  
        void populate()
        {
            Con.Open();
            string query = "select * from UsersTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            UsersGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void OrderButtonUsersForm_Click(object sender, EventArgs e)
        {
            UserOrder usersOrder = new UserOrder();
            usersOrder.Show();
            this.Hide();
        }

        private void ItemsButtonUsersForm_Click(object sender, EventArgs e)
        {
            ItemForm itemForm = new ItemForm();
            itemForm.Show();
            this.Hide();
        }

        private void UsersFromLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "insert into UsersTbl values('"+UnameTb.Text+"', '"+UphoneTb.Text+"', '"+UpassTb.Text+"')";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("User Succesfully Created");
            Con.Close();
            populate();
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void UsersGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UnameTb.Text = UsersGV.SelectedRows[0].Cells[0].Value.ToString();
            UphoneTb.Text = UsersGV.SelectedRows[0].Cells[1].Value.ToString();
            UpassTb.Text = UsersGV.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (UphoneTb.Text == "")
            {
                MessageBox.Show("Select the user to delete");
            }
            else
            {
                Con.Open();
                string query = "delete from UsersTbl where Uphone = '"+UphoneTb.Text+"' ";
                SqlCommand cmd = new SqlCommand(@query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Deleted");
                Con.Close();
                populate();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (UphoneTb.Text == "" || UpassTb.Text == "" || UnameTb.Text == "")
            {
                MessageBox.Show("Fill all the fields");
            }
            else
            {
                Con.Open();
                string query = "update UsersTbl set Uname='" + UnameTb.Text + "', Upassword='" + UpassTb.Text + "' where Uphone = '"+UphoneTb.Text+"' ";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Edited");
                Con.Close();
                populate();
            }
        }
    }
}
