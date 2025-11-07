namespace MMOGUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>//
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            Members = new ListBox();
            btnSendEmail = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Onyx", 48F, FontStyle.Italic);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(169, 23);
            label1.Name = "label1";
            label1.Size = new Size(565, 72);
            label1.TabIndex = 0;
            label1.Text = "MILLIONAIRE MINDS ORGANIZATION";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Bodoni MT", 11.25F);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(14, 133);
            label2.Name = "label2";
            label2.Size = new Size(117, 18);
            label2.TabIndex = 1;
            label2.Text = "ENTER NAME :";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.InfoText;
            textBox1.ForeColor = SystemColors.ButtonHighlight;
            textBox1.Location = new Point(137, 131);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(186, 23);
            textBox1.TabIndex = 2;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaptionText;
            button1.FlatStyle = FlatStyle.Popup;
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(14, 171);
            button1.Name = "button1";
            button1.Size = new Size(137, 44);
            button1.TabIndex = 3;
            button1.Text = "REGISTER";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaptionText;
            button2.FlatStyle = FlatStyle.Popup;
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(14, 248);
            button2.Name = "button2";
            button2.Size = new Size(137, 44);
            button2.TabIndex = 4;
            button2.Text = "VIEW LIST";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ActiveCaptionText;
            button3.FlatStyle = FlatStyle.Popup;
            button3.ForeColor = SystemColors.ButtonHighlight;
            button3.Location = new Point(14, 323);
            button3.Name = "button3";
            button3.Size = new Size(137, 44);
            button3.TabIndex = 5;
            button3.Text = "SEARCH GUEST";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.ActiveCaptionText;
            button4.FlatStyle = FlatStyle.Popup;
            button4.ForeColor = SystemColors.ButtonHighlight;
            button4.Location = new Point(14, 399);
            button4.Name = "button4";
            button4.Size = new Size(137, 44);
            button4.TabIndex = 6;
            button4.Text = "EXIT GUEST";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // Members
            // 
            Members.BackColor = SystemColors.MenuText;
            Members.ForeColor = SystemColors.ButtonHighlight;
            Members.FormattingEnabled = true;
            Members.HorizontalScrollbar = true;
            Members.ItemHeight = 17;
            Members.Location = new Point(628, 146);
            Members.Name = "Members";
            Members.Size = new Size(245, 310);
            Members.TabIndex = 7;
            // 
            // btnSendEmail
            // 
            btnSendEmail.BackColor = SystemColors.ActiveCaptionText;
            btnSendEmail.FlatStyle = FlatStyle.Popup;
            btnSendEmail.ForeColor = SystemColors.ButtonHighlight;
            btnSendEmail.Location = new Point(14, 470);
            btnSendEmail.Name = "btnSendEmail";
            btnSendEmail.Size = new Size(137, 44);
            btnSendEmail.TabIndex = 8;
            btnSendEmail.Text = "SEND EMAIL";
            btnSendEmail.UseVisualStyleBackColor = false;
            btnSendEmail.Click += btnSendEmail_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(914, 540);
            Controls.Add(btnSendEmail);
            Controls.Add(Members);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            DoubleBuffered = true;
            Font = new Font("Bodoni MT", 9.75F);
            ForeColor = SystemColors.ButtonHighlight;
            Name = "Form1";
            Text = "Millionaire Organization Event";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListBox Members;
        private System.Windows.Forms.Button btnSendEmail;
    }
}
