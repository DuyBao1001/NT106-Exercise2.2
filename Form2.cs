using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Exercise2_2_New
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button4.Click += new System.EventHandler(this.button4_Click);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!ValidateRegistration())
            {
                return;
            }

            try
            {
                string connectionString = "Server=localhost;Database=QuanLyUser;Integrated Security=True;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"INSERT INTO Users (Username, Password, FullName, Email) 
                                     VALUES (@Username, @Password, @FullName, @Email)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", textBox4.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", textBox5.Text.Trim());
                        cmd.Parameters.AddWithValue("@FullName", textBox3.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", textBox7.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Đăng ký thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng ký: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateRegistration()
        {
            // Kiểm tra tên người chơi
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                ShowError("Tên người chơi không được để trống!", textBox3);
                return false;
            }

            if (textBox3.Text.Length < 4 || textBox3.Text.Length > 50)
            {
                ShowError("Tên người chơi phải từ 4-50 ký tự!", textBox3);
                return false;
            }

            // Kiểm tra tên đăng nhập
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                ShowError("Tên đăng nhập không được để trống!", textBox4);
                return false;
            }

            if (textBox4.Text.Length < 4 || textBox4.Text.Length > 20)
            {
                ShowError("Tên đăng nhập phải từ 4-20 ký tự!", textBox4);
                return false;
            }

            if (!Regex.IsMatch(textBox4.Text, @"^[a-zA-Z0-9]+$"))
            {
                ShowError("Tên đăng nhập phải viết liền và không dấu!", textBox4);
                return false;
            }

            // Kiểm tra mật khẩu
            if (string.IsNullOrWhiteSpace(textBox5.Text))
            {
                ShowError("Mật khẩu không được để trống!", textBox5);
                return false;
            }

            if (!IsPasswordStrong(textBox5.Text))
            {
                ShowError("Mật khẩu phải chứa chữ thường, chữ hoa, số và ký tự đặc biệt (tối thiểu 8 ký tự)!", textBox5);
                return false;
            }

            // Kiểm tra xác nhận mật khẩu
            if (string.IsNullOrWhiteSpace(textBox6.Text))
            {
                ShowError("Vui lòng xác nhận mật khẩu!", textBox6);
                return false;
            }

            if (textBox5.Text != textBox6.Text)
            {
                ShowError("Mật khẩu xác nhận không khớp!", textBox6);
                return false;
            }

            // Kiểm tra email
            if (string.IsNullOrWhiteSpace(textBox7.Text))
            {
                ShowError("Email không được để trống!", textBox7);
                return false;
            }

            if (!IsValidEmail(textBox7.Text))
            {
                ShowError("Email không đúng định dạng!", textBox7);
                return false;
            }

            // Kiểm tra xác nhận không phải robot
            if (!checkBox2.Checked)
            {
                ShowError("Vui lòng xác nhận không phải là người máy!", checkBox2);
                return false;
            }

            // Kiểm tra đồng ý điều khoản
            if (!checkBox3.Checked)
            {
                ShowError("Vui lòng đồng ý với điều khoản sử dụng!", checkBox3);
                return false;
            }

            return true;
        }

        private bool IsPasswordStrong(string password)
        {
            // Ít nhất 8 ký tự, có chữ thường, chữ hoa, số và ký tự đặc biệt
            return Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$");
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private void ShowError(string message, Control control)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            control.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
               // Nếu người dùng chủ động bấm nút X thoát thì thoát toàn app
            if (e.CloseReason == CloseReason.UserClosing)
                {
                      Application.Exit();
                }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
