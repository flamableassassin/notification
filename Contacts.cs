using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify
{
    internal class Contacts
    {
        private static List<Contact> ContactList = new List<Contact>();
    }

    internal struct Contact
    {
        public int number;
        public string name;
    }
}