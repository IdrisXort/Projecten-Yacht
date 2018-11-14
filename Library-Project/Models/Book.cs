using Library_Project.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Project.Models
{
    public class Book
    {
        public bool IsAvailable { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int AmountInStock { get; set; }  
    }
}
