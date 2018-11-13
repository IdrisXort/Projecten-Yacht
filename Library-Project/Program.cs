using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Project.Models;
using Newtonsoft.Json;

namespace Library_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library("Rotterdam");
            library.InitializeLibrary();
            
            
            Console.ReadKey();
        }
    }
}
