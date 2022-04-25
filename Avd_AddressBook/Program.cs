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
        public static void Add_Contact()
        {           
            List<ContactDetails> contacts = new List<ContactDetails>();
            ContactDetails contactDetails = new ContactDetails();
            Console.WriteLine("First Name :");
            contactDetails.FirstName=Console.ReadLine();
            Console.WriteLine("Last Name :");
            contactDetails.LastName=Console.ReadLine();
            Console.WriteLine("Address :");
            contactDetails.Address=Console.ReadLine();
            Console.WriteLine("City :");
            contactDetails.City=Console.ReadLine();
            Console.WriteLine("State :");
            contactDetails.State=Console.ReadLine();
            Console.WriteLine("Zip code :");
            contactDetails.Zipcode=Console.ReadLine();
            Console.WriteLine("Phone Number :");
            contactDetails.PhoneNumber=Console.ReadLine();
            Console.WriteLine("Email Id :");
            contactDetails.EmailId=Console.ReadLine();
            SqlConnection connection = new SqlConnection(connectionString);
            string spname = "dbo.Add_Contacte";
            using (connection)
            {
                SqlCommand sqlCommand = new SqlCommand(spname, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@FirstName", contactDetails.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", contactDetails.LastName);
                sqlCommand.Parameters.AddWithValue("@Address", contactDetails.Address);
                sqlCommand.Parameters.AddWithValue("@City", contactDetails.City);
                sqlCommand.Parameters.AddWithValue("@State", contactDetails.State);
                sqlCommand.Parameters.AddWithValue("@Zipcode", contactDetails.Zipcode);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", contactDetails.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@EmailId", contactDetails.EmailId);
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                Console.WriteLine(contactDetails.FirstName + "," + contactDetails.LastName + "," + contactDetails.Address + ","
                    + contactDetails.City + "," + contactDetails.State + "," + contactDetails.Zipcode, ","
                    + contactDetails.PhoneNumber + "," + contactDetails.EmailId);
            
                   connection.Close();                
            }
        }
        static void Main(string[]args)
        {
            AddressBook.EstablishConnection();  
            AddressBook.CreateAddressBook();
            AddressBook.Add_Contact();
        }
    }
}

