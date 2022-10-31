using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Store.Domain
{
    public class Book
    {
        public int Id { get; }
        public string Isbn { get; set; }
        public string Author { get; set; }
        public string Title { get; }
        public Book(int id, string isbn, string author, string title)
        {
            Id = id;
            Title = title;
            Author = author;
            Isbn = isbn;
        }

        internal static bool IsIsbn(string s)
        {
            if (s == null)
            {
                return false;
            }
            s = s.Replace("-", "")
                .Replace(" ", "")
                .ToUpper();

            return Regex.IsMatch(s,@"^ISBN\d{10}(\d{3})?$");
        }
    }
}
