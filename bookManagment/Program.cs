using System;
using System.Collections.Generic;
using bookManagment;
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
        const string connectionString = "Server=Ethans-PC;Database=BookDB;Trusted_Connection=True;";

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
            
            Console.Write("\n$: ");
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
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    
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
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static void UpdateBook(BookDB bookDb)
    {
        Console.Write("Enter the Id of the book to update: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            // Optionally, you can fetch and display the current book info here
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
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
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