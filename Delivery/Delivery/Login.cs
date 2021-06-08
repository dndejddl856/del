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
    public partial class Login : Form
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;port=3306;Database=delivery;Uid=root;Pwd=gusals856;");
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "")
            {
                MessageBox.Show("모든 정보를 입력해주세요.");
            }
            else
            {
                int existId = 0;
                string sql = "SELECT * FROM user";
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                MySqlDataReader table = cmd.ExecuteReader();

                while (table.Read())
                {
                    if (textBox1.Text == table["user_id"].ToString())
                    {
                        if (textBox2.Text == table["password"].ToString())
                        {
                            existId = 1;
                            break;
                        }
                        else
                        {
                            existId = 2;
                            break;
                        }
                    }
                }
                if (existId == 1)
                {
                    if (textBox1.Text == "오현민")
                    {
                        new Admin().ShowDialog();
                    }
                    else
                    {
                        Main main = new Main(textBox1.Text);
                        main.ShowDialog();
                    }
                }
                else if (existId == 2)
                {
                    MessageBox.Show("비밀번호가 틀렸습니다.");
                }
                else
                {
                    MessageBox.Show("존재하지 않는 아이디입니다.");
                }
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Join().ShowDialog();
        }
    }
}
