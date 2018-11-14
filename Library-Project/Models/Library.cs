using Library_Project.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Project.Models
{
    internal class Library
    {

        public string Name { get; set; }
        public List<Book> ListOfBooks { get; set; }
        public List<Book> BooksAvailable { get; set; }
        public List<Book> GivenBooks { get; set; }
        public List<Person> ListofPeople { get; set; }
        public List<Librarian> Librarians { get; set; }

        public Library(string libraryName)
        {
            Name = libraryName;
        }
        public void InitializeLibrary()
        {
            Console.WriteLine($"Wellcome to the Library of { Name}");
            Console.WriteLine("The List of Books...");
            Factory factory = new Factory();
            ListOfBooks = factory.CreateBooks();
            ListofPeople = factory.CreatePeople();
            Librarians = factory.CreateLibrarians();
            Random random = new Random();
            while (true)
            {

                var renter = ListofPeople[random.Next(0, ListofPeople.Count)];
                var book = ListOfBooks[random.Next(0, ListOfBooks.Count)];

                var librarian = Librarians[random.Next(0, Librarians.Count)];
                librarian.OnGiveABook += Librarian_OnGiveABook;
                librarian.OnReturnOfABook += Librarian_OnReturnOfABook;
                renter.OnRentingABook += Person_OnRentingABook;
                renter.OnReturnOfABook += Renter_OnReturnOfABook;
                renter.AskForABook(book);
                librarian.GiveABook(book, renter);
                if (renter.BooksRentedFromLibrary.Contains(book))
                {
                    renter.AskForReturnOfABook(book);

                    if (librarian.IsAvailable)
                    {
                        librarian.ReturnABook(book, renter);
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(e.ReturnedBookInfo);
            Console.ResetColor();
        }

        private void Librarian_OnGiveABook(Librarian librarian, Book book, Person person, Events.LibrarianBookGivingEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(e.GivenBookInfo);
            Console.ResetColor();
        }

        private void Renter_OnReturnOfABook(Person person, Book book, Events.PersonBookReturningEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(e.ReturnedBookInfo);
            Console.ResetColor();
        }

        private void Person_OnRentingABook(Person person, Book book, Events.PersonBookRentingEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(e.BookAskedForInfo);
            Console.ResetColor();

        }
    }
}
