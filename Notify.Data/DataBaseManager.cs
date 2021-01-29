using Microsoft.Data.Sqlite;
using System;

namespace Notify.Managers
{
    /*
     * Notes:
     * - Need to setup message limts to prevent the file getting to big
     *          - Idea is to have 30 days
     *          - Would run when after connecting
     *
     */

    internal class DataBaseManager
    {
        private static DateTime LastSave;
        private static SqliteConnection Connection;

        public DataBaseManager()
        {
            Connection = new SqliteConnection("Data Source=data.db");
            Connection.Open();
        }

        public static Contact InsertContact(Contact contact)
        {
            SqliteCommand command = Connection.CreateCommand();
            command.Prepare();
            return contact;
        }

        /*
         * sets up the data base like adding tables
         */

        private static void setup()
        {
            bool isNew = true;
            if (isNew)
            {
                SqliteCommand command = Connection.CreateCommand();
            }
        }

        public static void close()
        {
            Connection.Close();
        }
    }
}