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
        public required CarInfo CarInfo { get; set; }

        /// <summary>
        /// List of maintenance entries.
        /// </summary>
        public List<MaintenanceEntry> MaintenanceEntries { get; set; } = [];
    }
}
