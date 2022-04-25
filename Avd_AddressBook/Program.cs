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
        //UC-2 Create contact
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
        //UC-3 Add contact        
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
                contacts.Add(contactDetails);
                connection.Close();                
            }           
        }
        //UC-4 Edit contact
        public static void Edit_Contact()
        {
            List<ContactDetails> contacts = new List<ContactDetails>();
            ContactDetails contactDetails = new ContactDetails();

            SqlConnection connection = new SqlConnection(connectionString);
            string spname = "dbo.Edit_Contact";
            using (connection)
            {
                SqlCommand sqlCommand = new SqlCommand(spname, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                Console.WriteLine("Edit Contact");
                Console.WriteLine("--------------");
                Console.WriteLine("First Name :");
                contactDetails.FirstName = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@FirstName", contactDetails.FirstName);              
                        Console.WriteLine("Last Name :");
                        contactDetails.LastName = Console.ReadLine();
                        sqlCommand.Parameters.AddWithValue("@LastName", contactDetails.LastName);                        
                        Console.WriteLine("Address :");
                        contactDetails.Address = Console.ReadLine();
                        sqlCommand.Parameters.AddWithValue("@Address", contactDetails.Address);                        
                        Console.WriteLine("City :");
                        contactDetails.City = Console.ReadLine();
                        sqlCommand.Parameters.AddWithValue("@City", contactDetails.City);                        
                        Console.WriteLine("State :");
                        contactDetails.State = Console.ReadLine();
                        sqlCommand.Parameters.AddWithValue("@State", contactDetails.State);                        
                        Console.WriteLine("Zip code :");
                        contactDetails.Zipcode = Console.ReadLine();
                        sqlCommand.Parameters.AddWithValue("@Zipcode", contactDetails.Zipcode);                       
                        Console.WriteLine("Phone Number :");
                        contactDetails.PhoneNumber = Console.ReadLine();
                        sqlCommand.Parameters.AddWithValue("@PhoneNumber", contactDetails.PhoneNumber);                       
                        Console.WriteLine("Email Id :");
                        contactDetails.EmailId = Console.ReadLine();
                        sqlCommand.Parameters.AddWithValue("@EmailId", contactDetails.EmailId);              
                        connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            contactDetails.FirstName = (string)reader["FirstName"];
                            contactDetails.LastName = (string)reader["LastName"];
                            contactDetails.Address = (string)reader["Address"];
                            contactDetails.City = (string)reader["City"];
                            contactDetails.State = (string)reader["State"];
                            contactDetails.Zipcode = (string)reader["Zipcode"];
                            contactDetails.PhoneNumber = (string)reader["PhoneNumber"];
                            contactDetails.EmailId = (string)reader["EmailId"];
                            contacts.Add(contactDetails);
                            Console.WriteLine(contactDetails.FirstName + "," + contactDetails.LastName + "," + contactDetails.Address + ","
                                + contactDetails.City + "," + contactDetails.State + "," + contactDetails.Zipcode, ","
                               + contactDetails.PhoneNumber + "," + contactDetails.EmailId);                          
                        }
                        connection.Close();
                    }
                }
            }
        }
        //UC-5 delete contact
        public static void Delete_Contact()
        {
            List<ContactDetails> contacts = new List<ContactDetails>();
            ContactDetails contactDetails = new ContactDetails();

            SqlConnection connection = new SqlConnection(connectionString);
            string spname = "dbo.Delete_Contact";
            using (connection)
            {
                SqlCommand sqlCommand = new SqlCommand(spname, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                Console.WriteLine("Delete Contact");
                Console.WriteLine("--------------");
                Console.WriteLine("First Name :");
                contactDetails.FirstName = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@FirstName", contactDetails.FirstName);
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            contactDetails.FirstName = (string)reader["FirstName"];
                            contactDetails.LastName = (string)reader["LastName"];
                            contactDetails.Address = (string)reader["Address"];
                            contactDetails.City = (string)reader["City"];
                            contactDetails.State = (string)reader["State"];
                            contactDetails.Zipcode = (string)reader["Zipcode"];
                            contactDetails.PhoneNumber = (string)reader["PhoneNumber"];
                            contactDetails.EmailId = (string)reader["EmailId"];
                            contacts.Add(contactDetails);
                            Console.WriteLine(contactDetails.FirstName + "," + contactDetails.LastName + "," + contactDetails.Address + ","
                                + contactDetails.City + "," + contactDetails.State + "," + contactDetails.Zipcode, ","
                               + contactDetails.PhoneNumber + "," + contactDetails.EmailId);
                        }
                        connection.Close();
                    }
                }
            }
        }
        //UC-6 && 7 Retrive value base on city and state and count
        public static void GetDataFrom_City_OrState()
        {
            List<ContactDetails> contacts = new List<ContactDetails>();
            ContactDetails contactDetails = new ContactDetails();

            SqlConnection connection = new SqlConnection(connectionString);
            string spname = "dbo.GetAllData";
            using (connection)
            {
                SqlCommand sqlCommand = new SqlCommand(spname, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                Console.WriteLine("Retrive Contact based on city ot state");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("Enter City :");
                contactDetails.City = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@City", contactDetails.City);
                Console.WriteLine("Enter State :");
                contactDetails.State = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@State", contactDetails.State);
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            contactDetails.FirstName = (string)reader["FirstName"];
                            contactDetails.LastName = (string)reader["LastName"];
                            contactDetails.Address = (string)reader["Address"];
                            contactDetails.City = (string)reader["City"];
                            contactDetails.State = (string)reader["State"];
                            contactDetails.Zipcode = (string)reader["Zipcode"];
                            contactDetails.PhoneNumber = (string)reader["PhoneNumber"];
                            contactDetails.EmailId = (string)reader["EmailId"];
                            contacts.Add(contactDetails);                            
                            Console.WriteLine(contactDetails.FirstName + "," + contactDetails.LastName + "," + contactDetails.Address + ","
                                + contactDetails.City + "," + contactDetails.State + "," + contactDetails.Zipcode, ","
                               + contactDetails.PhoneNumber + "," + contactDetails.EmailId);
                            Console.WriteLine("Contact Count :");
                            Console.WriteLine(contacts.Count());
                        }
                        connection.Close();
                    }
                }
            }
        }
        static void Main(string[]args)
        {
            AddressBook.EstablishConnection();
            AddressBook.CreateAddressBook();
            AddressBook.Add_Contact();
            AddressBook.Edit_Contact();
            AddressBook.Delete_Contact();
            AddressBook.GetDataFrom_City_OrState();
        }
       
    }
}

