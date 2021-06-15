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
    public partial class AllMenu : Form
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;port=3306;Database=delivery;Uid=root;Pwd=gusals856");

        public AllMenu()
        {
            InitializeComponent();
            string sql = "SELECT * FROM restaurant";
            connection.Open();
            MySqlDataAdapter adapt = new MySqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "")
            {
                MessageBox.Show("모든 정보를 입력해 주세요");
            }
            else
            {
                try
                {

                    string sql = "SELECT * FROM restaurant WHERE kinds = '" + textBox1.Text + "' AND restaurant_name = '" + textBox2.Text + "';";
                    connection.Open();
                    MySqlDataAdapter adapt = new MySqlDataAdapter(sql, connection);
                    DataTable dt = new DataTable();
                    adapt.Fill(dt);
                    dataGridView1.DataSource = dt;
                    connection.Close();
                }catch(Exception exa1)
                {
                    MessageBox.Show("정확한 정보를 입력하시오.");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM restaurant";
            connection.Open();
            MySqlDataAdapter adapt = new MySqlDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
        }

       
        
    }
}
