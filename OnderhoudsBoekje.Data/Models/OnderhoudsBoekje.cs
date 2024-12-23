namespace OnderhoudsBoekje.Data.Models
{
    /// <summary>
    /// An onderhoudsboekje for a car.
    /// </summary>
    public class OnderhoudsBoekje
    {
        /// <summary>
        /// Information about the car.
        /// </summary>
        public required CarInfo CarInfo { get; init; } = new CarInfo();

        /// <summary>
        /// List of maintenance entries.
        /// </summary>
        public List<MaintenanceEntry> MaintenanceEntries { get; set; } = [];

        /// <summary>
        /// The date and time when this onderhoudsboekje was created.
        /// </summary>
        public DateTime Created { get; set; } = DateTime.Now;

        /// <summary>
        /// Settings for this onderhoudsboekje.
        /// </summary>
        public Settings Settings { get; set; } = new Settings();
    }
}
