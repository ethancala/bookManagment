//this is primary driver file, 

using bookManagment;

//here is the script I ran for query in SSMS
/*
CREATE DATABASE BookDB;
GO
USE BookDB;
CREATE TABLE Books (
    Id INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(100) NOT NULL,
    Author NVARCHAR(100) NOT NULL,
    Genre NVARCHAR(50),
    Year INT
);
*/
class Program
{
    static void Main(string[] args)
    {
        //this is my local host connection string, change as needed!
        const string connectionString = "Server=Ethans-PC;Database=BookDB;Trusted_Connection=True;";

        //create instance of DB
        var bookDb = new BookDB(connectionString);

        //loop until user breaks
        bool showMenu = true;
        while (showMenu)
        {
            //menu
            Console.Clear();
            Console.WriteLine("BOOK DATABASE SYSTEM");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. List Books");
            Console.WriteLine("3. Update Book");
            Console.WriteLine("4. Remove Book");
            Console.WriteLine("5. Remove All Books");
            Console.WriteLine("6. Exit");
            
            Console.Write("\n$: ");
            //switch statement for prompt bcuz im sick in the head
            switch (Console.ReadLine())
            {
                case "1":
                    AddBook(bookDb);
                    break;
                case "2":
                    ListBooks(bookDb);
                    break;
                case "3":
                    UpdateBook(bookDb);
                    break;
                case "4":
                    RemoveBook(bookDb);
                    break;
                case "5":
                    RemoveAllBooks(bookDb);
                    break;
                
                case "6":
                    showMenu = false;
                    break;
            }
        }
    }

    //function to add book, that calls DB function to add book
    static void AddBook(BookDB bookDb)
    {
        var book = new Book();
        Console.Write("Enter title: ");
        book.Title = Console.ReadLine();
        Console.Write("Enter author: ");
        book.Author = Console.ReadLine();
        Console.Write("Enter genre: ");
        book.Genre = Console.ReadLine();
        Console.Write("Enter year: ");
        int.TryParse(Console.ReadLine(), out int year);
        book.Year = year;
        bookDb.AddBook(book);
    }
    
    //function to re book, that calls DB function to re book
    static void RemoveBook(BookDB bookDb)
    {
        Console.Write("Enter the Id of the book to remove: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            bookDb.RemoveBook(id);
        }
        else
        {
            Console.WriteLine("Invalid Id.");
        }
        //ui continue thing I thought might be better 
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    
    //function to re ALL books, that calls DB function e ALL books
    static void RemoveAllBooks(BookDB bookDb)
    {
        Console.Write("Are you sure you want to remove ALL books? (y/n): ");
        string answer = Console.ReadLine();
        if (answer.Trim().ToLower() == "y")
        {
            bookDb.RemoveAllBooks();
        }
        else
        {
            Console.WriteLine("Operation cancelled.");
        }
        //ui continue thing I thought might be better 
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
   //function to update book, that calls DB function to update book
    static void UpdateBook(BookDB bookDb)
    {
        Console.Write("Enter the Id of the book to update: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var book = new Book { Id = id };
            Console.Write("Enter new title: ");
            book.Title = Console.ReadLine();
            Console.Write("Enter new author: ");
            book.Author = Console.ReadLine();
            Console.Write("Enter new genre: ");
            book.Genre = Console.ReadLine();
            Console.Write("Enter new year: ");
            int.TryParse(Console.ReadLine(), out int year);
            book.Year = year;

            bookDb.UpdateBook(book);
        }
        else
        {
            Console.WriteLine("Invalid Id.");
        }
        //ui continue thing I thought might be better 
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    //function list books, that call lists books from DB class
    static void ListBooks(BookDB bookDb)
    {
        foreach (var book in bookDb.GetAllBooks())
        {
            Console.WriteLine(book);
        }
        //ui continue thing I thought might be better 
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}