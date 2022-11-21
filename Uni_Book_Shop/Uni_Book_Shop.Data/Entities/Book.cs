namespace Uni_Book_Shop.Data
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Price { get; set; }
        public string Photo { get; set; } = null!;
        public int BookCode { get; set; }
        public string Author { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Theme { get; set; } = null!;
        public int YearPublished { get; set; }
        public string Edition { get; set; } = null!;
        public int Amount { get; set; }
    }
}