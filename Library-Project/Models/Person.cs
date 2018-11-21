using Library_Project.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library_Project.Models
{
    public class Person
    {
        public event Delegates.PersonRentingBookEventHandler OnRentingABook;
        public event Delegates.PersonReturningBookEventHandler OnReturnOfABook;
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Book> BooksRentedFromLibrary { get; set; }
        public Person()
        {
            BooksRentedFromLibrary = new List<Book>();
        }
                
        public void AskForABook(Book book)
        { 
            OnRentingABook?.Invoke(this, book, new PersonBookRentingEventArgs($"{this.FirstName} wants to rent {book.Title}"));
        }
        public void AskForReturnOfABook(Book book)
        {
            
            OnReturnOfABook?.Invoke(this, book, new PersonBookReturningEventArgs($"{this.FirstName} wants to return {book.Title}"));
        }
        public void EnterTheLibrary(Library library)
        {
            library.ListofPeople.Add(this);
            Console.WriteLine($"{this.FirstName} entered the Library");
        }
        public void GetInQueue(Librarian librarian)
        {
            librarian.PeopleOnTheQueue.Add(this);
            Console.WriteLine($"{this.FirstName} is in the queue of {librarian.Name}");
        }


    }

}
