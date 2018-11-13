using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Project.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Book> Books { get; set; }
        public Person(string personName)
        {
            Name = personName;

        }

    }

}
