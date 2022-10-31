using Store.Domain;
using System;
using System.Linq;

namespace Store.Infrastructure
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[] 
        {
            new Book(1, "ISBN 12312-31231", "D.Knuth", "Art of Programming"),
            new Book(2, "ISBN 12312-31232","MFlower","Refactoring"),
            new Book(3, "ISBN 12312-31233","B. Kernigan","C Programming Language"),
        };

        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(x => x.Isbn == isbn).ToArray();
        }

        public Book[] GetAllByTitleOrAuthor(string query)
        {
            return books.Where(book => book.Title.Contains(query)
                || book.Author.Contains(query))
                .ToArray();
        }
    }
}
