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
        Semaphore semaphore = new Semaphore(0, 20);

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
            semaphore.WaitOne(1000);
            if (this.BooksRentedFromLibrary.Count >= 3)
            {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Cant gat the book {book.Title} because its out of limit");
                Console.ResetColor();
            }
            if (book.AmountInStock <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{book.Title} is no longer Available");
                book.IsAvailable = false;
                Console.ResetColor();

            }

            OnRentingABook?.Invoke(this, book, new PersonBookRentingEventArgs($"{this.FirstName} wants to rent {book.Title}"));
        }
        public void AskForReturnOfABook(Book book)
        {
            semaphore.WaitOne(1000);

            OnReturnOfABook?.Invoke(this, book, new PersonBookReturningEventArgs($"{this.FirstName} wants to return {book.Title}"));
        }

    }

}
