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
                //textBox1.Text = (string)CR.Cells[0].Value;
                //textBox2.Text = (string)CR.Cells[3].Value;
                //string sql = "SELECT restaurant_name,food,price,restaurant_address,number,rate FROM restaurant WHERE restaurant_name = '" + textBox1.Text + "' AND restaurant_address = '" + textBox2.Text + "';";
                //connection.Open();
                //MySqlCommand cmd = new MySqlCommand(sql, connection);
                //MySqlDataReader table = cmd.ExecuteReader();
                //connection.Close();
                
                groupBox3.Visible = false;
            }
            catch(Exception eo1)
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

              
                groupBox3.Visible = false;
                string sql = "SELECT number FROM restaurant WHERE restaurant_name = '" + textBox1.Text +"'" ;
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                MySqlDataReader table = cmd.ExecuteReader();
                if (textBox1.Text.Trim() == "" || textBox3.Text.Trim() == "")
                {
                    MessageBox.Show("모든 정보를 입력하시오.");

                }
                while (table.Read())
                {
                    
                    if (textBox3.Text == table["number"].ToString()  )
                    {
                        //Click(10);
                        label20.Text = textBox3.Text;
                    }
                    else 
                    {
                        MessageBox.Show("입력하신 가게는 없습니다.");
                        
                    }
                  
                }
                
                connection.Close();
            }catch(Exception exo2)
            {
                MessageBox.Show("일치하는 매장이 없습니다");
            }
        }

       
        private void Click(int x)
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
                x=3000;
                label22.Text = (string)CR.Cells[4].Value;
                label8.Text = (string)CR.Cells[0].Value;
                label10.Text = (string)CR.Cells[1].Value;
                label16.Text = (string)CR.Cells[3].Value;

                string price = (string)CR.Cells[2].Value;
                double price1 = double.Parse(price);
                label12.Text = price.ToString();
                //배달비 
                label15.Text = "3000";
                if(int.Parse(label15.Text) == 3000)
                {
                    price1 = price1 + 3000;
                }
                else
                {
                    price1 = price1;
                }
                label18.Text = price1.ToString();

                connection.Close();
            }
            catch(Exception eo2)
            {
                MessageBox.Show(eo2.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("결제하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string insertQuery = "INSERT INTO orderhistory(user_id,user_address,restaurant_name,food,price,restaurant_address,number" +
                         "VALUES('" + label4.Text + "','" + label6.Text + "','" + label8.Text + "','" + label10.Text + "','" + label18.Text + "','" + label16.Text + "','" + label22.Text + "')";
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(insertQuery, connection);
                    try
                    {
                        //정상적으로 입력되면 
                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("입력하신 정보로 주문 완료되었습니다.");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("오류오류!!!");
                        }
                    }
                    catch (Exception exo3)
                    {
                        MessageBox.Show(exo3.Message);
                    }
                }
                else
                {

                }
                connection.Close();
            }catch(Exception exo4)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox3.Text == label20.Text)
            {
                groupBox3.Visible = true;
                Click(10);
            }
            else
            {
                
            }
        }
    }
}
