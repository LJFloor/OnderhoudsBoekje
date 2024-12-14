namespace OnderhoudsBoekje.Data.Models
{
    public class Settings
    {
        /// <summary>
        /// Remind the user when the APK is about to expire.
        /// This is two weeks before the expiry date.
        /// </summary>
        public bool RemindApkExpiry { get; set; } = true;
    }
}
