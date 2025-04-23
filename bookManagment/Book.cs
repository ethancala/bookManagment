//This is model for the books
namespace bookManagment
{
    public class Book
    {
        //im using default constructor, and standard traits of a book
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }

        //simple to string method
        public override string ToString()
        {
            return $"{Id} {Title} {Author} {Genre} {Year}";
        }
    }
}