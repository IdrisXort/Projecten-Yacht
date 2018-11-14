using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Project.Events
{
   
        public class PersonBookReturningEventArgs : EventArgs
        {
            public PersonBookReturningEventArgs(string returnedBookInfo)
            {
            ReturnedBookInfo = returnedBookInfo;
            }   

            public string ReturnedBookInfo { get; }
        }
    
}
