namespace Funbit.Ets.Telemetry.Server
{
    partial class DBConfig
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.text_server = new System.Windows.Forms.TextBox();
            this.text_name = new System.Windows.Forms.TextBox();
            this.text_port = new System.Windows.Forms.TextBox();
            this.text_user = new System.Windows.Forms.TextBox();
            this.text_password = new System.Windows.Forms.TextBox();
            this.check_db_type = new System.Windows.Forms.RadioButton();
            this.btn_save = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "DB";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "User";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Password";
            // 
            // text_server
            // 
            this.text_server.Location = new System.Drawing.Point(110, 62);
            this.text_server.Name = "text_server";
            this.text_server.Size = new System.Drawing.Size(100, 20);
            this.text_server.TabIndex = 5;
            // 
            // text_name
            // 
            this.text_name.Location = new System.Drawing.Point(110, 88);
            this.text_name.Name = "text_name";
            this.text_name.Size = new System.Drawing.Size(100, 20);
            this.text_name.TabIndex = 6;
            // 
            // text_port
            // 
            this.text_port.Location = new System.Drawing.Point(110, 114);
            this.text_port.Name = "text_port";
            this.text_port.Size = new System.Drawing.Size(100, 20);
            this.text_port.TabIndex = 7;
            // 
            // text_user
            // 
            this.text_user.Location = new System.Drawing.Point(110, 140);
            this.text_user.Name = "text_user";
            this.text_user.Size = new System.Drawing.Size(100, 20);
            this.text_user.TabIndex = 8;
            // 
            // text_password
            // 
            this.text_password.Location = new System.Drawing.Point(110, 166);
            this.text_password.Name = "text_password";
            this.text_password.Size = new System.Drawing.Size(100, 20);
            this.text_password.TabIndex = 9;
            // 
            // check_db_type
            // 
            this.check_db_type.AutoSize = true;
            this.check_db_type.Checked = true;
            this.check_db_type.Location = new System.Drawing.Point(110, 29);
            this.check_db_type.Name = "check_db_type";
            this.check_db_type.Size = new System.Drawing.Size(54, 17);
            this.check_db_type.TabIndex = 10;
            this.check_db_type.TabStop = true;
            this.check_db_type.Text = "MySql";
            this.check_db_type.UseVisualStyleBackColor = true;
            this.check_db_type.CheckedChanged += new System.EventHandler(this.check_db_type_CheckedChanged);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(110, 192);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 11;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(213, 230);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Reconnect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DBConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 265);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.check_db_type);
            this.Controls.Add(this.text_password);
            this.Controls.Add(this.text_user);
            this.Controls.Add(this.text_port);
            this.Controls.Add(this.text_name);
            this.Controls.Add(this.text_server);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Name = "DBConfig";
            this.Text = "DB Config";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox text_server;
        private System.Windows.Forms.TextBox text_name;
        private System.Windows.Forms.TextBox text_port;
        private System.Windows.Forms.TextBox text_user;
        private System.Windows.Forms.TextBox text_password;
        private System.Windows.Forms.RadioButton check_db_type;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button button1;
    }
}