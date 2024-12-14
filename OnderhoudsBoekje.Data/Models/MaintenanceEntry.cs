namespace OnderhoudsBoekje.Data.Models
{
    public class MaintenanceEntry
    {
        /// <summary>
        /// Id of the entry.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Describes the maintenance.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The type of maintenance.
        /// </summary>
        public MaintenanceType Type { get; set; }

        /// <summary>
        /// Date of when the maintenance was done.
        /// </summary>
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        /// <summary>
        /// Mileage of the car when the maintenance was done.
        /// </summary>
        public uint? Mileage { get; set; }

        /// <summary>
        /// How long it took to do the maintenance.
        /// </summary>
        public TimeSpan? Duration { get; set; }

        /// <summary>
        /// Optional cost of the maintenance.
        /// </summary>
        public decimal? Cost { get; set; }

        /// <summary>
        /// Some extra notes about the maintenance.
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        /// A list of attachments to this entry.
        /// </summary>
        public List<DatabaseFile> Attachments { get; set; } = [];

        /// <summary>
        /// The date and time when this entry was created.
        /// </summary>
        public DateTime Created { get; } = DateTime.Now;
    }

    public enum MaintenanceType
    {
        Onderhoud = 1,
        Reparatie = 2,
        Modificatie = 3,
        APK = 4,
        Overig = 5
    }
}
