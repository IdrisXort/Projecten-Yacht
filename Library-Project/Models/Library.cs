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
        public  List<Book> ListOfBooks { get; set; }
        public List<Book> BooksAvailable { get; set; }
        public List<Book> GivenBooks { get; set; }

        public Library(string libraryName)
        {
            Name = libraryName;
        }
        public void InitializeLibrary()
        {
            Console.WriteLine($"Wellcome to the Library of { Name}");
            Console.WriteLine("The List of Books...");
            Factory factory = new Factory();
           ListOfBooks= factory.CreateBooks();
            foreach (var book in ListOfBooks)
            {
                //Console.WriteLine("books title {0}", book.Title);
                Console.WriteLine($"books title {book.Title}");
            }
        }
    }
}
