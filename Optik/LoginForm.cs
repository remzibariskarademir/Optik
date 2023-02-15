using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optik
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            lblemail.Text = "Email :";
            lblpassword.Text = "Şifre :";

            btnlogin.Text = "Giriş";
            btnfgpassword.Text = "Şifremi Unuttum";
            btnexit.Text = "Çıkış";
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            int status = login.Loginn(txtemail.Text, login.MD5Hash(txtpassword.Text));
            int loginfa = login.LoginFA(txtemail.Text, login.MD5Hash(txtpassword.Text));
            switch (status)
            {
                case 1:
                    MessageBox.Show("Admin Girişi Başarılı.", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                    AdminForm adminForm = new AdminForm();
                    adminForm.Show();
                    this.Visible = false;
                    break;
                case 2:
                    if (loginfa == 0)
                    {
                        MessageBox.Show("İlk girişiniz olduğu için şifrenizi yenilemeniz gerek.");
                        FirstActivitionForm firstActivitionForm = new FirstActivitionForm();
                        firstActivitionForm.Show();
                        this.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı Girişi Başarılı.", "", MessageBoxButtons.OK, MessageBoxIcon.None);
                        UserForm userForm = new UserForm();
                        userForm.Show();
                        this.Visible = false;
                    }
                    break;
                default:
                    MessageBox.Show("Email ya da şifre hatalı tekrar deneyiniz.", "",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnfgpassword_Click(object sender, EventArgs e)
        {
            FgPasswordForm fgPasswordForm = new FgPasswordForm();
            fgPasswordForm.Show();
            this.Visible = false;
        }
    }
}