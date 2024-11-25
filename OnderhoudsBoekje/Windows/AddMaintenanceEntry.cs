using OnderhoudsBoekje.Data.Models;

namespace OnderhoudsBoekje.Windows
{
    public partial class AddMaintenanceEntry : Form
    {
        public AddMaintenanceEntry()
        {
            InitializeComponent();
            Icon = Icon.FromHandle(Properties.Resources.add.GetHicon());

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
            durationCombo.Items.AddRange(durationItems.ToArray());

            milageTxt.Text = MainForm.Boekje.CarInfo.Mileage.ToString();
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
            // insert at the beginning
            var milage = uint.Parse(milageTxt.Text);
            MainForm.Boekje.MaintenanceEntries.Insert(0, new MaintenanceEntry
            {
                Id = Guid.NewGuid(),
                Date = DateOnly.FromDateTime(dateTimePicker1.Value.Date),
                Mileage = milage,
                Description = descriptionTxt.Text,
                Duration = durationCombo.SelectedItem?.ToString() == null ? null : TimeSpan.Parse(durationCombo.SelectedItem.ToString()),
                Type = (MaintenanceType)Enum.Parse(typeof(MaintenanceType), typeCombo.SelectedItem.ToString()),
                Cost = costTxt.Value is 0 ? null : costTxt.Value,
                Notes = string.IsNullOrWhiteSpace(notesTxt.Text) ? null : notesTxt.Text,
            });

            if (milage > MainForm.Boekje.CarInfo.Mileage)
            {
                MainForm.Boekje.CarInfo.Mileage = milage;
            }

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
