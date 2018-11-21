using Library_Project.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library_Project.Models
{
    public class Librarian
    {

        public event Delegates.GivenBookInfoEventHandler OnGiveABook;
        public event Delegates.ReturnedBookInfoEventHandler OnReturnOfABook;
        public bool IsAvailable { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Book> BooksGivenByLibrarian { get; set; }
        public List<Book> BooksLibrarianGotReturned { get; set; }
        public List<Person> PeopleOnTheQueue { get; set; }

        public void GiveABook(Book book, Person person)
        {
            this.IsAvailable = false;
            
            
            OnGiveABook?.Invoke(this, book, person, new LibrarianBookGivingEventArgs($"{this.Name} gave {person.FirstName} the book: {book.Title} "));
            
        }
        public void ReturnABook(Book book, Person person)
        {
            this.IsAvailable = false;
            OnReturnOfABook?.Invoke(this, book, person, new LibrarianBookReturningEventArgs($"{this.Name}  got the book: {book.Title} from {person.FirstName}"));
        }

    }
}
