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
    public partial class Admin : Form
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;port=3306;Database=delivery;Uid=root;Pwd=gusals856;");
        
        public Admin()
        {
            InitializeComponent();

            string sql = "SELECT * FROM restaurant";
            connection.Open();
            MySqlDataAdapter adapt = new MySqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.CurrentCellChanged += DataGridView1_CurrentCellChanged;
        }

        private void DataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow CR = dataGridView1.CurrentRow;

                textBox1.Text = (string)CR.Cells[0].Value;
                textBox2.Text = (string)CR.Cells[1].Value;
                textBox3.Text = (string)CR.Cells[2].Value;
                textBox4.Text = (string)CR.Cells[3].Value;
                textBox5.Text = (string)CR.Cells[4].Value;
            }
            catch(Exception ex2)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Close();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" )
            { 
                MessageBox.Show("모든 정보를 입력해주세요.");
            }
            else
            {
                string insertQuery = "INSERT INTO restaurant(restaurant_name,food,price,restaurant_address,number)" +
                "VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";

                MySqlCommand command = new MySqlCommand(insertQuery, connection);
                try//예외 처리
                {
                    // 만약에 내가처리한 Mysql에 정상적으로 들어갔다면 메세지를 보여주라는 뜻이다
                    if (command.ExecuteNonQuery() == 1)
                    {
                        string sql = "SELECT * FROM restaurant";
                        MySqlDataAdapter adapt = new MySqlDataAdapter(sql, connection);
                        DataTable dt = new DataTable();
                        adapt.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("오류오류!!");
                    }
                }
                catch (Exception exa1)
                {
                    MessageBox.Show(exa1.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "")
                {
                    MessageBox.Show("모든 정보를 입력해주세요.");
                }
                else
                {
                    string deleteQuery = "DELETE FROM restaurant WHERE restaurant_name = '" + textBox1.Text + "'AND food = '" + textBox2.Text + "'AND price = '" + textBox3.Text + "'AND restaurant_address = '" + textBox4.Text + "'AND number = '" + textBox5.Text +  "';";
                    MySqlCommand command = new MySqlCommand(deleteQuery, connection);
                    try
                    {
                        if(command.ExecuteNonQuery() == 1)
                        {
                            string sql = "SELECT * FROM restaurant";
                            MySqlDataAdapter adapt = new MySqlDataAdapter(sql, connection);
                            DataTable dt = new DataTable();
                            adapt.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("정확한 정보를 입력해주세요.");
                        }
                    }
                    catch (Exception exa3)
                    {
                        MessageBox.Show(exa3.Message);
                    }
                }
            }
            catch(Exception exa2)
            {
                MessageBox.Show(exa2.Message);
            }
        }
    }
}
