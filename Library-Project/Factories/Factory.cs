using Library_Project.Events;
using Library_Project.Models;
using Library_Project.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Project.Factories
{
    public class Factory
    {

        public  List<Book> CreateBooks()
        {
            List<Book> listofBooks = new List<Book>();

            using (StreamReader r = new StreamReader(@"D:\Projects\Projecten-Yacht\Library-Project\Data\Books.json"))
            {
                string json = r.ReadToEnd();
                List<Book> books = JsonConvert.DeserializeObject<List<Book>>(json);
                foreach (var book in books)
                {
                   listofBooks.Add(new Book() { Author = book.Author, Title = book.Title, AmountInStock = book.AmountInStock, Genre = book.Genre });
                }
            }
            return listofBooks;
        }

        public List<Person> CreatePeople()
        {
            List<Person> listofPeople = new List<Person>();

            using (StreamReader r = new StreamReader(@"D:\Projects\Projecten-Yacht\Library-Project\Data\People.json"))
            {
                string json = r.ReadToEnd();
                List<Person> people = JsonConvert.DeserializeObject<List<Person>>(json);
                foreach (var person in people)
                {
                    listofPeople.Add(new Person() {  Id=person.Id, FirstName=person.FirstName,LastName=person.LastName});
                }
            }
            return listofPeople;
        }
        public List<Librarian> CreateLibrarians()
        {
            List<Librarian> librarians = new List<Librarian>();
            librarians.Add(new Librarian() { Name = "Welat", Surname = "Xort", BooksGivenByLibrarian = new List<Book>(), BooksLibrarianGotReturned = new List<Book>() });
            librarians.Add(new Librarian() { Name = "Egit", Surname = "Serhildan", BooksGivenByLibrarian = new List<Book>(), BooksLibrarianGotReturned = new List<Book>() });
            librarians.Add(new Librarian() { Name = "Sipan", Surname = "Xelat", BooksGivenByLibrarian = new List<Book>(), BooksLibrarianGotReturned = new List<Book>() });
            librarians.Add(new Librarian() { Name = "Beritan", Surname = "Soran", BooksGivenByLibrarian = new List<Book>(), BooksLibrarianGotReturned = new List<Book>() });
            librarians.Add(new Librarian() { Name = "Delila", Surname = "Meyaser", BooksGivenByLibrarian = new List<Book>(), BooksLibrarianGotReturned = new List<Book>() });
            return librarians;
        }

      
    }
}
