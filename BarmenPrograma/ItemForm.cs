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
 

namespace BarmenPrograma
{
    public partial class ItemForm : Form
    {
        public ItemForm()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asd\Documents\Cafedb.mdf;Integrated Security=True;Connect Timeout=30");

        void populate()
        {
            Con.Open();
            string query = "select * from ItemTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ItemGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserOrder order = new UserOrder();
            order.Show();
        }

        private void ItemFormLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserOrder userOrder = new UserOrder();
            userOrder.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ItemNameTb.Text == "" || ItemNumTb.Text == "" || ItemPriceTb.Text == "")
            {
                MessageBox.Show("Fill fields");
            }else
            {
                Con.Open();
                string query = "insert into ItemTbl values('" + ItemNumTb.Text + "', '" + ItemNameTb.Text + "', '" + CatTb.SelectedItem.ToString() + "', '"+ItemPriceTb.Text+"')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Item Succesfully Created");
                Con.Close();
                populate();

            }

        }

        private void ItemForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void ItemGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ItemNumTb.Text = ItemGV.SelectedRows[0].Cells[0].Value.ToString();
            ItemNameTb.Text = ItemGV.SelectedRows[0].Cells[1].Value.ToString();
            CatTb.SelectedItem = ItemGV.SelectedRows[0].Cells[2].Value.ToString();
            ItemPriceTb.Text = ItemGV.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (ItemNumTb.Text == "")
            {
                MessageBox.Show("Select the item to delete");
            }
            else
            {
                Con.Open();
                string query = "delete from ItemTbl where Itemnum = '" + ItemNumTb.Text + "' ";
                SqlCommand cmd = new SqlCommand(@query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Item Deleted");
                Con.Close();
                populate();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (ItemNumTb.Text == "" || ItemNameTb.Text == "" || ItemPriceTb.Text == "")
            {
                MessageBox.Show("Fill all the fields");
            }
            else
            {
                Con.Open();
                string query = "update ItemTbl set ItemName='" + ItemNameTb.Text + "' , ItemCat='" + CatTb.SelectedItem.ToString() + "' where ItemPrice = " + ItemPriceTb.Text + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Item Edited");
                Con.Close();
                populate();
            }

        }
    }
}
