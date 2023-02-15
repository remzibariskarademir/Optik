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
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }
        User user = new User();
        private void UserForm_Load(object sender, EventArgs e)
        {
            btnback.Text = "Geri";
            btnexit.Text = "Çıkış";
            btnexportexcel.Text = "Excele Çıkart";
            btnexporttxt.Text = "Txteye Çıkart";
            btnfile.Text = "Dosya Seç";
            btnconfirm.Text = "Onay";

            lbldepartment.Text = "Bölüm :";
            lbllessname.Text = "Ders Adı :";
            lblextype.Text = "Sınav Türü :";
            lbllesstype.Text = "Kitapçık Türü :";
            lblqnumber.Text = "Soru Sayısı :";
            lblA.Text = "A Cevap anahtarı :";
            lblB.Text = "B Cevap anahtarı :";
            lblC.Text = "C Cevap anahtarı :";
            lblD.Text = "D Cevap anahtarı :";

            cmblesstype.DataSource = user.Fill();
            cmblesstype.DisplayMember = "bookletname";
            cmblesstype.ValueMember = "bookletname";

            cmbextype.DataSource = user.Fillex();
            cmbextype.DisplayMember = "exType";
            cmbextype.ValueMember = "exType";

            cmbdepartment.DataSource = user.Filldep();
            cmbdepartment.DisplayMember = "depname";
            cmbdepartment.ValueMember = "depname";

            lblB.Hide();
            lblC.Hide();
            lblD.Hide();

            txtB.Hide();
            txtC.Hide();
            txtD.Hide();

            txtA.Enabled = false;
            cmblesstype.Enabled = false;

            btnfile.Enabled = false;
            btnexportexcel.Enabled = false;
            btnexporttxt.Enabled = false;
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void cmblesstype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmblesstype.SelectedIndex == 1)
            {
                lblB.Show();
                txtB.Show();
                lblC.Hide();
                txtC.Hide();
                lblD.Hide();
                txtD.Hide();

            }
            else if (cmblesstype.SelectedIndex == 2)
            {
                lblB.Show();
                txtB.Show();
                lblC.Show();
                txtC.Show();
                lblD.Hide();
                txtD.Hide();
            }
            else if (cmblesstype.SelectedIndex == 3)
            {
                lblB.Show();
                txtB.Show();
                lblC.Show();
                txtC.Show();
                lblD.Show();
                txtD.Show();
            }
            else
            {
                lblB.Hide();
                txtB.Hide();
                lblC.Hide();
                txtC.Hide();
                lblD.Hide();
                txtD.Hide();
            }
        }

        private void btnfile_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = user.Read();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = true;
            btnexportexcel.Enabled = true;
            btnexporttxt.Enabled = true;
            btnfile.Enabled = false;

        }

        private void btnconfirm_Click(object sender, EventArgs e)
        {
            if (txtlessname.Text == String.Empty || txtqnumber.Text == String.Empty)
            {
                MessageBox.Show("Lütfen ders adı ve soru sayısını giriniz.");
            }
            else
            {
                txtA.MaxLength = Convert.ToInt32(txtqnumber.Text);
                cmblesstype.Enabled = true;
                txtA.Enabled = true;
                btnfile.Enabled = true;
                cmbdepartment.Enabled = false;
                txtqnumber.Enabled = false;
                txtlessname.Enabled = false;
                cmbextype.Enabled = false;
                btnconfirm.Enabled = false;
            }
        }

        private void txtA_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void btnexporttxt_Click(object sender, EventArgs e)
        {
            if (txtA.Enabled == true)
            {
                if (txtA.Text == String.Empty)
                {
                    MessageBox.Show("Cevap Anahtarı Giriniz");
                }
                else
                {
                    user.Hesapla(cmbdepartment.Text, cmbextype.Text, txtlessname.Text.ToUpper(), Convert.ToInt32(txtqnumber.Text), txtA.Text.ToUpper(), txtB.Text.ToUpper(), txtC.Text.ToUpper(), txtD.Text.ToUpper());
                    cmbdepartment.Enabled = true;
                    cmbextype.Enabled = true;
                    txtlessname.Enabled = true;
                    txtqnumber.Enabled = true;
                    btnconfirm.Enabled = true;
                    cmblesstype.Enabled = false;
                }
            }
            else if (txtA.Enabled == true || txtB.Enabled == true)
            {
                if (txtA.Text == String.Empty || txtB.Text == String.Empty)
                {
                    MessageBox.Show("Cevap Anahtarı Giriniz");
                }
                else
                {
                    user.Hesapla(cmbdepartment.Text, cmbextype.Text, txtlessname.Text.ToUpper(), Convert.ToInt32(txtqnumber.Text), txtA.Text.ToUpper(), txtB.Text.ToUpper(), txtC.Text.ToUpper(), txtD.Text.ToUpper());
                    cmbdepartment.Enabled = true;
                    cmbextype.Enabled = true;
                    txtlessname.Enabled = true;
                    txtqnumber.Enabled = true;
                    btnconfirm.Enabled = true;
                    cmblesstype.Enabled = false;
                }
            }
            else if (txtA.Enabled == true || txtB.Enabled == true || txtC.Enabled == true)
            {
                if (txtA.Text == String.Empty || txtB.Text == String.Empty || txtC.Text == String.Empty)
                {
                    MessageBox.Show("Cevap Anahtarı Giriniz");
                }
                else
                {
                    user.Hesapla(cmbdepartment.Text, cmbextype.Text, txtlessname.Text.ToUpper(), Convert.ToInt32(txtqnumber.Text), txtA.Text.ToUpper(), txtB.Text.ToUpper(), txtC.Text.ToUpper(), txtD.Text.ToUpper());
                    cmbdepartment.Enabled = true;
                    cmbextype.Enabled = true;
                    txtlessname.Enabled = true;
                    txtqnumber.Enabled = true;
                    btnconfirm.Enabled = true;
                    cmblesstype.Enabled = false;
                }
            }
            else if (txtA.Enabled == true || txtB.Enabled == true || txtC.Enabled == true || txtD.Enabled == true)
            {
                if (txtA.Text == String.Empty || txtB.Text == String.Empty || txtC.Text == String.Empty || txtD.Text == String.Empty)
                {
                    MessageBox.Show("Cevap Anahtarı Giriniz");
                }
                else
                {
                    user.Hesapla(cmbdepartment.Text, cmbextype.Text, txtlessname.Text.ToUpper(), Convert.ToInt32(txtqnumber.Text), txtA.Text.ToUpper(), txtB.Text.ToUpper(), txtC.Text.ToUpper(), txtD.Text.ToUpper());
                    cmbdepartment.Enabled = true;
                    cmbextype.Enabled = true;
                    txtlessname.Enabled = true;
                    txtqnumber.Enabled = true;
                    btnconfirm.Enabled = true;
                    cmblesstype.Enabled = false;
                }
            }
        }

        private void btnexportexcel_Click(object sender, EventArgs e)
        {
            if (txtA.Enabled == true)
            {
                if (txtA.Text == String.Empty)
                {
                    MessageBox.Show("Cevap Anahtarı Giriniz");
                }
                else
                {
                    user.Hesaplae(cmbdepartment.Text, cmbextype.Text, txtlessname.Text.ToUpper(), Convert.ToInt32(txtqnumber.Text), txtA.Text.ToUpper(), txtB.Text.ToUpper(), txtC.Text.ToUpper(), txtD.Text.ToUpper());
                    cmbdepartment.Enabled = true;
                    cmbextype.Enabled = true;
                    txtlessname.Enabled = true;
                    txtqnumber.Enabled = true;
                    btnconfirm.Enabled = true;
                    cmblesstype.Enabled = false;
                }
            }
            else if (txtA.Enabled == true || txtB.Enabled == true)
            {
                if (txtA.Text == String.Empty || txtB.Text == String.Empty)
                {
                    MessageBox.Show("Cevap Anahtarı Giriniz");
                }
                else
                {
                    user.Hesaplae(cmbdepartment.Text, cmbextype.Text, txtlessname.Text.ToUpper(), Convert.ToInt32(txtqnumber.Text), txtA.Text.ToUpper(), txtB.Text.ToUpper(), txtC.Text.ToUpper(), txtD.Text.ToUpper());
                    cmbdepartment.Enabled = true;
                    cmbextype.Enabled = true;
                    txtlessname.Enabled = true;
                    txtqnumber.Enabled = true;
                    btnconfirm.Enabled = true;
                    cmblesstype.Enabled = false;
                }
            }
            else if (txtA.Enabled == true || txtB.Enabled == true || txtC.Enabled == true)
            {
                if (txtA.Text == String.Empty || txtB.Text == String.Empty || txtC.Text == String.Empty)
                {
                    MessageBox.Show("Cevap Anahtarı Giriniz");
                }
                else
                {
                    user.Hesaplae(cmbdepartment.Text, cmbextype.Text, txtlessname.Text.ToUpper(), Convert.ToInt32(txtqnumber.Text), txtA.Text.ToUpper(), txtB.Text.ToUpper(), txtC.Text.ToUpper(), txtD.Text.ToUpper());
                    cmbdepartment.Enabled = true;
                    cmbextype.Enabled = true;
                    txtlessname.Enabled = true;
                    txtqnumber.Enabled = true;
                    btnconfirm.Enabled = true;
                    cmblesstype.Enabled = false;
                }
            }
            else if (txtA.Enabled == true || txtB.Enabled == true || txtC.Enabled == true || txtD.Enabled == true)
            {
                if (txtA.Text == String.Empty || txtB.Text == String.Empty || txtC.Text == String.Empty || txtD.Text == String.Empty)
                {
                    MessageBox.Show("Cevap Anahtarı Giriniz");
                }
                else
                {
                    user.Hesaplae(cmbdepartment.Text, cmbextype.Text, txtlessname.Text.ToUpper(), Convert.ToInt32(txtqnumber.Text), txtA.Text.ToUpper(), txtB.Text.ToUpper(), txtC.Text.ToUpper(), txtD.Text.ToUpper());
                    cmbdepartment.Enabled = true;
                    cmbextype.Enabled = true;
                    txtlessname.Enabled = true;
                    txtqnumber.Enabled = true;
                    btnconfirm.Enabled = true;
                    cmblesstype.Enabled = false;
                }
            }
        }
    }
}