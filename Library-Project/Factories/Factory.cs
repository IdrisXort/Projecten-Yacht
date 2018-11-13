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
       public List<Book> CreateBooks()
        {
             List<Book> listofBooks = new List<Book>();
           
            using (StreamReader r = new StreamReader("C:\\Users\\501071\\source\\repos\\Library-Project\\Library-Project\\Data\\Books.json"))
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

    }
}
