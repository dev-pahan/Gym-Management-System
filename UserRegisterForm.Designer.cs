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
            this.RUsername = new System.Windows.Forms.TextBox();
            this.RPassword = new System.Windows.Forms.TextBox();
            this.RRole = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // SubmitBtn
            // 
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
            this.label1.Location = new System.Drawing.Point(116, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username";
            // 
            // PasswordTb
            // 
            this.PasswordTb.AutoSize = true;
            this.PasswordTb.Location = new System.Drawing.Point(118, 84);
            this.PasswordTb.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PasswordTb.Name = "PasswordTb";
            this.PasswordTb.Size = new System.Drawing.Size(53, 13);
            this.PasswordTb.TabIndex = 2;
            this.PasswordTb.Text = "Password";
            // 
            // RUsername
            // 
            this.RUsername.Location = new System.Drawing.Point(183, 49);
            this.RUsername.Margin = new System.Windows.Forms.Padding(2);
            this.RUsername.Name = "RUsername";
            this.RUsername.Size = new System.Drawing.Size(76, 20);
            this.RUsername.TabIndex = 3;
            // 
            // RPassword
            // 
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SubmitBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label PasswordTb;
        private System.Windows.Forms.TextBox RUsername;
        private System.Windows.Forms.TextBox RPassword;
        private System.Windows.Forms.ComboBox RRole;
    }
}