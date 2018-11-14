using Library_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Project.Events
{
    public static class Delegates
    {
        public delegate void ReturnedBookInfoEventHandler(Librarian librarian, Book book, Person person, LibrarianBookReturningEventArgs e);
        public delegate void GivenBookInfoEventHandler(Librarian librarian, Book book, Person person, LibrarianBookGivingEventArgs e);
        public delegate void PersonReturningBookEventHandler(Person person, Book book, PersonBookReturningEventArgs e);
        public delegate void PersonRentingBookEventHandler(Person person, Book book, PersonBookRentingEventArgs e);


    }
}
