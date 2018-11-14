using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Project.Events
{
   
        public class LibrarianBookReturningEventArgs : EventArgs
        {
            public LibrarianBookReturningEventArgs(string returnedBookInfo)
            {
            ReturnedBookInfo = returnedBookInfo;
            }   

            public string ReturnedBookInfo { get; }
        }
    
}
