namespace MDP.Models
{
    public class Image
    {
        public int Id { get; set; }
        /// <summary>
        /// May be an URL or a Base64
        /// </summary>
        public string Content { get; set; }
        public ImageType Type { get; set; }
    }
}
