using System;
using System.Collections.Generic;

namespace Notify.Managers
{
    internal class MessageManager
    {
        private static List<Message> MessageList = new List<Message>();
        private static ContactsManager Contacts = null;

        public MessageManager(ContactsManager contact) => Contacts = contact;

        public static Message AddText(int number, string text, DateTime time = new DateTime(), string contact = "")
        {
        }
    }

    internal struct Message
    {
        public Contact contact;
        public string text;
        public DateTime sent;
    }
}