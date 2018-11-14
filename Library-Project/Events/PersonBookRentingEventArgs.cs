using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Project.Events
{
   
        public class PersonBookRentingEventArgs : EventArgs
        {
            public PersonBookRentingEventArgs(string bookAskedForInfo)
            {
            BookAskedForInfo = bookAskedForInfo;
            }   

            public string BookAskedForInfo { get; }
        }
    
}
