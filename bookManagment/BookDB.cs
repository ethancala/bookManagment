using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace bookManagment
{
    public class BookDB
    {
        private readonly string _connectionString;

        public BookDB(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddBook(Book book)
        {
            const string query = @"INSERT INTO Books (Title, Author, Genre, Year) VALUES (@title, @author, @genre, @year)";
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@title", book.Title);
                command.Parameters.AddWithValue("@author", book.Author);
                command.Parameters.AddWithValue("@genre", book.Genre);
                command.Parameters.AddWithValue("@year", book.Year);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void RemoveAllBooks()
        {
            const string query = "DELETE FROM Books";
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} book(s) removed from the database.");
            }
        }

        public void RemoveBook(int id)
        {
            const string query = "DELETE FROM Books WHERE Id = @id";
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    Console.WriteLine("No book found with that Id.");
                }
                else
                {
                    Console.WriteLine("Book removed successfully.");
                }
            }
        }
        public void UpdateBook(Book book)
        {
            const string query = @"UPDATE Books
                          SET Title = @title,
                              Author = @author,
                              Genre = @genre,
                              Year = @year
                          WHERE Id = @id";
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@title", book.Title);
                command.Parameters.AddWithValue("@author", book.Author);
                command.Parameters.AddWithValue("@genre", book.Genre);
                command.Parameters.AddWithValue("@year", book.Year);
                command.Parameters.AddWithValue("@id", book.Id);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    Console.WriteLine("No book found with that Id.");
                }
                else
                {
                    Console.WriteLine("Book updated successfully.");
                }
            }
        }

        public List<Book> GetAllBooks()
        {
            var books = new List<Book>();
            const string query = "SELECT * FROM Books";
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    books.Add(new Book
                    {
                        Id = (int)reader["Id"],
                        Title = reader["Title"].ToString(),
                        Author = reader["Author"].ToString(),
                        Genre = reader["Genre"].ToString(),
                        Year = (int)reader["Year"]
                    });
                }
            }
            return books;
        }

        // TODO: Implement UpdateBook, RemoveBook, RemoveAllBooks methods
    }
}