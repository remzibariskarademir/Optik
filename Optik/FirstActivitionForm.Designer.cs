namespace Optik
{
    partial class FirstActivitionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnback = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.lblemail = new System.Windows.Forms.Label();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.lblpassword = new System.Windows.Forms.Label();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.lblquestion = new System.Windows.Forms.Label();
            this.cmbquestion = new System.Windows.Forms.ComboBox();
            this.lblanswer = new System.Windows.Forms.Label();
            this.txtanswer = new System.Windows.Forms.TextBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnback
            // 
            this.btnback.Location = new System.Drawing.Point(12, 12);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(75, 23);
            this.btnback.TabIndex = 0;
            this.btnback.Text = "button1";
            this.btnback.UseVisualStyleBackColor = true;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // btnexit
            // 
            this.btnexit.Location = new System.Drawing.Point(425, 345);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(75, 23);
            this.btnexit.TabIndex = 1;
            this.btnexit.Text = "button1";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // lblemail
            // 
            this.lblemail.AutoSize = true;
            this.lblemail.Location = new System.Drawing.Point(101, 74);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(35, 13);
            this.lblemail.TabIndex = 2;
            this.lblemail.Text = "label1";
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(181, 71);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(220, 20);
            this.txtemail.TabIndex = 3;
            // 
            // lblpassword
            // 
            this.lblpassword.AutoSize = true;
            this.lblpassword.Location = new System.Drawing.Point(101, 126);
            this.lblpassword.Name = "lblpassword";
            this.lblpassword.Size = new System.Drawing.Size(35, 13);
            this.lblpassword.TabIndex = 4;
            this.lblpassword.Text = "label1";
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(181, 123);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(220, 20);
            this.txtpassword.TabIndex = 5;
            // 
            // lblquestion
            // 
            this.lblquestion.AutoSize = true;
            this.lblquestion.Location = new System.Drawing.Point(101, 169);
            this.lblquestion.Name = "lblquestion";
            this.lblquestion.Size = new System.Drawing.Size(35, 13);
            this.lblquestion.TabIndex = 6;
            this.lblquestion.Text = "label1";
            // 
            // cmbquestion
            // 
            this.cmbquestion.FormattingEnabled = true;
            this.cmbquestion.Location = new System.Drawing.Point(181, 166);
            this.cmbquestion.Name = "cmbquestion";
            this.cmbquestion.Size = new System.Drawing.Size(220, 21);
            this.cmbquestion.TabIndex = 7;
            // 
            // lblanswer
            // 
            this.lblanswer.AutoSize = true;
            this.lblanswer.Location = new System.Drawing.Point(101, 220);
            this.lblanswer.Name = "lblanswer";
            this.lblanswer.Size = new System.Drawing.Size(35, 13);
            this.lblanswer.TabIndex = 8;
            this.lblanswer.Text = "label1";
            // 
            // txtanswer
            // 
            this.txtanswer.Location = new System.Drawing.Point(181, 217);
            this.txtanswer.Name = "txtanswer";
            this.txtanswer.Size = new System.Drawing.Size(220, 20);
            this.txtanswer.TabIndex = 9;
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(326, 276);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 10;
            this.btnsave.Text = "button1";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // FirstActivitionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 380);
            this.ControlBox = false;
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.txtanswer);
            this.Controls.Add(this.lblanswer);
            this.Controls.Add(this.cmbquestion);
            this.Controls.Add(this.lblquestion);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.lblpassword);
            this.Controls.Add(this.txtemail);
            this.Controls.Add(this.lblemail);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btnback);
            this.Name = "FirstActivitionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İlk Giriş Paneli";
            this.Load += new System.EventHandler(this.FirstActivitionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Label lblemail;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.Label lblpassword;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Label lblquestion;
        private System.Windows.Forms.ComboBox cmbquestion;
        private System.Windows.Forms.Label lblanswer;
        private System.Windows.Forms.TextBox txtanswer;
        private System.Windows.Forms.Button btnsave;
    }
}