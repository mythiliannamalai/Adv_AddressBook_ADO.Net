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
        //UC-8 Retrive value base on city and Alphabetical orider
        public static void GetDataFrom_City_OrState_AlphabeticalOrder()
        {
            List<ContactDetails> contacts = new List<ContactDetails>();
            ContactDetails contactDetails = new ContactDetails();

            SqlConnection connection = new SqlConnection(connectionString);
            string spname = "dbo.GetDataIn_alphabeticalOrder";
            using (connection)
            {
                SqlCommand sqlCommand = new SqlCommand(spname, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                Console.WriteLine("Retrive Contact based on city ot state by Alphabetical order");
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("Enter City :");
                contactDetails.City = Console.ReadLine();
                sqlCommand.Parameters.AddWithValue("@City", contactDetails.City);                
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
        //UC-9 Alter table and add ContactType
        public static void AlterTable_CreateContactType()
        {
            List<ContactDetails> contacts = new List<ContactDetails>();
            ContactDetails contactDetails = new ContactDetails();
            SqlConnection connection = new SqlConnection(connectionString);
            string spname = "dbo.AddContactType";
            using (connection)
            {
                SqlCommand sqlCommand = new SqlCommand(spname, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                connection.Close();                
            }
        }
        //UC-10 Count by Contact type
        public static String CountContct()
        {
            int tempInt = 0;
            int tempInt1 = 0;
            int tempInt2 = 0;
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlComm = new SqlCommand("CountByContactType", sqlCon))
                {
                    sqlComm.CommandType = CommandType.StoredProcedure;

                    sqlComm.Parameters.Add("@Count", SqlDbType.Int);
                    sqlComm.Parameters.Add("@Count1", SqlDbType.Int);
                    sqlComm.Parameters.Add("@Count2", SqlDbType.Int);
                    sqlCon.Open();
                    sqlComm.ExecuteReader();
                    
                    tempInt = Convert.ToInt32(sqlComm.Parameters["@Count"]);
                    tempInt1 = Convert.ToInt32(sqlComm.Parameters["@Count1"]);
                    tempInt2 = Convert.ToInt32(sqlComm.Parameters["@Count2"]);
                    Console.WriteLine(tempInt);
                    Console.WriteLine(tempInt1);
                    Console.WriteLine(tempInt2);
                }
            }
            return tempInt.ToString();
        }
        //UC-11 Add contact in both contact
        public static void Add_Contact_Both_Contacttype()
        {
            List<ContactDetails> contacts = new List<ContactDetails>();
            ContactDetails contactDetails = new ContactDetails();
            Console.WriteLine("First Name :");
            contactDetails.FirstName = Console.ReadLine();
            Console.WriteLine("Last Name :");
            contactDetails.LastName = Console.ReadLine();
            Console.WriteLine("Address :");
            contactDetails.Address = Console.ReadLine();
            Console.WriteLine("City :");
            contactDetails.City = Console.ReadLine();
            Console.WriteLine("State :");
            contactDetails.State = Console.ReadLine();
            Console.WriteLine("Zip code :");
            contactDetails.Zipcode = Console.ReadLine();
            Console.WriteLine("Phone Number :");
            contactDetails.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Email Id :");
            contactDetails.EmailId = Console.ReadLine();
            SqlConnection connection = new SqlConnection(connectionString);
            string spname = "dbo.AddContact_Bothtype";
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
        static void Main(string[] args)
        {
            AddressBook book = new AddressBook();
            AddressBook.EstablishConnection();
            AddressBook.CreateAddressBook();
            AddressBook.AlterTable_CreateContactType();
            int val;
            do
            {
                Console.WriteLine("\n1.Add contact");
                Console.WriteLine("2.Edit contact");
                Console.WriteLine("3.Delete contact");
                Console.WriteLine("4.Get contact base on city and state");
                Console.WriteLine("5.Get contact base on city order by alphabetical order");
                Console.WriteLine("6.Contact type count");
                Console.WriteLine("7.Add Contact in Family and Friends type");
                Console.WriteLine("0.Exit");
                Console.WriteLine("Enter your choice");
                val = int.Parse(Console.ReadLine());           
                switch (val)
                {
                    case 1:
                        AddressBook.Add_Contact();
                        break;
                    case 2:
                        AddressBook.Edit_Contact();
                        break;
                    case 3:
                        AddressBook.Delete_Contact();
                        break;
                    case 4:
                        Console.WriteLine("\nGet contact base on city and state and count");
                        AddressBook.GetDataFrom_City_OrState();
                        break;
                     case 5:
                        Console.WriteLine("\nGet contact base on city by alphabetical order");
                        AddressBook.GetDataFrom_City_OrState_AlphabeticalOrder();
                        break;
                    case 6:                        
                        AddressBook.CountContct();
                        break;
                    case 7:
                        AddressBook.Add_Contact_Both_Contacttype();
                        break;
                    case 0:
                        Console.WriteLine("*****Exit*****");
                        break;                        
                }
            }while(val!=0);
        }       
    }
}

