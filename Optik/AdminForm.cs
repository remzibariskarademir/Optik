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
    public partial class AdminForm : Form
    {
        public string UId;
        public string name;
        public string surname;
        public string email;
        public string phone;
        Admin admin = new Admin();
        private void AdminForm_Load(object sender, EventArgs e)
        {
            btnback.Text = "Geri";
            btnexit.Text = "Çıkış";
            btnlist.Text = "Listele";
            btnadd.Text = "Ekle";
            btndelete.Text = "Sil";
            btnupdate.Text = "Güncelle";
            btnclear.Text = "Temizle";

            lblemail.Text = "Email :";
            lblname.Text = "İsim :";
            lblsurname.Text = "Soy isim :";
            lblphone.Text = "Telefon numarası :";

            chbpasiflist.Text = "Silinen Kullanıcılar";

            dataGridView1.DataSource = admin.Fill();

            btndelete.Enabled = false;
            btnupdate.Enabled = false;
        }
        public AdminForm()
        {
            InitializeComponent();
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btnupdate.Enabled = true;
            btndelete.Enabled = true;
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                UId = row.Cells[0].Value.ToString();
                name = row.Cells[1].Value.ToString();
                surname = row.Cells[2].Value.ToString();
                email = row.Cells[4].Value.ToString();
                phone = row.Cells[5].Value.ToString();   
            }
        }

        private void btnlist_Click(object sender, EventArgs e)
        {
            if (chbpasiflist.Checked)
            {
                dataGridView1.DataSource = admin.PasifFill();
                btndelete.Enabled = false;
                btnupdate.Enabled = false;
            }
            else
            {
                dataGridView1.DataSource = admin.Fill();
                btndelete.Enabled = false;
                btnupdate.Enabled = false;
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txtname.Text == String.Empty || txtsurname.Text == String.Empty || txtemail.Text == String.Empty || txtphone.Text== String.Empty)
            {
                MessageBox.Show("Lütfen alanları doldurunuz");
            }
            else
            {
                admin.Add(txtname.Text, txtsurname.Text, txtemail.Text, txtphone.Text);
                dataGridView1.DataSource = admin.Fill();
            }   
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (UId == null)
            {
                MessageBox.Show("Lütfen seçim yapınız.");
            }
            else
            {
                admin.Delete(UId);
                dataGridView1.DataSource = admin.Fill();
                btndelete.Enabled = false;
                btnupdate.Enabled = false;
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (UId == null)
            {
                MessageBox.Show("Lütfen seçim yapınız.");
            }
            else if (txtname.Text == String.Empty || txtsurname.Text == String.Empty || txtemail.Text == String.Empty || txtphone.Text == String.Empty)
            {
                txtname.Text = name;
                txtsurname.Text = surname;
                txtemail.Text = email;
                txtphone.Text = phone;
                MessageBox.Show("Lütfen düzeltmeleinizden sonra tekrar güncelle butonuna basınız.");
            }
            else
            {
                admin.Update(UId,txtname.Text, txtsurname.Text, txtemail.Text, txtphone.Text);
                txtname.Clear();
                txtsurname.Clear();
                txtemail.Clear();
                txtphone.Clear();
                dataGridView1.DataSource = admin.Fill();
                btnupdate.Enabled = false;
                btndelete.Enabled = false;
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtname.Clear();
            txtsurname.Clear();
            txtemail.Clear();
            txtphone.Clear();
        }
    }
}