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
    public partial class OrderHistory : Form
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;port=3306;Database=delivery;Uid=root;Pwd=gusals856");
        string LoginUser;
        public OrderHistory(string _LoginUser)
        {
            LoginUser = _LoginUser;
            InitializeComponent();
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
            label2.Text = user.user_id;
            label5.Text = user.user_address;
            connection.Close();

            connection.Open();
            string sql2 = "SELECT * FROM orderhistory where user_id = '" + LoginUser + "'";
            MySqlDataAdapter adapt = new MySqlDataAdapter(sql2, connection);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Close();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try//예외 처리
            {
                if (MessageBox.Show("주문 취소하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    connection.Open();
                    DataGridViewRow CR = dataGridView1.CurrentRow;

                    string deleteQuery = "DELETE FROM orderhistory WHERE restaurant_name = '" + (string)CR.Cells[2].Value + "'AND number = '" + (string)CR.Cells[6].Value + "';";
                    MySqlCommand command = new MySqlCommand(deleteQuery, connection);

                    // 만약에 내가처리한 Mysql에 정상적으로 들어갔다면 메세지를 보여주라는 뜻이다
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("주문이 취소되었습니다!");
                        string sql2 = "SELECT * FROM orderhistory where user_id = '" + LoginUser + "'";
                        MySqlDataAdapter adapt = new MySqlDataAdapter(sql2, connection);
                        DataTable dt = new DataTable();
                        adapt.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("정확한 정보를 입력해주세요!");
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("정확한 정보를 선택해주세요");
            }
            connection.Close();
        }
    }
    
}
