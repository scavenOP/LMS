namespace LMS.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Edition { get; set; }
        public string Catagory { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }

        public Publisher Publisher { get; set; }
        public int PublisherId { get; set; }
        public long Price { get; set; }
    }
}