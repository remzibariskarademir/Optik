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
    public partial class FgPasswordForm : Form
    {
        public FgPasswordForm()
        {
            InitializeComponent();
        }
        FgPassword fgPassword = new FgPassword();
        private void FgPasswordForm_Load(object sender, EventArgs e)
        {
            btnback.Text = "Geri";
            btnexit.Text = "Çıkış";
            btnsave.Text = "Kaydet";

            lblquestion.Text = "Soru seçiniz :";
            lblanswer.Text = "Cevap :";
            lblpassword.Text = "Yeni Şifre :";
            lblemail.Text = "Email :";

            cmbquestion.DataSource = fgPassword.Fill();
            cmbquestion.DisplayMember = "Question";
            cmbquestion.ValueMember = "Question";
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if(txtanswer.Text == String.Empty || txtpassword.Text == String.Empty || cmbquestion.Text == String.Empty)
            {
                MessageBox.Show("Lütfen alanları doldurunuz");
            }
            else
            {
                fgPassword.Update(txtemail.Text,cmbquestion.Text, fgPassword.MD5Hash(txtanswer.Text.ToUpper()), fgPassword.MD5Hash(txtpassword.Text));
                UserForm userForm = new UserForm();
                userForm.Show();
                this.Close();
            }
        }
    }
}