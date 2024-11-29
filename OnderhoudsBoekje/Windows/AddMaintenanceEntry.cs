using OnderhoudsBoekje.Data.Models;

namespace OnderhoudsBoekje.Windows
{
    public partial class AddMaintenanceEntry : Form
    {
        private readonly Guid? _id;
        public AddMaintenanceEntry(Guid? id = null)
        {
            InitializeComponent();
            Icon = Icon.FromHandle(Properties.Resources.add.GetHicon());
            _id = id;

            typeCombo.Items.AddRange(Enum.GetNames<MaintenanceType>());
            typeCombo.SelectedIndex = 0;

            var durationItems = new List<string>();
            for (var i = 0; i < 24; i++)
            {
                for (var j = 0; j < 60; j += 5)
                {
                    durationItems.Add($"{i:00}:{j:00}");
                }
            }

            durationItems.Reverse();
            durationCombo.Items.Clear();
            durationCombo.Items.AddRange(durationItems.ToArray());

            if (_id == null)
            {
                milageTxt.Text = MainForm.Boekje.CarInfo.Mileage.ToString();
            }
            else
            {
                var entry = MainForm.Boekje.MaintenanceEntries.Find(e => e.Id == _id)!;
                dateTimePicker1.Value = entry.Date.ToDateTime(new TimeOnly());
                typeCombo.SelectedIndex = typeCombo.Items.IndexOf(entry.Type.ToString());
                milageTxt.Text = entry.Mileage.ToString();
                descriptionTxt.Text = entry.Description;

                durationCombo.SelectedIndex = durationCombo.Items.IndexOf(entry.Duration?.ToString("hh\\:mm") ?? "00:00");
                costTxt.Value = entry.Cost ?? 0;
                notesTxt.Text = entry.Notes;
                createBtn.Text = "Opslaan";
            }
        }

        private void numericUpDown2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void milageTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // numbers only
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            var milage = uint.Parse(milageTxt.Text);
            var newEntry = new MaintenanceEntry
            {
                Id = Guid.NewGuid(),
                Date = DateOnly.FromDateTime(dateTimePicker1.Value.Date),
                Mileage = milage,
                Description = descriptionTxt.Text,
                Duration = durationCombo.SelectedItem?.ToString() == null ? null : TimeSpan.Parse(durationCombo.SelectedItem.ToString()),
                Type = (MaintenanceType)Enum.Parse(typeof(MaintenanceType), typeCombo.SelectedItem.ToString()),
                Cost = costTxt.Value is 0 ? null : costTxt.Value,
                Notes = string.IsNullOrWhiteSpace(notesTxt.Text) ? null : notesTxt.Text,
            };

            if (_id == null)
            {
                // insert at the beginning
                MainForm.Boekje.MaintenanceEntries.Insert(0, newEntry);

                if (milage > MainForm.Boekje.CarInfo.Mileage)
                {
                    MainForm.Boekje.CarInfo.Mileage = milage;
                }
            }
            else
            {
                newEntry.Id = _id.Value;
                var index = MainForm.Boekje.MaintenanceEntries.FindIndex(e => e.Id == _id);

                // remove the old, insert the new
                MainForm.Boekje.MaintenanceEntries.RemoveAt(index);
                MainForm.Boekje.MaintenanceEntries.Insert(index, newEntry);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void descriptionTxt_TextChanged(object sender, EventArgs e)
        {
            createBtn.Enabled = !string.IsNullOrWhiteSpace(descriptionTxt.Text);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void AddMaintenanceEntry_Load(object sender, EventArgs e)
        {
            await Task.Delay(50);
            descriptionTxt.Focus();
        }
    }
}
