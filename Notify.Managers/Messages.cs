using System;
using System.Collections.Generic;
using System.Linq;

namespace Notify.Managers
{
    internal class MessageManager
    {
        private static List<Message> MessageList = new List<Message>();
        private static ContactsManager Contacts = null;

        public MessageManager(ContactsManager contact) => Contacts = contact;

        public Message AddText(int number, string text, DateTime time = new DateTime(), string contact = "")
        {
            Contact usercontact = Contacts.Find(number, contact);
            Message msg = new Message() { contact = usercontact, sent = time, text = text };
            MessageList.Add(msg);
            return msg;
        }

        public List<Message> ContactMessages(Contact cont) => MessageList.Where(user => user.contact.Equals(cont)).ToList();

        public Message FindMessage(Message msg) => MessageList.Find(oldMsg => oldMsg.Equals(msg));
    }

    internal struct Message
    {
        public Contact contact;
        public string text;
        public DateTime sent;
    }
}