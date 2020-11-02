using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify
{
    internal class Messages
    {
        private static List<Message> MessageList = new List<Message>();
        private static List<Contact> ContactList = new List<Contact>();

        public Messages()
        {
            Console.WriteLine("hi");
        }

        public static void AddText(int number, string text, DateTime time = new DateTime(), string contact = "")
        {
            int contactIndex = ContactList.FindIndex(item => item.number == number);
            Contact newContact = new Contact() { number = number, name = contact };

            //checking to see if contact has a name and if it doesn't and a name came through add the name;
            if (contactIndex != -1 && ContactList[contactIndex].name == null && contact != "") ContactList[contactIndex] = newContact;

            Message msg = new Message() { text = text, contact = newContact, sent = time };
            MessageList.Add(msg);
        }
    }

    internal struct Message
    {
        public Contact contact;
        public string text;
        public DateTime sent;
    }
}