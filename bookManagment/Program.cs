using System;
using System.Collections.Generic;
using bookManagment;

class Program
{
    static void Main(string[] args)
    {
        const string connectionString = @"Your-Connection-String-Here";
        var bookDb = new BookDB(connectionString);

        bool showMenu = true;
        while (showMenu)
        {
            Console.Clear();
            Console.WriteLine("BOOK DATABASE SYSTEM");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. List Books");
            Console.WriteLine("3. Update Book");
            Console.WriteLine("4. Remove Book");
            Console.WriteLine("5. Remove All Books");
            Console.WriteLine("6. Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    AddBook(bookDb);
                    break;
                case "2":
                    ListBooks(bookDb);
                    break;
                // TODO: Implement other cases
                case "6":
                    showMenu = false;
                    break;
            }
        }
    }

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

    static void ListBooks(BookDB bookDb)
    {
        foreach (var book in bookDb.GetAllBooks())
        {
            Console.WriteLine(book);
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}