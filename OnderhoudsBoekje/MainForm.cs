using OnderhoudsBoekje.CreateWizzard;
using OnderhoudsBoekje.Data.Models;
using OnderhoudsBoekje.Windows;
using System.Text.Json;

namespace OnderhoudsBoekje
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// The file that is currently being used.
        /// </summary>
        public static string OpenFile = "";
        public static Data.Models.OnderhoudsBoekje Boekje;
        public static ConfigFile Config;

        // %appdata%\OnderhoudsBoekje\config.json
        private static readonly string configPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "OnderhoudsBoekje", "config.json");

        public MainForm()
        {
            InitializeComponent();
            Icon = Icon.FromHandle(Properties.Resources.book.GetHicon());
            var imageList = new ImageList();
            imageList.Images.Add(Properties.Resources.paperclip);
            listView1.SmallImageList = imageList;
            attachmentsHeader.ImageIndex = 0;

            openenToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            opslaanToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            nieuwOnderhoudsboekjeToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;


            if (File.Exists(configPath))
            {
                var json = File.ReadAllText(configPath);
                Config = JsonSerializer.Deserialize<ConfigFile>(json)!;

                if (Config.LastOpenedFile != null)
                {
                    LoadFile(Config.LastOpenedFile);
                }
            }
            else
            {
                Directory.CreateDirectory(Path.GetDirectoryName(configPath)!);
                File.WriteAllText(configPath, JsonSerializer.Serialize(new Data.Models.ConfigFile()));
            }
        }

        public void LoadFile(string file)
        {
            try
            {
                var json = File.ReadAllText(file);
                var boekje = JsonSerializer.Deserialize<Data.Models.OnderhoudsBoekje>(json);

                if (boekje == null)
                {
                    MessageBox.Show("Het bestand is geen geldig onderhoudsboekje bestand.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                boekje.MaintenanceEntries = boekje.MaintenanceEntries.OrderByDescending(x => x.Mileage).ToList();
                Boekje = boekje;

                status1.Text = $"Onderhoudsboekje voor {Boekje.CarInfo.Brand} {Boekje.CarInfo.Model} ({Boekje.CarInfo.LicensePlate})";
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Er is een fout opgetreden bij het openen van het bestand: {ex.Message}", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Er is een fout opgetreden bij het lezen van het bestand: {ex.Message}", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OpenFile = file;
            RenderRows();
            SaveConfig();
            RenderShell();
        }

        public static void Save()
        {
            Cursor.Current = Cursors.WaitCursor;
            var json = JsonSerializer.Serialize(Boekje);
            File.WriteAllText(OpenFile, json);
            Cursor.Current = Cursors.Default;
        }

        public void SaveConfig()
        {
            Config.LastOpenedFile = OpenFile;
            Config.RecentlyOpenedFiles = Config.RecentlyOpenedFiles.Where(x => x != OpenFile).ToList();
            Config.RecentlyOpenedFiles.Insert(0, OpenFile);
            Config.RecentlyOpenedFiles = Config.RecentlyOpenedFiles.Take(10).ToList();
            File.WriteAllText(configPath, JsonSerializer.Serialize(Config));
        }

        private void RenderRows()
        {
            var rows = Boekje.MaintenanceEntries.Select(entry => new ListViewItem(entry.Attachments.Count == 0 ? "" : entry.Attachments.Count.ToString())
            {

                SubItems =
                {
                    entry.Date.ToString(),
                    entry.Mileage.ToString(),
                    entry.Description,
                    entry.Cost?.ToString("C") ?? "",
                    entry.Duration == null ? "" : $"{entry.Duration?.Hours:00}:{entry.Duration?.Minutes:00}",
                    entry.Notes
                }
            }).ToArray();

            listView1.Items.Clear();
            listView1.Items.AddRange(rows);
        }

        private void RenderShell()
        {
            // render other items, like the car info, menu recents, etc.

            if (Boekje == null)
            {
                status1.Text = "Geen onderhoudsboekje geopend";
                return;
            }

            status1.Text = $"Onderhoudsboekje voor {Boekje.CarInfo.Brand} {Boekje.CarInfo.Model} ({Boekje.CarInfo.LicensePlate})";

            var existingItems = Config.RecentlyOpenedFiles
                .Where(x => File.Exists(x))
                .ToList();

            recentFilesMenuButton.DropDownItems.Clear();
            recentFilesMenuButton.Enabled = existingItems.Any();
            recentFilesMenuButton.DropDownItems.AddRange(existingItems.Select(file =>
            {
                var item = new ToolStripMenuItem(file);
                item.Click += (s, e) => LoadFile(file);
                return item;
            }).ToArray());
        }

        private void OpenEditWindow(Guid? id = null)
        {
            var window = new AddMaintenanceEntry(id);
            // set the window to the same screen as the parent
            window.StartPosition = FormStartPosition.Manual;
            window.Location = new Point(Location.X + (Width - window.Width) / 2, Location.Y + (Height - window.Height) / 2);
            window.Show();

            window.FormClosed += (s, e) =>
            {
                if (window.DialogResult == DialogResult.OK)
                {
                    RenderRows();
                }
            };
        }

        private void openenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Onderhoudsboekje bestand|*.obk|Alle bestanden|*.*";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.Title = "Open een onderhoudsboekje";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName != "")
            {
                Cursor = Cursors.WaitCursor;
                LoadFile(openFileDialog1.FileName);
                Cursor = Cursors.Default;
            }
        }

        private void nieuwOnderhoudsboekjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var wizzard = new CreateOnderhoudsboekjeWizzard();
            wizzard.ShowDialog();

            if (wizzard.DialogResult == DialogResult.OK)
            {
                LoadFile(wizzard.Filename);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenEditWindow();
        }

        private void opslaanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            deleteBtn.Enabled = listView1.SelectedItems.Count > 0;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            bool confirm;

            if (listView1.SelectedItems.Count == 1)
            {
                confirm = MessageBox.Show("Weet je zeker dat je dit onderhoudsitem wilt verwijderen?", "Verwijderen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            }
            else
            {
                confirm = MessageBox.Show($"Weet je zeker dat je deze {listView1.SelectedItems.Count} onderhoudsitems wilt verwijderen?", "Verwijderen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            }

            if (!confirm)
            {
                return;
            }

            foreach (ListViewItem item in listView1.SelectedItems)
            {
                Boekje.MaintenanceEntries.RemoveAt(item.Index);
            }

            RenderRows();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                return;
            }

            var entry = Boekje.MaintenanceEntries[listView1.SelectedItems[0].Index];
            OpenEditWindow(entry.Id);
        }
    }
}