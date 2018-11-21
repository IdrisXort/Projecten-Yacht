using Library_Project.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library_Project.Models
{
    public class Library
    {
        public static Semaphore Jumper { get; set; }
        public string Name { get; set; }
        public List<Book> ListOfBooks { get; set; }
        public List<Book> BooksAvailable { get; set; }
        public List<Book> GivenBooks { get; set; }
        public List<Person> ListofPeople { get; set; }
        public List<Librarian> Librarians { get; set; }

        public Library(string libraryName)
        {
            Name = libraryName;
            Jumper = new Semaphore(3, 3);
        }
        Random random = new Random();

        public Person GetRandomPerson()
        {
            return ListofPeople[random.Next(0, ListofPeople.Count)];
        }
        public Book GetRandomBook()
        {
            return ListOfBooks[random.Next(0, ListOfBooks.Count)];
        }
        public Librarian GetRandomLibrarian()
        {
            return Librarians[random.Next(0, Librarians.Count)];
        }

        public void InitializeLibrary()
        {
            Console.WriteLine($"Wellcome to the Library of { Name}");
            Factory factory = new Factory();
            ListOfBooks = factory.CreateBooks();
            ListofPeople = factory.CreatePeople();
            Librarians = factory.CreateLibrarians();

            Console.WriteLine("Librarians :");
            foreach (var librarian in Librarians)
            {
                Console.Write($"{librarian.Name}  ");
            }
            Console.WriteLine("are ready for work");



            while (true)
            {

                var renter = GetRandomPerson();
                var book = GetRandomBook();
                var librarian = GetRandomLibrarian();

                renter.EnterTheLibrary(this);

                librarian.OnGiveABook += Librarian_OnGiveABook;
                librarian.OnReturnOfABook += Librarian_OnReturnOfABook;
                if (librarian.PeopleOnTheQueue == null) librarian.PeopleOnTheQueue = new List<Person>();
                librarian.IsAvailable = true;
                renter.OnRentingABook += Renter_OnRentingABook;
                renter.OnReturnOfABook += Renter_OnReturnOfABook;
                renter.GetInQueue(librarian);
                renter.AskForABook(book);
                foreach (var peopleWaitingInQueue in librarian.PeopleOnTheQueue)
                {
                    if (librarian.IsAvailable)
                    {
                        librarian.GiveABook(book, renter);
                        librarian.IsAvailable = true;

                    }

                }


                if (renter.BooksRentedFromLibrary.Contains(book))
                {
                    Jumper.WaitOne(200);
                    renter.AskForReturnOfABook(book);

                    if (librarian.IsAvailable)
                    {
                        librarian.ReturnABook(book, renter);
                        librarian.IsAvailable = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine($"{librarian.Name} is not available");

                        Console.ResetColor();
                    }

                }

            }

        }

        private void Librarian_OnReturnOfABook(Librarian librarian, Book book, Person person, Events.LibrarianBookReturningEventArgs e)
        {
            Jumper.WaitOne(1000);
            var returnedBook = ListOfBooks.Where(a => a == book).First();
            librarian.IsAvailable = false;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"there was {returnedBook.AmountInStock++} times {book.Title} and now there are {returnedBook.AmountInStock}  available in Library");
            Console.ResetColor();
            librarian.BooksLibrarianGotReturned.Add(book);
            person.BooksRentedFromLibrary.Remove(book);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(e.ReturnedBookInfo);
            Console.WriteLine($"Books {person.FirstName} has rented from library are :");
            foreach (var returnedbook in person.BooksRentedFromLibrary)
            {
                Console.WriteLine($"        -{returnedbook.Title}");
            }
            Console.ResetColor();
        }

        private void Librarian_OnGiveABook(Librarian librarian, Book book, Person person, Events.LibrarianBookGivingEventArgs e)
        {
            Jumper.WaitOne(1000);
            librarian.IsAvailable = false;

            var givenBook = ListOfBooks.Where(a => a == book).First();
            if (givenBook.AmountInStock > 0 && !person.BooksRentedFromLibrary.Contains(book))
            {

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"there are {givenBook.AmountInStock--}  {book.Title}  in Library");
                person.BooksRentedFromLibrary.Add(book);
                librarian.BooksGivenByLibrarian.Add(book);
                Console.WriteLine(e.GivenBookInfo);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"there are {givenBook.AmountInStock}  {book.Title} left in Library");


            }
            else
            {
                givenBook.IsAvailable = false;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{book.Title} is no longer available in Library");

            }
            librarian.IsAvailable = true;
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(e.GivenBookInfo);
            Console.WriteLine($"Books given by {librarian.Name} are: ");
            foreach (var givenBookByLibrarian in librarian.BooksGivenByLibrarian)
            {
                Console.WriteLine($"      -{givenBookByLibrarian.Title}");
            }
            Console.ResetColor();
        }

        private void Renter_OnReturnOfABook(Person person, Book book, Events.PersonBookReturningEventArgs e)
        {
            Jumper.WaitOne(1000);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(e.ReturnedBookInfo);
            Console.ResetColor();
        }

        private void Renter_OnRentingABook(Person person, Book book, Events.PersonBookRentingEventArgs e)
        {
            Jumper.WaitOne(1000);
            if (person.BooksRentedFromLibrary.Count >= 3)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Cant get the book {book.Title} because its out of limit");
                Console.ResetColor();
            }
            if (book.AmountInStock <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{book.Title} is no longer Available");
                book.IsAvailable = false;
                Console.ResetColor();

            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(e.BookAskedForInfo);
            Console.ResetColor();

        }
    }
}
