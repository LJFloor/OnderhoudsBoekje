namespace OnderhoudsBoekje.CreateWizzard
{
    partial class CreateOnderhoudsboekjeWizzard
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
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            licensePlateTextbox1 = new Controls.LicensePlateTextbox();
            label3 = new Label();
            panel2 = new Panel();
            label12 = new Label();
            milageTxt = new TextBox();
            label11 = new Label();
            buildYearNr = new NumericUpDown();
            label10 = new Label();
            cylinderCountNr = new NumericUpDown();
            label9 = new Label();
            fuelCombo = new ComboBox();
            label6 = new Label();
            ccTxt = new TextBox();
            vinLocationTxt = new Label();
            label8 = new Label();
            vinTxt = new TextBox();
            label7 = new Label();
            colorTxt = new TextBox();
            modelTxt = new TextBox();
            brandTxt = new TextBox();
            label5 = new Label();
            label4 = new Label();
            panel3 = new Panel();
            createBtn = new Button();
            selectLocationBtn = new Button();
            locationTxt = new TextBox();
            saveFileDialog1 = new SaveFileDialog();
            label13 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)buildYearNr).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cylinderCountNr).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-1, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(543, 68);
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 33);
            label2.Name = "label2";
            label2.Size = new Size(290, 15);
            label2.TabIndex = 1;
            label2.Text = "Gemakkelijk al het onderhoud van uw auto bijhouden";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(239, 20);
            label1.TabIndex = 0;
            label1.Text = "Nieuw onderhoudsboekje maken";
            // 
            // licensePlateTextbox1
            // 
            licensePlateTextbox1.Location = new Point(257, 97);
            licensePlateTextbox1.Name = "licensePlateTextbox1";
            licensePlateTextbox1.Size = new Size(222, 23);
            licensePlateTextbox1.TabIndex = 1;
            licensePlateTextbox1.Leave += licensePlateTextbox1_Leave;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 100);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 2;
            label3.Text = "Kenteken:";
            // 
            // panel2
            // 
            panel2.Controls.Add(label12);
            panel2.Controls.Add(milageTxt);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(buildYearNr);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(cylinderCountNr);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(fuelCombo);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(ccTxt);
            panel2.Controls.Add(vinLocationTxt);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(vinTxt);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(colorTxt);
            panel2.Controls.Add(modelTxt);
            panel2.Controls.Add(brandTxt);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(40, 140);
            panel2.Name = "panel2";
            panel2.Size = new Size(439, 282);
            panel2.TabIndex = 3;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(0, 213);
            label12.Name = "label12";
            label12.Size = new Size(90, 15);
            label12.TabIndex = 20;
            label12.Text = "Kilometerstand:";
            // 
            // milageTxt
            // 
            milageTxt.Location = new Point(217, 210);
            milageTxt.Name = "milageTxt";
            milageTxt.Size = new Size(222, 23);
            milageTxt.TabIndex = 19;
            milageTxt.KeyPress += milageTxt_KeyPress;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(0, 67);
            label11.Name = "label11";
            label11.Size = new Size(59, 15);
            label11.TabIndex = 18;
            label11.Text = "Bouwjaar:";
            // 
            // buildYearNr
            // 
            buildYearNr.Location = new Point(217, 65);
            buildYearNr.Name = "buildYearNr";
            buildYearNr.Size = new Size(222, 23);
            buildYearNr.TabIndex = 17;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(0, 154);
            label10.Name = "label10";
            label10.Size = new Size(91, 15);
            label10.TabIndex = 16;
            label10.Text = "Aantal cilinders:";
            // 
            // cylinderCountNr
            // 
            cylinderCountNr.Location = new Point(217, 152);
            cylinderCountNr.Name = "cylinderCountNr";
            cylinderCountNr.Size = new Size(222, 23);
            cylinderCountNr.TabIndex = 15;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(0, 184);
            label9.Name = "label9";
            label9.Size = new Size(65, 15);
            label9.TabIndex = 14;
            label9.Text = "Brandstrof:";
            // 
            // fuelCombo
            // 
            fuelCombo.FormattingEnabled = true;
            fuelCombo.Items.AddRange(new object[] { "Benzine", "Diesel", "LPG", "Elektriciteit" });
            fuelCombo.Location = new Point(217, 181);
            fuelCombo.Name = "fuelCombo";
            fuelCombo.Size = new Size(222, 23);
            fuelCombo.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(0, 126);
            label6.Name = "label6";
            label6.Size = new Size(112, 15);
            label6.TabIndex = 12;
            label6.Text = "Cilinderinhoud: (cc)";
            // 
            // ccTxt
            // 
            ccTxt.Location = new Point(217, 123);
            ccTxt.Name = "ccTxt";
            ccTxt.Size = new Size(222, 23);
            ccTxt.TabIndex = 11;
            // 
            // vinLocationTxt
            // 
            vinLocationTxt.AutoSize = true;
            vinLocationTxt.Font = new Font("Segoe UI", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            vinLocationTxt.Location = new Point(217, 265);
            vinLocationTxt.Name = "vinLocationTxt";
            vinLocationTxt.Size = new Size(77, 13);
            vinLocationTxt.TabIndex = 10;
            vinLocationTxt.Text = "PLACEHOLDER";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(0, 242);
            label8.Name = "label8";
            label8.Size = new Size(29, 15);
            label8.TabIndex = 9;
            label8.Text = "VIN:";
            // 
            // vinTxt
            // 
            vinTxt.Location = new Point(217, 239);
            vinTxt.Name = "vinTxt";
            vinTxt.Size = new Size(222, 23);
            vinTxt.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(0, 97);
            label7.Name = "label7";
            label7.Size = new Size(37, 15);
            label7.TabIndex = 7;
            label7.Text = "Kleur:";
            // 
            // colorTxt
            // 
            colorTxt.Location = new Point(217, 94);
            colorTxt.Name = "colorTxt";
            colorTxt.Size = new Size(222, 23);
            colorTxt.TabIndex = 5;
            // 
            // modelTxt
            // 
            modelTxt.Location = new Point(217, 36);
            modelTxt.Name = "modelTxt";
            modelTxt.Size = new Size(222, 23);
            modelTxt.TabIndex = 3;
            // 
            // brandTxt
            // 
            brandTxt.Location = new Point(217, 7);
            brandTxt.Name = "brandTxt";
            brandTxt.Size = new Size(222, 23);
            brandTxt.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(0, 39);
            label5.Name = "label5";
            label5.Size = new Size(44, 15);
            label5.TabIndex = 1;
            label5.Text = "Model:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(0, 10);
            label4.Name = "label4";
            label4.Size = new Size(37, 15);
            label4.TabIndex = 0;
            label4.Text = "Merk:";
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(createBtn);
            panel3.Location = new Point(-2, 506);
            panel3.Name = "panel3";
            panel3.Size = new Size(544, 44);
            panel3.TabIndex = 4;
            // 
            // createBtn
            // 
            createBtn.Enabled = false;
            createBtn.Location = new Point(459, 9);
            createBtn.Name = "createBtn";
            createBtn.Size = new Size(75, 23);
            createBtn.TabIndex = 5;
            createBtn.Text = "Aanmaken";
            createBtn.UseVisualStyleBackColor = true;
            createBtn.Click += createBtn_Click;
            // 
            // selectLocationBtn
            // 
            selectLocationBtn.Location = new Point(395, 450);
            selectLocationBtn.Name = "selectLocationBtn";
            selectLocationBtn.Size = new Size(84, 23);
            selectLocationBtn.TabIndex = 5;
            selectLocationBtn.Text = "Selecteren";
            selectLocationBtn.UseVisualStyleBackColor = true;
            selectLocationBtn.Click += selectLocationBtn_Click;
            // 
            // locationTxt
            // 
            locationTxt.Location = new Point(40, 451);
            locationTxt.Name = "locationTxt";
            locationTxt.Size = new Size(349, 23);
            locationTxt.TabIndex = 6;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(40, 433);
            label13.Name = "label13";
            label13.Size = new Size(90, 15);
            label13.TabIndex = 7;
            label13.Text = "Bestand locatie:";
            // 
            // CreateOnderhoudsboekjeWizzard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(539, 547);
            Controls.Add(label13);
            Controls.Add(locationTxt);
            Controls.Add(selectLocationBtn);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(label3);
            Controls.Add(licensePlateTextbox1);
            Controls.Add(panel1);
            Name = "CreateOnderhoudsboekjeWizzard";
            Text = "Nieuw onderhoudsboekje maken";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)buildYearNr).EndInit();
            ((System.ComponentModel.ISupportInitialize)cylinderCountNr).EndInit();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private Controls.LicensePlateTextbox licensePlateTextbox1;
        private Label label3;
        private Panel panel2;
        private TextBox modelTxt;
        private TextBox brandTxt;
        private Label label5;
        private Label label4;
        private TextBox colorTxt;
        private Label label8;
        private TextBox vinTxt;
        private Label label7;
        private Label vinLocationTxt;
        private Label label6;
        private TextBox ccTxt;
        private Label label9;
        private ComboBox fuelCombo;
        private NumericUpDown cylinderCountNr;
        private Label label10;
        private Label label11;
        private NumericUpDown buildYearNr;
        private Panel panel3;
        private Button createBtn;
        private Button selectLocationBtn;
        private TextBox locationTxt;
        private SaveFileDialog saveFileDialog1;
        private TextBox milageTxt;
        private Label label12;
        private Label label13;
    }
}