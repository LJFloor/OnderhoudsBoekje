namespace OnderhoudsBoekje.Data.Models
{
    public class ConfigFile
    {
        /// <summary>
        /// Path to the file that was opened last time.
        /// </summary>
        public string? LastOpenedFile { get; set; }

        /// <summary>
        /// A list of files that were opened recently, in order of most recently opened.
        /// </summary>
        public List<string> RecentlyOpenedFiles { get; set; } = [];
    }
}
