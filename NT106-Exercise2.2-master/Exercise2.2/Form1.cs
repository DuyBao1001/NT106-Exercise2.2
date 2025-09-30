using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Exercise2._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateLogin())
            {
                return;
            }

            MessageBox.Show("Đăng nhập thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool ValidateLogin()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Tên đăng nhập không được để trống!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Mật khẩu không được để trống!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
                return false;
            }

            if (!checkBox1.Checked)
            {
                MessageBox.Show("Vui lòng xác nhận không phải là người máy!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBox1.Focus();
                return false;
            }

            // Kết nối SQL Server
            string connectionString = @"Server=NHATMINH\SQLEXPRESS;Database=QuanLyUser;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM Users WHERE Username=@username AND Password=@password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", textBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", textBox2.Text.Trim());

                    int result = (int)cmd.ExecuteScalar();

                    if (result > 0)
                    {
                        return true; // Đăng nhập thành công
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
                    return false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Tùy chỉnh xử lý nếu cần
        }
    }
}
