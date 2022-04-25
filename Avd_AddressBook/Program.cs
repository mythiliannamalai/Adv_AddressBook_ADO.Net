using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
namespace Avd_AddressBook
{
    public class AddressBook
    {
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = Address_Book_Service; Integrated Security=SSPI;";
        static SqlConnection connection = new SqlConnection(connectionString);
        //UC-1 Check connection
        public static void EstablishConnection()
        {
            if (connection != null && connection.State.Equals(ConnectionState.Closed))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception)
                {
                    throw new AddressBookException(AddressBookException.ExceptionType.Connection_Failed, "Connection failed..");
                }
            }
            if (connection != null && connection.State.Equals(ConnectionState.Open))
            {
                try
                {
                    connection.Close();
                }
                catch (Exception)
                {
                    throw new AddressBookException(AddressBookException.ExceptionType.Connection_Failed, "Connection failed..");
                }
            }
        }
        public static List<ContactDetails> CreateAddressBook()
        {
            List<ContactDetails> contacts = new List<ContactDetails>();
            ContactDetails contactDetails = new ContactDetails();
            SqlConnection connection = new SqlConnection(connectionString);
            string spname = "dbo.Create_AddressBook";
            using (connection)
            {
                SqlCommand sqlCommand = new SqlCommand(spname, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                connection.Close();
                return contacts;
            }
        }
        static void Main(string[]args)
        {
            AddressBook.EstablishConnection();  
            AddressBook.CreateAddressBook();
        }
    }
}