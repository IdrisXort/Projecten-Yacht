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
        Semaphore semaphore = new Semaphore(0, 20);
        public event Delegates.GivenBookInfoEventHandler OnGiveABook;
        public event Delegates.ReturnedBookInfoEventHandler OnReturnOfABook;
        public bool IsAvailable { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Book> BooksGivenByLibrarian { get; set; }
        public List<Book> BooksLibrarianGotReturned { get; set; }

        public void GiveABook(Book book, Person person)
        {
            semaphore.WaitOne(1000);
            this.IsAvailable = false;

            if (book.AmountInStock > 0)
            {

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"there are {book.AmountInStock}  {book.Title}  in Library");
                person.BooksRentedFromLibrary.Add(book);

                this.BooksGivenByLibrarian.Add(book);
                book.AmountInStock--;

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"there are {book.AmountInStock}  {book.Title} left in Library");

                OnGiveABook?.Invoke(this, book, person, new LibrarianBookGivingEventArgs($"{this.Name} gave {person.FirstName} the book: {book.Title} "));
                
            }
            else
            {
                book.IsAvailable = false;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{book.Title} is no longer available in Library");
                
            }
            this.IsAvailable = true;
            Console.ResetColor();
        }
        public void ReturnABook(Book book, Person person)
        {
            semaphore.WaitOne(1000);
            this.IsAvailable = false;

            this.BooksLibrarianGotReturned.Add(book);
            person.BooksRentedFromLibrary.Remove(book);
            OnReturnOfABook?.Invoke(this, book, person, new LibrarianBookReturningEventArgs($"{this.Name}  got the book: {book.Title} from {person.FirstName}"));
            this.IsAvailable = true;
            Console.ResetColor();
        }

    }
}
