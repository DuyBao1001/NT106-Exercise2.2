using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Exercise2._2
{
    string connectionString = @"Server=localhost;Database=QuanLyUser;Integrated Security=True;";
    private bool ValidateLogin()
    {
        if (string.IsNullOrWhiteSpace(textBox1.Text))
        {
            MessageBox.Show("Tên đăng nhập không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            textBox1.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(textBox2.Text))
        {
            MessageBox.Show("Mật khẩu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            textBox2.Focus();
            return false;
        }

        if (!checkBox1.Checked)
        {
            MessageBox.Show("Vui lòng xác nhận không phải là người máy!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            checkBox1.Focus();
            return false;
        }

        // Kiểm tra database
        string connectionString = @"Server=localhost;Database=QuanLyUser;Integrated Security=True;";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            try
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM Users WHERE Username=@username AND Password=@password";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", textBox1.Text);
                    cmd.Parameters.AddWithValue("@password", textBox2.Text);

                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối SQL: " + ex.Message);
                return false;
            }
        }
    }

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

            return true;
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

        }
    }
}