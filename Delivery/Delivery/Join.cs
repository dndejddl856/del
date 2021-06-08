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
    public partial class Join : Form
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;port=3306;Database=delivery;Uid=root;Pwd=gusals856;");
        public Join()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "")
                MessageBox.Show("모든 정보를 입력해주세요.");
            else
            {
                string insertQuery = "INSERT INTO user(user_id,password,user_name,age,user_address)" + "VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                connection.Open();
                MySqlCommand command = new MySqlCommand(insertQuery, connection);
                try
                {
                    if(command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("회원가입이 완료되었습니다. ");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("회원가입 오류발생!!!");
                    }
                }
                catch(Exception e1)
                {
                    MessageBox.Show(e1.Message);
                }
            }
            connection.Close();
        }   

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
