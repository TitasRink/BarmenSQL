using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarmenPrograma
{
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();
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
    }
}
