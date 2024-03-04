namespace directionPacientToEvent
{
    partial class formAuthorization
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblLogin = new Label();
            tbLogin = new TextBox();
            tbPassword = new TextBox();
            lblPassword = new Label();
            btnSignIn = new Button();
            SuspendLayout();
            // 
            // lblLogin
            // 
            lblLogin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lblLogin.Location = new Point(12, 9);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(117, 45);
            lblLogin.TabIndex = 0;
            lblLogin.Text = "Логин:";
            // 
            // tbLogin
            // 
            tbLogin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbLogin.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbLogin.Location = new Point(12, 68);
            tbLogin.Name = "tbLogin";
            tbLogin.Size = new Size(293, 45);
            tbLogin.TabIndex = 1;
            // 
            // tbPassword
            // 
            tbPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbPassword.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbPassword.Location = new Point(12, 186);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(293, 45);
            tbPassword.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lblPassword.Location = new Point(12, 127);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(137, 45);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Пароль:";
            // 
            // btnSignIn
            // 
            btnSignIn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSignIn.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnSignIn.Location = new Point(12, 237);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Size = new Size(293, 68);
            btnSignIn.TabIndex = 4;
            btnSignIn.Text = "Войти";
            btnSignIn.UseVisualStyleBackColor = true;
            btnSignIn.Click += btnSignInClick;
            // 
            // formAuthorization
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(317, 318);
            Controls.Add(btnSignIn);
            Controls.Add(tbPassword);
            Controls.Add(lblPassword);
            Controls.Add(tbLogin);
            Controls.Add(lblLogin);
            MinimumSize = new Size(339, 374);
            Name = "formAuthorization";
            Text = "Авторизация";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLogin;
        private TextBox tbLogin;
        private TextBox tbPassword;
        private Label lblPassword;
        private Button btnSignIn;
    }
}