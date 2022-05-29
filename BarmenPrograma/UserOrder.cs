using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BarmenPrograma
{
    public partial class UserOrder : Form
    {
        public UserOrder()
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
            ItemsGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            UsersForm usersForm = new UsersForm();
            usersForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ItemForm Item = new ItemForm();
            Item.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int num = 0;
        int price, qty, total;
        string item,cat;

        private void button1_Click(object sender, EventArgs e)
        {
            if (QtyTb.Text == "")
            {
                MessageBox.Show("Inseret Quantity");
            }
            else if (flag == 0)
            {
                MessageBox.Show("Select Product to Add");
            }
            else
            {
                num = num + 1;
                total = price * Convert.ToInt32(QtyTb.Text);
                table.Rows.Add(num,Item,cat,price,total);
                OrdersGV.DataSource = table;
                flag = 0;
            }
        }
        DataTable table = new DataTable();
        int flag = 0;
        private void UserOrder_Load(object sender, EventArgs e)
        {
            populate();
            table.Columns.Add("Num", typeof(int));
            table.Columns.Add("Item", typeof(string));
            table.Columns.Add("Category", typeof(string));
            table.Columns.Add("UnitPrice", typeof (int));
            table.Columns.Add("Total", typeof(int));
            OrdersGV.DataSource = table;
        }

        private void ItemsGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Name = ItemsGV.SelectedRows[0].Cells[1].Value.ToString();
            cat = ItemsGV.SelectedRows[0].Cells[2].Value.ToString();
            price = Convert.ToInt32(ItemsGV.SelectedRows[0].Cells[3].Value.ToString());
            flag = 1;

        }
    }
}
