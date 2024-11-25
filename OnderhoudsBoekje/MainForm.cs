using OnderhoudsBoekje.CreateWizzard;
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

        public MainForm()
        {
            InitializeComponent();
            Icon = Icon.FromHandle(Properties.Resources.book.GetHicon());
            var imageList = new ImageList();
            imageList.Images.Add(Properties.Resources.paperclip);
            listView1.SmallImageList = imageList;
            attachmentsHeader.ImageIndex = 0;
        }

        public void ReadFromFile()
        {
            var json = File.ReadAllText(OpenFile);
            var boekje = JsonSerializer.Deserialize<Data.Models.OnderhoudsBoekje>(json)!;
            boekje.MaintenanceEntries = boekje.MaintenanceEntries.OrderByDescending(x => x.Mileage).ToList();
            Boekje = boekje;

            status1.Text = $"Onderhoudsboekje voor {Boekje.CarInfo.Brand} {Boekje.CarInfo.Model} ({Boekje.CarInfo.LicensePlate})";
        }

        public static void Save()
        {
            var json = JsonSerializer.Serialize(Boekje);
            File.WriteAllText(OpenFile, json);
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
                OpenFile = openFileDialog1.FileName;
                ReadFromFile();
                RenderRows();
                Cursor = Cursors.Default;
            }
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

        private void nieuwOnderhoudsboekjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var wizzard = new CreateOnderhoudsboekjeWizzard();
            wizzard.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var window = new AddMaintenanceEntry();
            window.Show();
            window.FormClosed += (s, e) => RenderRows();
        }

        private void opslaanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}
