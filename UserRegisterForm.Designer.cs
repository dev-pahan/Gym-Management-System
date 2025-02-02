namespace GymManagementSystem
{
    partial class UserRegisterForm
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
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PasswordTb = new System.Windows.Forms.Label();

            this.UsernameTb = new System.Windows.Forms.TextBox();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();

            this.RUsername = new System.Windows.Forms.TextBox();
            this.RPassword = new System.Windows.Forms.TextBox();
            this.RRole = new System.Windows.Forms.ComboBox();

            this.SuspendLayout();
            // 
            // SubmitBtn
            // 

            this.SubmitBtn.BackColor = System.Drawing.Color.Teal;
            this.SubmitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SubmitBtn.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.SubmitBtn.ForeColor = System.Drawing.Color.White;
            this.SubmitBtn.Location = new System.Drawing.Point(358, 480);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(270, 44);
            this.SubmitBtn.TabIndex = 3;
            this.SubmitBtn.Text = "Register";
            this.SubmitBtn.UseVisualStyleBackColor = false;

            this.SubmitBtn.Location = new System.Drawing.Point(203, 195);
            this.SubmitBtn.Margin = new System.Windows.Forms.Padding(2);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(56, 19);
            this.SubmitBtn.TabIndex = 0;
            this.SubmitBtn.Text = "Submit";
            this.SubmitBtn.UseVisualStyleBackColor = true;

            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;

            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(353, 321);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 30);

            this.label1.Location = new System.Drawing.Point(116, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);

            this.label1.TabIndex = 1;
            this.label1.Text = "Username";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // PasswordTb
            // 
            this.PasswordTb.AutoSize = true;

            this.PasswordTb.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.PasswordTb.ForeColor = System.Drawing.Color.Teal;
            this.PasswordTb.Location = new System.Drawing.Point(353, 394);
            this.PasswordTb.Name = "PasswordTb";
            this.PasswordTb.Size = new System.Drawing.Size(122, 30);
            this.PasswordTb.TabIndex = 1;

            this.PasswordTb.Location = new System.Drawing.Point(118, 84);
            this.PasswordTb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PasswordTb.Name = "PasswordTb";
            this.PasswordTb.Size = new System.Drawing.Size(53, 13);
            this.PasswordTb.TabIndex = 2;

            this.PasswordTb.Text = "Password";
            this.PasswordTb.Click += new System.EventHandler(this.PasswordTb_Click);
            // 
            // RUsername
            // 
            this.UsernameTb.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.UsernameTb.Location = new System.Drawing.Point(358, 345);
            this.UsernameTb.Name = "UsernameTb";
            this.UsernameTb.Size = new System.Drawing.Size(270, 37);
            this.UsernameTb.TabIndex = 2;

            this.RUsername.Location = new System.Drawing.Point(183, 49);
            this.RUsername.Margin = new System.Windows.Forms.Padding(2);
            this.RUsername.Name = "RUsername";
            this.RUsername.Size = new System.Drawing.Size(76, 20);
            this.RUsername.TabIndex = 3;
            // 
            // RPassword
            // 

            this.TxtPassword.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.TxtPassword.Location = new System.Drawing.Point(358, 418);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(270, 37);
            this.TxtPassword.TabIndex = 2;
            this.TxtPassword.TextChanged += new System.EventHandler(this.TxtPassword_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 56);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GymManagementSystem.Properties.Resources.Dumbbellwhite;
            this.pictureBox1.Location = new System.Drawing.Point(12, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Image = global::GymManagementSystem.Properties.Resources.Dumbbell;
            this.pictureBox2.Location = new System.Drawing.Point(437, 121);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 100);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(265, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(471, 72);
            this.label2.TabIndex = 1;
            this.label2.Text = "                   Welcome\r\n Your Fitness Journey Starts Here.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(63, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(323, 28);
            this.label3.TabIndex = 1;
            this.label3.Text = "Gym Management System";
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(950, 650);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.UsernameTb);
            this.Controls.Add(this.PasswordTb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SubmitBtn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            this.RPassword.Location = new System.Drawing.Point(183, 81);
            this.RPassword.Margin = new System.Windows.Forms.Padding(2);
            this.RPassword.Name = "RPassword";
            this.RPassword.Size = new System.Drawing.Size(76, 20);
            this.RPassword.TabIndex = 4;
            // 
            // RRole
            // 
            this.RRole.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RRole.FormattingEnabled = true;
            this.RRole.Items.AddRange(new object[] {
            "Admin",
            "Trainer"});
            this.RRole.Location = new System.Drawing.Point(153, 118);
            this.RRole.Name = "RRole";
            this.RRole.Size = new System.Drawing.Size(121, 31);
            this.RRole.TabIndex = 46;
            // 
            // UserRegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.RRole);
            this.Controls.Add(this.RPassword);
            this.Controls.Add(this.RUsername);
            this.Controls.Add(this.PasswordTb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SubmitBtn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UserRegisterForm";

            this.Text = "RegisterForm";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SubmitBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label PasswordTb;

        private System.Windows.Forms.TextBox UsernameTb;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox RUsername;
        private System.Windows.Forms.TextBox RPassword;
        private System.Windows.Forms.ComboBox RRole;

    }
}