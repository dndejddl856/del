using System;
using System.Windows.Forms;
using System.Drawing;
using System.Net;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using MySql.Data.MySqlClient;

namespace Delivery
{
    public partial class Main : Form
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;port=3306;Database=delivery;Uid=root;Pwd=gusals856");
        string LoginUser = null;
        public Main(string _LoginUser)
        {
            InitializeComponent();

            this.LoginUser = _LoginUser;
            string sql = "SELECT * FROM user where user_id = '" + LoginUser + "'";
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader table = cmd.ExecuteReader();

            User user = new User();
            while(table.Read())
            {
                user.user_id = table["user_id"].ToString();
                user.password = table["password"].ToString();
                user.user_name = table["user_name"].ToString();
                user.age = table["age"].ToString();
                user.user_address = table["user_address"].ToString();
            }
            label2.Text = user.user_address;
            label3.Text = user.user_name;

            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void buttom2_Click(object sender, EventArgs e)
        {
            Order order = new Order(LoginUser);
            order.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OrderHistory orderhistory = new OrderHistory(LoginUser);
            orderhistory.ShowDialog();
        }
    }
}
