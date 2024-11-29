namespace OnderhoudsBoekje
{
    partial class MainForm
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
            listView1 = new ListView();
            attachmentsHeader = new ColumnHeader();
            dateHeader = new ColumnHeader();
            kmHeader = new ColumnHeader();
            descriptioHeader = new ColumnHeader();
            costHeader = new ColumnHeader();
            timeHeader = new ColumnHeader();
            notesHeader = new ColumnHeader();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            deleteBtn = new ToolStripButton();
            statusStrip1 = new StatusStrip();
            status1 = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            bestandToolStripMenuItem = new ToolStripMenuItem();
            openenToolStripMenuItem = new ToolStripMenuItem();
            recentFilesMenuButton = new ToolStripMenuItem();
            opslaanToolStripMenuItem = new ToolStripMenuItem();
            nieuwOnderhoudsboekjeToolStripMenuItem = new ToolStripMenuItem();
            bewerkenToolStripMenuItem = new ToolStripMenuItem();
            weergaveToolStripMenuItem = new ToolStripMenuItem();
            sToolStripMenuItem = new ToolStripMenuItem();
            overToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog1 = new OpenFileDialog();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView1.Columns.AddRange(new ColumnHeader[] { attachmentsHeader, dateHeader, kmHeader, descriptioHeader, costHeader, timeHeader, notesHeader });
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new Point(0, 52);
            listView1.Name = "listView1";
            listView1.Size = new Size(1108, 485);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.ItemSelectionChanged += listView1_ItemSelectionChanged;
            listView1.DoubleClick += listView1_DoubleClick;
            // 
            // attachmentsHeader
            // 
            attachmentsHeader.Text = "";
            attachmentsHeader.Width = 32;
            // 
            // dateHeader
            // 
            dateHeader.Text = "Datum";
            dateHeader.Width = 100;
            // 
            // kmHeader
            // 
            kmHeader.Text = "Kilometerstand";
            kmHeader.Width = 100;
            // 
            // descriptioHeader
            // 
            descriptioHeader.Text = "Omschrijving";
            descriptioHeader.Width = 300;
            // 
            // costHeader
            // 
            costHeader.Text = "Kosten";
            costHeader.Width = 80;
            // 
            // timeHeader
            // 
            timeHeader.Text = "Tijd";
            timeHeader.Width = 100;
            // 
            // notesHeader
            // 
            notesHeader.Text = "Opmerkingen";
            notesHeader.Width = 400;
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, deleteBtn });
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(2, 0, 2, 0);
            toolStrip1.Size = new Size(1108, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.Image = Properties.Resources.add;
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(86, 22);
            toolStripButton1.Text = "Registreren";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // deleteBtn
            // 
            deleteBtn.Enabled = false;
            deleteBtn.Image = Properties.Resources.cross;
            deleteBtn.ImageTransparentColor = Color.Magenta;
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(88, 22);
            deleteBtn.Text = "Verwijderen";
            deleteBtn.Click += deleteBtn_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { status1 });
            statusStrip1.Location = new Point(0, 537);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1108, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // status1
            // 
            status1.Name = "status1";
            status1.Size = new Size(118, 17);
            status1.Text = "toolStripStatusLabel1";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { bestandToolStripMenuItem, bewerkenToolStripMenuItem, weergaveToolStripMenuItem, overToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1108, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // bestandToolStripMenuItem
            // 
            bestandToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openenToolStripMenuItem, recentFilesMenuButton, opslaanToolStripMenuItem, nieuwOnderhoudsboekjeToolStripMenuItem });
            bestandToolStripMenuItem.Name = "bestandToolStripMenuItem";
            bestandToolStripMenuItem.Size = new Size(61, 20);
            bestandToolStripMenuItem.Text = "Bestand";
            // 
            // openenToolStripMenuItem
            // 
            openenToolStripMenuItem.Image = Properties.Resources.book;
            openenToolStripMenuItem.Name = "openenToolStripMenuItem";
            openenToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + O";
            openenToolStripMenuItem.Size = new Size(259, 22);
            openenToolStripMenuItem.Text = "Openen";
            openenToolStripMenuItem.Click += openenToolStripMenuItem_Click;
            // 
            // recentFilesMenuButton
            // 
            recentFilesMenuButton.Name = "recentFilesMenuButton";
            recentFilesMenuButton.Size = new Size(259, 22);
            recentFilesMenuButton.Text = "Recente bestanden";
            // 
            // opslaanToolStripMenuItem
            // 
            opslaanToolStripMenuItem.Image = Properties.Resources.save;
            opslaanToolStripMenuItem.Name = "opslaanToolStripMenuItem";
            opslaanToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + S";
            opslaanToolStripMenuItem.Size = new Size(259, 22);
            opslaanToolStripMenuItem.Text = "Opslaan";
            opslaanToolStripMenuItem.Click += opslaanToolStripMenuItem_Click;
            // 
            // nieuwOnderhoudsboekjeToolStripMenuItem
            // 
            nieuwOnderhoudsboekjeToolStripMenuItem.Image = Properties.Resources.book_add;
            nieuwOnderhoudsboekjeToolStripMenuItem.Name = "nieuwOnderhoudsboekjeToolStripMenuItem";
            nieuwOnderhoudsboekjeToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl + N";
            nieuwOnderhoudsboekjeToolStripMenuItem.Size = new Size(259, 22);
            nieuwOnderhoudsboekjeToolStripMenuItem.Text = "Nieuw onderhoudsboekje";
            nieuwOnderhoudsboekjeToolStripMenuItem.Click += nieuwOnderhoudsboekjeToolStripMenuItem_Click;
            // 
            // bewerkenToolStripMenuItem
            // 
            bewerkenToolStripMenuItem.Name = "bewerkenToolStripMenuItem";
            bewerkenToolStripMenuItem.Size = new Size(70, 20);
            bewerkenToolStripMenuItem.Text = "Bewerken";
            // 
            // weergaveToolStripMenuItem
            // 
            weergaveToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sToolStripMenuItem });
            weergaveToolStripMenuItem.Name = "weergaveToolStripMenuItem";
            weergaveToolStripMenuItem.Size = new Size(71, 20);
            weergaveToolStripMenuItem.Text = "Weergave";
            // 
            // sToolStripMenuItem
            // 
            sToolStripMenuItem.Image = Properties.Resources.paperclip;
            sToolStripMenuItem.Name = "sToolStripMenuItem";
            sToolStripMenuItem.Size = new Size(79, 22);
            sToolStripMenuItem.Text = "s";
            // 
            // overToolStripMenuItem
            // 
            overToolStripMenuItem.Name = "overToolStripMenuItem";
            overToolStripMenuItem.Size = new Size(44, 20);
            overToolStripMenuItem.Text = "Over";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1108, 559);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            Controls.Add(listView1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Onderhoudsboekje";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private ToolStrip toolStrip1;
        private ToolStripButton deleteBtn;
        private ToolStripButton toolStripButton1;
        private StatusStrip statusStrip1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem bestandToolStripMenuItem;
        private ToolStripMenuItem openenToolStripMenuItem;
        private ToolStripMenuItem opslaanToolStripMenuItem;
        private ToolStripMenuItem nieuwOnderhoudsboekjeToolStripMenuItem;
        private OpenFileDialog openFileDialog1;
        private ColumnHeader dateHeader;
        private ColumnHeader kmHeader;
        private ColumnHeader descriptioHeader;
        private ToolStripStatusLabel status1;
        private ColumnHeader costHeader;
        private ColumnHeader timeHeader;
        private ColumnHeader notesHeader;
        private ToolStripMenuItem bewerkenToolStripMenuItem;
        private ToolStripMenuItem weergaveToolStripMenuItem;
        private ToolStripMenuItem overToolStripMenuItem;
        private ColumnHeader attachmentsHeader;
        private ToolStripMenuItem sToolStripMenuItem;
        private ToolStripMenuItem recentFilesMenuButton;
    }
}
