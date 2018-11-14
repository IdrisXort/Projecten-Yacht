using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Project.Events
{
    public class LibrarianBookGivingEventArgs : EventArgs
    {
        public LibrarianBookGivingEventArgs(string givenBookInfo)
        {
            GivenBookInfo = givenBookInfo;
        }

        public string GivenBookInfo { get; }
    }
}
