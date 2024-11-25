namespace OnderhoudsBoekje.Windows
{
    partial class AddMaintenanceEntry
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
            pictureBox1 = new PictureBox();
            label1 = new Label();
            dateTimePicker1 = new DateTimePicker();
            descriptionTxt = new TextBox();
            label2 = new Label();
            typeCombo = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            costTxt = new NumericUpDown();
            label6 = new Label();
            milageTxt = new TextBox();
            label7 = new Label();
            notesTxt = new TextBox();
            panel3 = new Panel();
            cancelBtn = new Button();
            createBtn = new Button();
            durationCombo = new DomainUpDown();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)costTxt).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pictureBox1.Image = Properties.Resources.create_entry_sidebar;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(160, 498);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(223, 59);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 1;
            label1.Text = "Datum:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(386, 53);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(278, 23);
            dateTimePicker1.TabIndex = 2;
            // 
            // descriptionTxt
            // 
            descriptionTxt.Location = new Point(386, 111);
            descriptionTxt.Name = "descriptionTxt";
            descriptionTxt.Size = new Size(278, 23);
            descriptionTxt.TabIndex = 3;
            descriptionTxt.TextChanged += descriptionTxt_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(223, 114);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 4;
            label2.Text = "Omschrijving:";
            // 
            // typeCombo
            // 
            typeCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            typeCombo.FormattingEnabled = true;
            typeCombo.Location = new Point(386, 82);
            typeCombo.Name = "typeCombo";
            typeCombo.Size = new Size(278, 23);
            typeCombo.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(223, 85);
            label3.Name = "label3";
            label3.Size = new Size(35, 15);
            label3.TabIndex = 6;
            label3.Text = "Type:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(223, 168);
            label4.Name = "label4";
            label4.Size = new Size(90, 15);
            label4.TabIndex = 8;
            label4.Text = "Kilometerstand:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(223, 196);
            label5.Name = "label5";
            label5.Size = new Size(78, 15);
            label5.TabIndex = 10;
            label5.Text = "Besteden tijd:";
            // 
            // costTxt
            // 
            costTxt.DecimalPlaces = 2;
            costTxt.Location = new Point(386, 223);
            costTxt.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            costTxt.Name = "costTxt";
            costTxt.Size = new Size(278, 23);
            costTxt.TabIndex = 11;
            costTxt.KeyPress += numericUpDown2_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(223, 225);
            label6.Name = "label6";
            label6.Size = new Size(46, 15);
            label6.TabIndex = 12;
            label6.Text = "Kosten:";
            // 
            // milageTxt
            // 
            milageTxt.Location = new Point(386, 165);
            milageTxt.Name = "milageTxt";
            milageTxt.Size = new Size(278, 23);
            milageTxt.TabIndex = 13;
            milageTxt.KeyPress += milageTxt_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(223, 258);
            label7.Name = "label7";
            label7.Size = new Size(83, 15);
            label7.TabIndex = 14;
            label7.Text = "Opmerkingen:";
            // 
            // notesTxt
            // 
            notesTxt.Location = new Point(386, 252);
            notesTxt.Multiline = true;
            notesTxt.Name = "notesTxt";
            notesTxt.Size = new Size(278, 176);
            notesTxt.TabIndex = 15;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(cancelBtn);
            panel3.Controls.Add(createBtn);
            panel3.Location = new Point(156, 455);
            panel3.Name = "panel3";
            panel3.Size = new Size(593, 44);
            panel3.TabIndex = 16;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(392, 10);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(89, 23);
            cancelBtn.TabIndex = 6;
            cancelBtn.Text = "Annuleren";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // createBtn
            // 
            createBtn.Enabled = false;
            createBtn.Location = new Point(487, 10);
            createBtn.Name = "createBtn";
            createBtn.Size = new Size(89, 23);
            createBtn.TabIndex = 5;
            createBtn.Text = "Registreren";
            createBtn.UseVisualStyleBackColor = true;
            createBtn.Click += createBtn_Click;
            // 
            // durationCombo
            // 
            durationCombo.BackColor = Color.White;
            durationCombo.Items.Add("00:00");
            durationCombo.Items.Add("00:10");
            durationCombo.Items.Add("00:20");
            durationCombo.Items.Add("00:30");
            durationCombo.Items.Add("00:40");
            durationCombo.Items.Add("00:50");
            durationCombo.Items.Add("01:00");
            durationCombo.Items.Add("01:10");
            durationCombo.Items.Add("01:20");
            durationCombo.Items.Add("01:30");
            durationCombo.Items.Add("01:40");
            durationCombo.Items.Add("01:50");
            durationCombo.Items.Add("02:00");
            durationCombo.Location = new Point(386, 194);
            durationCombo.Name = "durationCombo";
            durationCombo.ReadOnly = true;
            durationCombo.Size = new Size(278, 23);
            durationCombo.TabIndex = 9;
            durationCombo.Text = "00:00";
            // 
            // AddMaintenanceEntry
            // 
            AcceptButton = createBtn;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelBtn;
            ClientSize = new Size(745, 498);
            Controls.Add(pictureBox1);
            Controls.Add(panel3);
            Controls.Add(notesTxt);
            Controls.Add(label7);
            Controls.Add(milageTxt);
            Controls.Add(label6);
            Controls.Add(costTxt);
            Controls.Add(label5);
            Controls.Add(durationCombo);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(typeCombo);
            Controls.Add(label2);
            Controls.Add(descriptionTxt);
            Controls.Add(dateTimePicker1);
            Controls.Add(label1);
            MaximizeBox = false;
            Name = "AddMaintenanceEntry";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Nieuwe onderhoudsregistratie";
            Load += AddMaintenanceEntry_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)costTxt).EndInit();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private DateTimePicker dateTimePicker1;
        private TextBox descriptionTxt;
        private Label label2;
        private ComboBox typeCombo;
        private Label label3;
        private Label label4;
        private Label label5;
        private NumericUpDown costTxt;
        private Label label6;
        private TextBox milageTxt;
        private Label label7;
        private TextBox notesTxt;
        private Panel panel3;
        private Button createBtn;
        private Button cancelBtn;
        private DomainUpDown durationCombo;
    }
}