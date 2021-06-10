using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delivery
{
    public partial class Order : Form 
    {
        string LoginId;
        MySqlConnection connection = new MySqlConnection("Server=localhost;port=3306;Database=delivery;Uid=root;Pwd=gusals856;");

        public Order(string _LoginUser)
        {
            LoginId = _LoginUser;
            InitializeComponent();
            string sql = "SELECT * FROM restaurant";
            connection.Open();
            MySqlDataAdapter adapt = new MySqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            adapt.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.CurrentCellChanged += DataGridView1_CurrentCellChanged;
            connection.Close();
        }

        private void DataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {


                DataGridViewRow CR = dataGridView1.CurrentRow;
                //Visible가로 설정 된 경우에도 true 컨트롤은 다른 컨트롤 뒤에 
                //가려져 있는 경우 사용자에 게 표시 되지 않을 수 있습니다.
                textBox1.Text = (string)CR.Cells[0].Value;
                textBox2.Text = (string)CR.Cells[3].Value;
                //string sql = "SELECT restaurant_name,food,price,restaurant_address,number,rate FROM restaurant WHERE restaurant_name = '" + textBox1.Text + "' AND restaurant_address = '" + textBox2.Text + "';";
                //connection.Open();
                //MySqlCommand cmd = new MySqlCommand(sql, connection);
                //MySqlDataReader table = cmd.ExecuteReader();
                //connection.Close();
                groupBox2.Visible = false;
                groupBox3.Visible = false;
            }
            catch(Exception eo1)
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            textBox4.Text = textBox2.Text;
            string sql = "SELECT food FROM restaurant WHERE restaurant_address = '" + textBox2.Text + "'";
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader table = cmd.ExecuteReader();
            groupBox2.Visible = true;
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox4.Text != textBox2.Text)
            {
                MessageBox.Show("가게 주소가 다릅니다.");
            }
            else
            {
                Click("광명시 하안동");
            }
        }
        private void Click(string x)
        {
            try
            {

                DataGridViewRow CR = dataGridView1.CurrentRow;
                groupBox3.Visible = true;
                connection.Open();

                label4.Text = LoginId;
                string sql = "SELECT * FROM user WHERE user_id = '" + LoginId + "';";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                MySqlDataReader table = cmd.ExecuteReader();

                while (table.Read())
                {
                    label6.Text = table["user_address"].ToString();
                    //label12.Text = table["price"].ToString();
                }
                label16.Text = x;
                //label16.Text = textBox4.Text;
                label8.Text = (string)CR.Cells[0].Value;
                label10.Text = (string)CR.Cells[1].Value;
                label12.Text = (string)CR.Cells[2].Value;
                label15.Text = "3000";

                string price = (string)CR.Cells[2].Value;
                //double price1 = double.Parse(price);
                price = price + 3000;
                label18.Text = price.ToString();
                connection.Close();
            }
            catch(Exception eo2)
            {
                MessageBox.Show(eo2.Message);
            }
        }

       
    }
}
