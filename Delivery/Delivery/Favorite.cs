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
    public partial class Favorite : Form
    {
        MySqlConnection connection = new MySqlConnection("Server=localhost;port=3306;Database=delivery;Uid=root;Pwd=gusals856;");
        string LoginId;
        public Favorite(string _LoginId)
        {
            LoginId = _LoginId;
            InitializeComponent();
            string sql = "SELECT * FROM user where user_id = '" + LoginId + "'";
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader table = cmd.ExecuteReader();
            User user = new User();
            while (table.Read())
            {
                user.user_id = table["user_id"].ToString();
                user.password = table["password"].ToString();
                user.user_name = table["user_name"].ToString();
                user.age = table["age"].ToString();
                user.user_address = table["user_address"].ToString();
            }
            label2.Text = user.user_id;
            connection.Close();

            connection.Open();
            string sql2 = "SELECT * FROM restaurant ;";
            MySqlDataAdapter adapt = new MySqlDataAdapter(sql2, connection);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();

            connection.Open();
            string sql3 = "SELECT * FROM favorite ;";
            MySqlDataAdapter adapt2 = new MySqlDataAdapter(sql3, connection);
            DataTable dt2 = new DataTable();
            adapt2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            connection.Close();

        }

        private void DataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow CR = dataGridView1.CurrentRow;
            }
            catch(Exception exf1)
            {
                MessageBox.Show("데이터 그리드 오류");
            }
        }
        private void Click()
        {
            try
            {

                DataGridViewRow CR = dataGridView1.CurrentRow;
                connection.Open();

                string sql = "SELECT * FROM user WHERE user_id = '" + LoginId + "';";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                MySqlDataReader table = cmd.ExecuteReader();

                //while (table.Read())
                //{
                //    label6.Text = table["user_address"].ToString();
                //    //label12.Text = table["price"].ToString();
                //}
                label9.Text = (string)CR.Cells[0].Value;
                label5.Text = (string)CR.Cells[3].Value;
                label11.Text = (string)CR.Cells[4].Value;
                
                connection.Close();
            }
            catch (Exception eo2)
            {
                MessageBox.Show("Click에서 오류");
                //MessageBox.Show(eo2.Message);
            }
        }
        private void button3_Click(object sender, EventArgs e) // 뒤로가기
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e) //보기
        {
            Click();
        }

        private void button1_Click(object sender, EventArgs e) // 추가
        {
            try
            {
                if (MessageBox.Show("즐겨찾기에 추가하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string insertQuery = "INSERT INTO favorite(restaurant_number,restaurant_address,restaurant_name)" +
                         "VALUES('" + label9.Text + "','" + label5.Text + "','" + label11.Text + "')";
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(insertQuery, connection);
                    try
                    {
                        //정상적으로 입력되면 
                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("즐겨찾기에 추가되었습니다.");
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
            }
            catch (Exception exo4)
            {
                MessageBox.Show("button1(추가)에서 오류");
            }
        }

        ////삭제
        //private void button2_Click(object sender, EventArgs e)
        //{
        //    try//예외 처리
        //    {
        //        if (MessageBox.Show("삭제하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
        //        {
        //            connection.Open();
        //            DataGridViewRow CR = dataGridView2.CurrentRow;

        //            string deleteQuery = "DELETE FROM favorite WHERE restaurant_name = '" + (string)CR.Cells[2].Value + "'AND restaurant_number = '" + (string)CR.Cells[0].Value + "';";
        //            MySqlCommand command = new MySqlCommand(deleteQuery, connection);

        //            // 만약에 내가처리한 Mysql에 정상적으로 들어갔다면 메세지를 보여주라는 뜻이다
        //            if (command.ExecuteNonQuery() == 1)
        //            {
        //                MessageBox.Show("취소되었습니다!");
        //                string sql = "SELECT * FROM favorite where restaurant_number = '" + (string)CR.Cells[0].Value + "';";
        //                MySqlDataAdapter adapt = new MySqlDataAdapter(sql, connection);
        //                DataTable dt = new DataTable();
        //                adapt.Fill(dt);
        //                dataGridView2.DataSource = dt;
        //            }
        //            else
        //            {
        //                MessageBox.Show("정확한 정보를 입력해주세요!");
        //            }
        //        }
        //        else
        //        {

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("정확한 정보를 선택해주세요");
        //    }
        //    connection.Close();
        //}
    }
}
