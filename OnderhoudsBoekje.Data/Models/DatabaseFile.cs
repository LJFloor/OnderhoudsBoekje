namespace OnderhoudsBoekje.Data.Models
{
    public class DatabaseFile
    {
        /// <summary>
        /// The Id of the file.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the file.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// The content of the file.
        /// </summary>
        public byte[] Content { get; set; } = [];
    }
}
