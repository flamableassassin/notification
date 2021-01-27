using Microsoft.Data.Sqlite;
using System;

namespace Notify.Managers
{
    internal class DataBaseManager
    {
        private static DateTime LastSave;

        public DataBaseManager()
        {
            using (var connection = new SqliteConnection("Data Source=data.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"CREATE TABLE Persons (
                    PersonID int,
                    LastName varchar(255),
                    FirstName varchar(255),
                    Address varchar(255),
                    City varchar(255)
                );";
                int num = command.ExecuteNonQuery();
                Console.WriteLine(num);
            }
        }
    }
}