using System.Collections;
using System.Collections.Generic;

namespace Notify.Managers
{
    internal class ContactsManager
    {
        private static List<Contact> ContactList = new List<Contact>();

        public int Length => ContactList.Count;

        public static Contact Find(int number, string name = "")
        {
            if (!ContactExists(number)) return CreateContact(number, name);
            else return ContactList.Find(item => item.number == number);
        }

        public static Contact CreateContact(int number, string name = "")
        {
            if (ContactExists(number)) return ContactList.Find(item => item.number == number);
            else
            {
                Contact user = new Contact()
                {
                    number = number,
                    name = name
                };
                return user;
            }
        }

        public static List<Contact> GetContacts() => ContactList;

        private static bool ContactExists(int number)
        {
            Contact user = ContactList.Find(item => item.number == number);
            return !(user.Equals(new Contact()));
        }
    }

    internal struct Contact
    {
        public int number;
        public string name;
    }
}