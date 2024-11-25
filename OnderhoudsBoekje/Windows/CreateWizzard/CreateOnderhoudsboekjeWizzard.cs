using Microsoft.EntityFrameworkCore;
using OnderhoudsBoekje.Data.Models;
using RdwApi;

namespace OnderhoudsBoekje.CreateWizzard
{
    public partial class CreateOnderhoudsboekjeWizzard : Form
    {
        private string PreviousLicensePlate = "";
        private readonly RdwClient _rdwClient = new();

        public CreateOnderhoudsboekjeWizzard()
        {
            InitializeComponent();
            vinLocationTxt.Text = "";
            buildYearNr.Minimum = 1900;
            buildYearNr.Maximum = DateTime.Now.Year;
        }

        private async void licensePlateTextbox1_Leave(object sender, EventArgs e)
        {

            var stripped = StripLicensePlate(licensePlateTextbox1.Text);
            if (PreviousLicensePlate != licensePlateTextbox1.Text && stripped.Length == 6)
            {
                try
                {
                    var info = await _rdwClient.GetCarAsync(licensePlateTextbox1.Text);
                    var fuelInfo = await _rdwClient.GetFuelInfoAsync(licensePlateTextbox1.Text);
                    if (info == null)
                    {
                        return;
                    }


                    brandTxt.Text = info.Brand == "BMW" ? "BMW" : FirstCapital(info.Brand);
                    modelTxt.Text = FirstCapital(info.Model);
                    colorTxt.Text = FirstCapital(info.FirstColor);
                    ccTxt.Text = info.CylinderCapacity.ToString();
                    cylinderCountNr.Value = info.PistonCount;
                    buildYearNr.Value = info.FirstAdmissionDate.Year;


                    if (fuelInfo != null)
                    {
                        // get all options of fuel combo as string array
                        var fuelOptions = fuelCombo.Items.Cast<string>().ToArray();

                        var selectedFuel = fuelOptions.FirstOrDefault(f => f.ToLower().Contains(fuelInfo.Description.ToLower()));

                        // If not found locally, add it to the combo box
                        if (selectedFuel != null)
                        {
                            fuelCombo.SelectedItem = selectedFuel;
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(info.ChassisNumberLocation))
                    {
                        vinLocationTxt.Text = $"Locatie: {info.ChassisNumberLocation}";
                        // set tooltip to so when user hovers they see the full location
                        var tooltip = new ToolTip();
                        tooltip.SetToolTip(vinLocationTxt, info.ChassisNumberLocation);
                    }


                    licensePlateTextbox1.Text = FormatLicensePlate(info.LicensePlate);
                }
                catch
                {

                }
            }

            PreviousLicensePlate = licensePlateTextbox1.Text;

        }

        private string StripLicensePlate(string raw)
        {
            // use regex to filter out anything not a letter or number
            var regex = new System.Text.RegularExpressions.Regex("[^a-zA-Z0-9]");
            return regex.Replace(raw, "");
        }

        private string FirstCapital(string str)
        {
            var split = str.Split(" ").SelectMany(s => s.Split("-"));
            var result = "";
            foreach (var s in split)
            {
                result += s.Substring(0, 1).ToUpper() + s.Substring(1).ToLower() + " ";
            }
            return result.Trim();
        }

        private string FormatLicensePlate(string raw)
        {
            var stripped = StripLicensePlate(raw).ToCharArray();
            var result = "";

            for (int i = 0; i < stripped.Length; i++)
            {
                if (i == 0)
                {
                    result += char.ToUpper(stripped[i]);
                    continue;
                }

                var lastWasLetter = char.IsLetter(stripped[i - 1]);
                var currentIsLetter = char.IsLetter(stripped[i]);
                if (lastWasLetter == currentIsLetter)
                {
                    result += char.ToUpper(stripped[i]);
                }
                else
                {
                    result += '-';
                    result += char.ToUpper(stripped[i]);
                }
            }

            // If anywhere in result there is a group of 4 leters or 4 numbers without a dash, split it up
            var regex = new System.Text.RegularExpressions.Regex("([A-Z]{4})|([0-9]{4})");
            var matches = regex.Matches(result);

            if (matches.Count > 0)
            {
                var match = matches[0];
                var index = result.IndexOf(match.Value);
                result = result.Insert(index + 2, "-");
            }

            return result;
        }

        private void selectLocationBtn_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Onderhoudsboekje bestand|*.obk";
            saveFileDialog1.Title = "Selecteer een locatie voor het onderhoudsboekje";
            saveFileDialog1.FileName = $"{licensePlateTextbox1.Text} {brandTxt.Text} {modelTxt.Text}.obk";
            saveFileDialog1.ShowDialog();

            if (!string.IsNullOrWhiteSpace(saveFileDialog1.FileName) && Directory.Exists(Path.GetDirectoryName(saveFileDialog1.FileName)))
            {
                locationTxt.Text = saveFileDialog1.FileName;
                createBtn.Enabled = true;
            }
            else
            {
                createBtn.Enabled = false;
            }
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            if (File.Exists(locationTxt.Text))
            {
                MessageBox.Show("Het bestand bestaat al, kies een andere locatie", "Bestand bestaat al", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MainForm.OpenFile = locationTxt.Text;
            MainForm.Boekje = new Data.Models.OnderhoudsBoekje()
            {
                CarInfo = new CarInfo
                {
                    Brand = brandTxt.Text,
                    Model = modelTxt.Text,
                    LicensePlate = licensePlateTextbox1.Text,
                    BuildYear = (int)buildYearNr.Value,
                    CylinderCapacity = int.Parse(ccTxt.Text),
                    CylinderCount = (int)cylinderCountNr.Value,
                    FuelType = fuelCombo.SelectedItem?.ToString() ?? "",
                    Color = colorTxt.Text,
                    Vin = vinTxt.Text,
                    Mileage = milageTxt.Text == "" ? 0 : uint.Parse(milageTxt.Text)
                }
            };

            MainForm.Save();

            MessageBox.Show("Onderhoudsboekje aangemaakt", "Onderhoudsboekje aangemaakt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void milageTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only numbers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            } 
        }
    }
}
