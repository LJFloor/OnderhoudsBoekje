using OnderhoudsBoekje.CreateWizzard;
using OnderhoudsBoekje.Data.Models;
using OnderhoudsBoekje.Windows;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using RdwApi;
using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
                Config = new ConfigFile();
                Directory.CreateDirectory(Path.GetDirectoryName(configPath)!);
                File.WriteAllText(configPath, JsonSerializer.Serialize(Config));
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
            toolStripButton1.Enabled = true;
            RenderRows();
            SaveConfig();
            RenderShell();
            CheckForApkChange();
        }

        public static void Save()
        {
            Cursor.Current = Cursors.WaitCursor;
            var json = JsonSerializer.Serialize(Boekje, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(OpenFile, json);
            Cursor.Current = Cursors.Default;
        }

        public void SaveConfig()
        {
            Config.LastOpenedFile = OpenFile;
            Config.RecentlyOpenedFiles = Config.RecentlyOpenedFiles.Where(x => x != OpenFile).ToList();
            Config.RecentlyOpenedFiles.Insert(0, OpenFile);
            Config.RecentlyOpenedFiles = Config.RecentlyOpenedFiles.Take(10).ToList();
            File.WriteAllText(configPath, JsonSerializer.Serialize(Config, new JsonSerializerOptions
            {
                WriteIndented = true
            }));
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

        private void OpenEditWindow(MaintenanceEntry? entry = null)
        {
            var window = new AddMaintenanceEntry(entry);
            // set the window to the same screen as the parent
            window.StartPosition = FormStartPosition.Manual;
            window.Location = new Point(Location.X + (Width - window.Width) / 2, Location.Y + (Height - window.Height) / 2);
            window.Show();

            window.FormClosed += (s, e) =>
            {
                if (window.DialogResult == DialogResult.OK)
                {
                    RenderRows();
                    Save();
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
            OpenEditWindow(entry);
        }

        private async void CheckForApkChange()
        {
            if (string.IsNullOrWhiteSpace(Boekje.CarInfo.LicensePlate))
            {
                return;
            }

            var rdwClient = new RdwClient();
            var carInfo = await rdwClient.GetCarAsync(Boekje.CarInfo.LicensePlate);

            if (carInfo == null)
            {
                return;
            }

            if (carInfo.ApkExpiryDate < DateTime.Now)
            {
                MessageBox.Show($"Let op: De APK voor uw auto is verlopen op {carInfo.ApkExpiryDate.ToString("d MMMM yyyy").ToLower()}!", "APK verlopen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (carInfo.ApkExpiryDate.AddDays(-14) < DateTime.Now && Boekje.Settings.RemindApkExpiry)
            {
                var remindConfirm = MessageBox.Show($"Let op: De APK voor uw auto verloopt op {carInfo.ApkExpiryDate.ToString("d MMMM").ToLower()}!", "APK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // They already have an APK entry for this year
            if (Boekje.MaintenanceEntries.Any(x => x.Type == MaintenanceType.APK && x.Date.Year == DateTime.Now.Year))
            {
                return;
            }

            var apkRegisterDate = carInfo.ApkExpiryDate.AddYears(-1);

            // We don't bother people when they created the onderhoudsboekje BEFORE they got an APK this year
            if (apkRegisterDate < Boekje.Created)
            {
                return;
            }

            var confirm = MessageBox.Show($"Het lijkt erop dat uw auto door de APK is gekomen. Wilt u een onderhoudsitem toevoegen voor de APK van dit jaar?", "APK", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                OpenEditWindow(new MaintenanceEntry
                {
                    Type = MaintenanceType.APK,
                    Description = "APK keuring",
                    Date = DateOnly.FromDateTime(carInfo.ApkExpiryDate),
                    Mileage = Boekje.CarInfo.Mileage
                });
            }
        }

        private void exporterenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // export to PDF, landscape
            var dialog = new SaveFileDialog
            {
                Filter = "PDF bestand|*.pdf",
                Title = "Exporteer onderhoudsboekje",
                FileName = $"{Boekje.CarInfo.Brand} {Boekje.CarInfo.Model} {Boekje.CarInfo.LicensePlate} onderhoudsboekje.pdf"
            };

            dialog.ShowDialog();

            if (dialog.FileName == "")
            {
                return;
            }

            var lightGray = XColor.FromArgb(230, 230, 230);

            using var document = new PdfDocument();
            var page = document.AddPage();
            page.Size = PdfSharp.PageSize.A4;
            page.Orientation = PdfSharp.PageOrientation.Landscape;
            var gfx = XGraphics.FromPdfPage(page);
            var font = new XFont("Arial", 10);


            var headers = new string[] { "Datum", "Kilometerstand", "Omschrijving", "Kosten", "Duur", "Notities" };
            var columnWidths = new int[] { 100, 100, 300, 70, 50, 200 };
            DrawHeader(page, gfx, headers, columnWidths);


            var rowsPerPage = 23;

            var x = 40.0;
            var y = 80.0;

            for (int i = 0; i < Boekje.MaintenanceEntries.Count; i++)
            {
                MaintenanceEntry? entry = Boekje.MaintenanceEntries[i];
                x = 40;

                gfx.DrawString(entry.Date.ToString("dd-MM-yyyy"), font, XBrushes.Black, new XRect(x, y, columnWidths[0], 20), XStringFormats.TopLeft);
                x += columnWidths[0];

                gfx.DrawString(entry.Mileage.ToString(), font, XBrushes.Black, new XRect(x, y, columnWidths[1], 20), XStringFormats.TopLeft);
                x += columnWidths[1];

                gfx.DrawString(entry.Description, font, XBrushes.Black, new XRect(x, y, columnWidths[2], 20), XStringFormats.TopLeft);
                x += columnWidths[2];

                gfx.DrawString(entry.Cost?.ToString("C") ?? "", font, XBrushes.Black, new XRect(x, y, columnWidths[3], 20), XStringFormats.TopLeft);
                x += columnWidths[3];

                gfx.DrawString(entry.Duration == null ? "" : $"{entry.Duration?.Hours:00}:{entry.Duration?.Minutes:00}", font, XBrushes.Black, new XRect(x, y, columnWidths[4], 20), XStringFormats.TopLeft);
                x += columnWidths[4];

                gfx.DrawString(entry.Notes ?? "", font, XBrushes.Black, new XRect(x, y, columnWidths[5], 20), XStringFormats.TopLeft);

                var pen = new XPen(lightGray);
                gfx.DrawLine(pen, 40, y + 15, page.Width - 50, y + 15);

                y += 20;

                if (i > 0 && i % rowsPerPage == 0)
                {
                    y = 80;
                    var newPage = document.AddPage();
                    newPage.Orientation = PdfSharp.PageOrientation.Landscape;
                    newPage.Size = PdfSharp.PageSize.A4;
                    gfx = XGraphics.FromPdfPage(newPage);
                    DrawHeader(page, gfx, headers, columnWidths);
                }

                
            }

            document.Save(dialog.FileName);

            MessageBox.Show("Het onderhoudsboekje is geëxporteerd naar een PDF bestand.", "Exporteren", MessageBoxButtons.OK, MessageBoxIcon.Information);

            gfx.Dispose();
        }

        private static void DrawHeader(PdfPage page, XGraphics gfx, string[] columns, int[] sizes)
        {
            var headerFont = new XFont("Arial", 11, XFontStyleEx.Bold);
            gfx.DrawString($"Onderhoudsboekje voor {Boekje.CarInfo.Brand} {Boekje.CarInfo.Model} ({Boekje.CarInfo.LicensePlate})", headerFont, XBrushes.Black, new XRect(20, 20, page.Width - 40, 20), XStringFormats.TopCenter);
            var x = 40;
            var y = 60;
            for (var i = 0; i < columns.Length; i++)
            {
                gfx.DrawString(columns[i], headerFont, XBrushes.Black, new XRect(x, y, sizes[i], 20), XStringFormats.TopLeft);
                x += sizes[i];
            }

            // header line
            var black = XColor.FromArgb(0, 0, 0);
            var pen = new XPen(black);
            gfx.DrawLine(pen, 40, y + 15, page.Width - 50, y + 15);
        }
    }
}