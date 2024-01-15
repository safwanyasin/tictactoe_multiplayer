namespace client
{
    partial class Form1
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
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.logs = new System.Windows.Forms.RichTextBox();
            this.textBox_message = new System.Windows.Forms.TextBox();
            this.button_send = new System.Windows.Forms.Button();
            this.button_disconnect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.box9 = new System.Windows.Forms.Label();
            this.box8 = new System.Windows.Forms.Label();
            this.box7 = new System.Windows.Forms.Label();
            this.box6 = new System.Windows.Forms.Label();
            this.box5 = new System.Windows.Forms.Label();
            this.box4 = new System.Windows.Forms.Label();
            this.box3 = new System.Windows.Forms.Label();
            this.box2 = new System.Windows.Forms.Label();
            this.box1 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.winsx_label9 = new System.Windows.Forms.Label();
            this.winso_label10 = new System.Windows.Forms.Label();
            this.draw_label11 = new System.Windows.Forms.Label();
            this.rounds_label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(51, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(33, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port:";
            // 
            // textBox_ip
            // 
            this.textBox_ip.BackColor = System.Drawing.Color.Gray;
            this.textBox_ip.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox_ip.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ip.ForeColor = System.Drawing.Color.Black;
            this.textBox_ip.Location = new System.Drawing.Point(89, 97);
            this.textBox_ip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(116, 27);
            this.textBox_ip.TabIndex = 2;
            // 
            // textBox_port
            // 
            this.textBox_port.BackColor = System.Drawing.Color.Gray;
            this.textBox_port.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox_port.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_port.ForeColor = System.Drawing.Color.Black;
            this.textBox_port.Location = new System.Drawing.Point(89, 133);
            this.textBox_port.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(116, 27);
            this.textBox_port.TabIndex = 3;
            // 
            // button_connect
            // 
            this.button_connect.BackColor = System.Drawing.Color.Gray;
            this.button_connect.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button_connect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_connect.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_connect.ForeColor = System.Drawing.Color.Black;
            this.button_connect.Location = new System.Drawing.Point(12, 175);
            this.button_connect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(121, 27);
            this.button_connect.TabIndex = 4;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = false;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // logs
            // 
            this.logs.BackColor = System.Drawing.Color.Gray;
            this.logs.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.logs.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logs.ForeColor = System.Drawing.Color.Black;
            this.logs.Location = new System.Drawing.Point(621, 76);
            this.logs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logs.Name = "logs";
            this.logs.Size = new System.Drawing.Size(255, 320);
            this.logs.TabIndex = 5;
            this.logs.Text = "";
            // 
            // textBox_message
            // 
            this.textBox_message.BackColor = System.Drawing.Color.Gray;
            this.textBox_message.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox_message.Enabled = false;
            this.textBox_message.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_message.ForeColor = System.Drawing.Color.Black;
            this.textBox_message.Location = new System.Drawing.Point(86, 341);
            this.textBox_message.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_message.Name = "textBox_message";
            this.textBox_message.Size = new System.Drawing.Size(129, 27);
            this.textBox_message.TabIndex = 6;
            // 
            // button_send
            // 
            this.button_send.BackColor = System.Drawing.Color.Gray;
            this.button_send.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button_send.Enabled = false;
            this.button_send.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_send.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_send.ForeColor = System.Drawing.Color.Black;
            this.button_send.Location = new System.Drawing.Point(221, 341);
            this.button_send.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(87, 27);
            this.button_send.TabIndex = 8;
            this.button_send.Text = "Send";
            this.button_send.UseVisualStyleBackColor = false;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // button_disconnect
            // 
            this.button_disconnect.BackColor = System.Drawing.Color.Gray;
            this.button_disconnect.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button_disconnect.Enabled = false;
            this.button_disconnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_disconnect.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_disconnect.ForeColor = System.Drawing.Color.Black;
            this.button_disconnect.Location = new System.Drawing.Point(148, 175);
            this.button_disconnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_disconnect.Name = "button_disconnect";
            this.button_disconnect.Size = new System.Drawing.Size(122, 27);
            this.button_disconnect.TabIndex = 15;
            this.button_disconnect.Text = "Disconnect";
            this.button_disconnect.UseVisualStyleBackColor = false;
            this.button_disconnect.Click += new System.EventHandler(this.button_disconnect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(31, 341);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 22);
            this.label3.TabIndex = 7;
            this.label3.Text = "Turn:";
            // 
            // box9
            // 
            this.box9.AutoSize = true;
            this.box9.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.box9.Font = new System.Drawing.Font("Showcard Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box9.ForeColor = System.Drawing.Color.White;
            this.box9.Location = new System.Drawing.Point(452, 256);
            this.box9.Name = "box9";
            this.box9.Size = new System.Drawing.Size(27, 29);
            this.box9.TabIndex = 33;
            this.box9.Text = "9";
            // 
            // box8
            // 
            this.box8.AutoSize = true;
            this.box8.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.box8.Font = new System.Drawing.Font("Showcard Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box8.ForeColor = System.Drawing.Color.White;
            this.box8.Location = new System.Drawing.Point(397, 256);
            this.box8.Name = "box8";
            this.box8.Size = new System.Drawing.Size(27, 29);
            this.box8.TabIndex = 32;
            this.box8.Text = "8";
            // 
            // box7
            // 
            this.box7.AutoSize = true;
            this.box7.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.box7.Font = new System.Drawing.Font("Showcard Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box7.ForeColor = System.Drawing.Color.White;
            this.box7.Location = new System.Drawing.Point(343, 256);
            this.box7.Name = "box7";
            this.box7.Size = new System.Drawing.Size(26, 29);
            this.box7.TabIndex = 31;
            this.box7.Text = "7";
            // 
            // box6
            // 
            this.box6.AutoSize = true;
            this.box6.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.box6.Font = new System.Drawing.Font("Showcard Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box6.ForeColor = System.Drawing.Color.White;
            this.box6.Location = new System.Drawing.Point(453, 213);
            this.box6.Name = "box6";
            this.box6.Size = new System.Drawing.Size(26, 29);
            this.box6.TabIndex = 30;
            this.box6.Text = "6";
            // 
            // box5
            // 
            this.box5.AutoSize = true;
            this.box5.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.box5.Font = new System.Drawing.Font("Showcard Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box5.ForeColor = System.Drawing.Color.White;
            this.box5.Location = new System.Drawing.Point(399, 213);
            this.box5.Name = "box5";
            this.box5.Size = new System.Drawing.Size(26, 29);
            this.box5.TabIndex = 29;
            this.box5.Text = "5";
            // 
            // box4
            // 
            this.box4.AutoSize = true;
            this.box4.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.box4.Font = new System.Drawing.Font("Showcard Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box4.ForeColor = System.Drawing.Color.White;
            this.box4.Location = new System.Drawing.Point(342, 213);
            this.box4.Name = "box4";
            this.box4.Size = new System.Drawing.Size(27, 29);
            this.box4.TabIndex = 28;
            this.box4.Text = "4";
            // 
            // box3
            // 
            this.box3.AutoSize = true;
            this.box3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.box3.Font = new System.Drawing.Font("Showcard Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box3.ForeColor = System.Drawing.Color.White;
            this.box3.Location = new System.Drawing.Point(454, 169);
            this.box3.Name = "box3";
            this.box3.Size = new System.Drawing.Size(25, 29);
            this.box3.TabIndex = 27;
            this.box3.Text = "3";
            // 
            // box2
            // 
            this.box2.AutoSize = true;
            this.box2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.box2.Font = new System.Drawing.Font("Showcard Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box2.ForeColor = System.Drawing.Color.White;
            this.box2.Location = new System.Drawing.Point(399, 169);
            this.box2.Name = "box2";
            this.box2.Size = new System.Drawing.Size(25, 29);
            this.box2.TabIndex = 26;
            this.box2.Text = "2";
            // 
            // box1
            // 
            this.box1.AutoSize = true;
            this.box1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.box1.Font = new System.Drawing.Font("Showcard Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box1.ForeColor = System.Drawing.Color.White;
            this.box1.Location = new System.Drawing.Point(345, 169);
            this.box1.Name = "box1";
            this.box1.Size = new System.Drawing.Size(24, 29);
            this.box1.TabIndex = 25;
            this.box1.Text = "1";
            // 
            // textBox_name
            // 
            this.textBox_name.BackColor = System.Drawing.Color.Gray;
            this.textBox_name.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox_name.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_name.ForeColor = System.Drawing.Color.Black;
            this.textBox_name.Location = new System.Drawing.Point(89, 63);
            this.textBox_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(116, 27);
            this.textBox_name.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(20, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.TabIndex = 35;
            this.label4.Text = "Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(259, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 26);
            this.label5.TabIndex = 36;
            this.label5.Text = "wins(X)";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(347, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 26);
            this.label6.TabIndex = 37;
            this.label6.Text = "wins(O)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label7.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(437, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 26);
            this.label7.TabIndex = 38;
            this.label7.Text = "Draw";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label8.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(515, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 26);
            this.label8.TabIndex = 39;
            this.label8.Text = "Rounds";
            // 
            // winsx_label9
            // 
            this.winsx_label9.AutoSize = true;
            this.winsx_label9.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.winsx_label9.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winsx_label9.ForeColor = System.Drawing.Color.Blue;
            this.winsx_label9.Location = new System.Drawing.Point(284, 35);
            this.winsx_label9.Name = "winsx_label9";
            this.winsx_label9.Size = new System.Drawing.Size(34, 39);
            this.winsx_label9.TabIndex = 40;
            this.winsx_label9.Text = "0";
            // 
            // winso_label10
            // 
            this.winso_label10.AutoSize = true;
            this.winso_label10.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.winso_label10.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winso_label10.ForeColor = System.Drawing.Color.Blue;
            this.winso_label10.Location = new System.Drawing.Point(370, 35);
            this.winso_label10.Name = "winso_label10";
            this.winso_label10.Size = new System.Drawing.Size(34, 39);
            this.winso_label10.TabIndex = 41;
            this.winso_label10.Text = "0";
            // 
            // draw_label11
            // 
            this.draw_label11.AutoSize = true;
            this.draw_label11.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.draw_label11.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.draw_label11.ForeColor = System.Drawing.Color.Blue;
            this.draw_label11.Location = new System.Drawing.Point(451, 35);
            this.draw_label11.Name = "draw_label11";
            this.draw_label11.Size = new System.Drawing.Size(34, 39);
            this.draw_label11.TabIndex = 42;
            this.draw_label11.Text = "0";
            this.draw_label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // rounds_label12
            // 
            this.rounds_label12.AutoSize = true;
            this.rounds_label12.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.rounds_label12.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rounds_label12.ForeColor = System.Drawing.Color.Blue;
            this.rounds_label12.Location = new System.Drawing.Point(536, 35);
            this.rounds_label12.Name = "rounds_label12";
            this.rounds_label12.Size = new System.Drawing.Size(34, 39);
            this.rounds_label12.TabIndex = 43;
            this.rounds_label12.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(992, 441);
            this.Controls.Add(this.rounds_label12);
            this.Controls.Add(this.draw_label11);
            this.Controls.Add(this.winso_label10);
            this.Controls.Add(this.winsx_label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.box9);
            this.Controls.Add(this.box8);
            this.Controls.Add(this.box7);
            this.Controls.Add(this.box6);
            this.Controls.Add(this.box5);
            this.Controls.Add(this.box4);
            this.Controls.Add(this.box3);
            this.Controls.Add(this.box2);
            this.Controls.Add(this.box1);
            this.Controls.Add(this.button_disconnect);
            this.Controls.Add(this.button_send);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_message);
            this.Controls.Add(this.logs);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.textBox_ip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.RichTextBox logs;
        private System.Windows.Forms.TextBox textBox_message;
        private System.Windows.Forms.Button button_send;
		private System.Windows.Forms.Button button_disconnect;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label box9;
		private System.Windows.Forms.Label box8;
		private System.Windows.Forms.Label box7;
		private System.Windows.Forms.Label box6;
		private System.Windows.Forms.Label box5;
		private System.Windows.Forms.Label box4;
		private System.Windows.Forms.Label box3;
		private System.Windows.Forms.Label box2;
		private System.Windows.Forms.Label box1;
		private System.Windows.Forms.TextBox textBox_name;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label winsx_label9;
        private System.Windows.Forms.Label winso_label10;
        private System.Windows.Forms.Label draw_label11;
        private System.Windows.Forms.Label rounds_label12;
    }
}

