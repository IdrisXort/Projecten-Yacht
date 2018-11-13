using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Project.Models
{
    public class Librarian
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Book> BooksHeGave { get; set; }
        public List<Book> BookHeGotReturned { get; set; }
        
        public void GiveABookToSomeone(Book book, Person person)
        {

        }

        public void GetABookBackFromSomeone(Book book, Person person)
        {

        }
    }
}
