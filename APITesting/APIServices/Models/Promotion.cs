namespace APIServices.Models
{
    public class Promotion
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public long MinimumPhotoCount { get; set; }
        public long? OriginalPrice { get; set; }
        public bool? Recommended { get; set; }

    }
}
