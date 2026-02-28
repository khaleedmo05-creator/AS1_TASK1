using System;
using System.Collections.Generic;

namespace Task3
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int ISBN { get; set; }
        public bool Available { get; set; }

        public Book(string title, string author, int isbn, bool available = true)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Available = available;
        }
    }

    class Library
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book newBook)
        {
            books.Add(newBook);
            Console.WriteLine($"Book '{newBook.Title}' added successfully.");
        }

        public Book? SearchBook(string search)
        {
            foreach (var book in books)
            {
                if (book.Title == search || book.Author == search)
                    return book;
            }
            return null;
        }

        public bool BorrowBook(int isbn)
        {
            foreach (var book in books)
            {
                if (book.ISBN == isbn && book.Available)
                {
                    book.Available = false;
                    return true;
                }
            }
            return false;
        }

        public bool ReturnBook(int isbn)
        {
            foreach (var book in books)
            {
                if (book.ISBN == isbn && !book.Available)
                {
                    book.Available = true;
                    return true;
                }
            }
            return false;
        }

        public void ShowBooks()
        {
            Console.WriteLine("\nLibrary Books:");
            foreach (var book in books)
            {
                Console.WriteLine(
                    $"Title: {book.Title}, Author: {book.Author}, " +
                    $"ISBN: {book.ISBN}, Available: {book.Available}");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            library.AddBook(new Book("A", "AA", 111));
            library.AddBook(new Book("B", "BB", 222));
            library.AddBook(new Book("C", "CC", 333));

            library.ShowBooks();

            Console.WriteLine("\nSearching for 'B'...");
            var foundBook = library.SearchBook("B");

            if (foundBook != null)
                Console.WriteLine($"Book Found: {foundBook.Title}");
            else
                Console.WriteLine("Book Not Found");

            Console.WriteLine("\nBorrow Book (ISBN 222):");
            Console.WriteLine(library.BorrowBook(222)
                ? "Book Borrowed Successfully"
                : "Borrow Failed");

            Console.WriteLine("\nBorrow Again:");
            Console.WriteLine(library.BorrowBook(222)
                ? "Book Borrowed Successfully"
                : "Borrow Failed");

            Console.WriteLine("\nReturn Book:");
            Console.WriteLine(library.ReturnBook(222)
                ? "Book Returned Successfully"
                : "Return Failed");

            library.ShowBooks();
        }
    }
}