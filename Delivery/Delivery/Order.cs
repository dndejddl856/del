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
            DataGridViewRow CR = dataGridView1.CurrentRow;
            //Visible가로 설정 된 경우에도 true 컨트롤은 다른 컨트롤 뒤에 
            //가려져 있는 경우 사용자에 게 표시 되지 않을 수 있습니다.

            string sql = "SELECT restaurant_name,food,price,restaurant_address,number,rate FROM restaurant WHERE restaurant_name = '" ;
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader table = cmd.ExecuteReader();
            connection.Close();



        }
    }
}
