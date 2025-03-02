namespace Scrap.Model
{
    public class CollectedInfo
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Link { get; set; }
        public DateTime ScrapedAt { get; set; }
        public int WebsiteId { get; set; }
    }
}
