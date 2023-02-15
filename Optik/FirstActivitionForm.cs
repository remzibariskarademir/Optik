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
    public partial class FirstActivitionForm : Form
    {
        public FirstActivitionForm()
        {
            InitializeComponent();
        }
        FirstActivition firstActivition = new FirstActivition();
        private void FirstActivitionForm_Load(object sender, EventArgs e)
        {
            btnback.Text = "Geri";
            btnexit.Text = "Çıkış";
            btnsave.Text = "Kaydet";

            lblanswer.Text = "Cevap :";
            lblemail.Text = "Email :";
            lblpassword.Text = "Yeni Şifre :";
            lblquestion.Text = "Soru Seçiniz :";

            cmbquestion.DataSource = firstActivition.Fill();
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
            if (txtemail.Text == String.Empty || txtpassword.Text == String.Empty || cmbquestion.Text == String.Empty || txtanswer.Text == String.Empty)
            {
                MessageBox.Show("Lütfen alanları doldurunuz");
            }
            else
            {
                firstActivition.Update(txtemail.Text, firstActivition.MD5Hash(txtpassword.Text), cmbquestion.Text, firstActivition.MD5Hash(txtanswer.Text.ToUpper()));
                UserForm userForm = new UserForm();
                userForm.Show();
                this.Close();
            } 
        }
    }
}