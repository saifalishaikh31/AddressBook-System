using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace AddressBookSystem
{
    class AddressBookMain
    {
        public List<Contacts> addressBook = new List<Contacts>();
        public Dictionary<string, List<Contacts>> myAddressBook = new Dictionary<string, List<Contacts>>();

      
        public void AddAddressBook()
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\n1.Create New AddressBook"
                                 + "\n2.Existing AddressBook"
                                 + "\n3.Exit");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        AddressBookNewNameValidator();
                        break;
                    case 2:
                        AddressBookExistingNameValidator();
                        break;
                    case 3:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Choose Correct Option!!!");
                        break;
                }
            }
        }

        public void AddressBookNewNameValidator()
        {
            Console.WriteLine("Enter the new addressbook name\n");
            string addressBookName = Console.ReadLine();
            if (myAddressBook.ContainsKey(addressBookName))
            {
                Console.WriteLine("Please enter a new addressbook name. The name entered already exist");
                AddressBookNewNameValidator();

            }
            else
            {
                CallContacts(addressBookName);
            }
        }

        public void AddressBookExistingNameValidator()
        {
            Console.WriteLine("Enter into the Existing addressbook name\n");
            string addressBookName = Console.ReadLine();
            if (!myAddressBook.ContainsKey(addressBookName))
            {
                Console.WriteLine("Please enter a new addressbook name. The name entered already exist");
                AddressBookExistingNameValidator();
            }
            if (myAddressBook.ContainsKey(addressBookName))
            {
                CallContacts(addressBookName);
            }
            else
            {
                Console.WriteLine("AddressBook Does'nt Exist!!!");
            }
        }

        public void CallContacts(string addressBookName)
        {
            myAddressBook[addressBookName] = new List<Contacts>();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\n 1.Add Contact."
                                + "\n 2.Edit Contact."
                                + "\n 3.Delete Contact."
                                + "\n 4.Display Contact."
                                + "\n 5.Go To Main."
                                + "\n 6.Search by city or state."
                                + "\n 7.View by City or state."
                                + "\n 8.Count Person by City or state."
                                + "\n 9.Sort by Person FirstName."
                                + "\n 10.Sort by City / State / ZipCode."
                                + "\n 11.Write to File/"
                                + "\n 12.Read from File/"
                                + "\n 13.Write to CSV File."
                                + "\n 14.Read from CSV File."
                                + "\n 15.Write to JSON File"
                                + "\n 16.Read from JSON File"
                                + "\n 17.Exit.\n");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        AddContact(addressBookName);
                        break;
                    case 2:
                        EditContact(addressBookName);
                        break;
                    case 3:
                        DeleteContact(addressBookName);
                        break;
                    case 4:
                        Display(addressBookName);
                        break;
                    case 5:
                        AddAddressBook();
                        break;
                    case 6:
                        //    Console.WriteLine("Enter address book Name");
                        //    string addBookName = Console.ReadLine();
                        Console.WriteLine("Enter city or state to search contact");
                        string cityOrState = Console.ReadLine();
                        //SearchPersonByCityOrState(addBookName, cityOrState);
                        SearchPersonByCityOrState(addressBookName, cityOrState);
                        break;
                    case 7:
                        ViewPersonByCityOrState(addressBookName);
                        break;
                    case 8:
                        CountPersonByCityOrState(addressBookName);
                        break;
                    case 9:
                        SortByName(addressBookName);
                        break;
                    case 10:
                        SortByCityStateZipCode(addressBookName);
                        break;
                    case 11:
                        WriteToFile(addressBookName);
                        break;
                    case 12:
                        ReadFile(addressBookName);
                        break;
                    case 13:
                        WriteCsvFile();
                        break;
                    case 14:
                        ReadCsvFile();
                        break;
                    case 15:
                        WriteJsonFile();
                        break;
                    case 16:
                        ReadJsonFile();
                        break;
                    case 17:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Enter Correct Option!!!");
                        break;
                }
            }
        }




        public void AddContact(string addressBookName)
        {
            Console.Write("How many person's contact details do you want to add? : ");
            int personNum = Convert.ToInt32(Console.ReadLine());
            while (personNum > 0)
            {
                Contacts contacts = new Contacts();
                Console.Write("Enter First Name   : ");
                contacts.firstName = Console.ReadLine();
                Console.Write("Enter Last Name    : ");
                contacts.lastName = Console.ReadLine();
                Console.Write("Enter Address      : ");
                contacts.address = Console.ReadLine();
                Console.Write("Enter City         : ");
                contacts.city = Console.ReadLine();
                Console.Write("Enter State        : ");
                contacts.state = Console.ReadLine();
                Console.Write("Enter Zip Code     : ");
                contacts.zipCode = Console.ReadLine();
                Console.Write("Enter Phone Number : ");
                contacts.phoneNunmber = Console.ReadLine();
                Console.Write("Enter Email        : ");
                contacts.eMail = Console.ReadLine();

                var res = myAddressBook[addressBookName].Find(p => p.firstName.Equals(contacts.firstName) && p.lastName.Equals(contacts.lastName));
                if (res != null)
                {
                    Console.WriteLine("Duplicate contacts not allowed");
                }
                else
                {

                    Console.WriteLine("\nCreated Contact :"
                                    + "\n" + contacts.firstName
                                    + "\n" + contacts.lastName
                                    + "\n" + contacts.address
                                    + "\n" + contacts.city
                                    + "\n" + contacts.state
                                    + "\n" + contacts.zipCode
                                    + "\n" + contacts.phoneNunmber
                                    + "\n" + contacts.eMail);
                    myAddressBook[addressBookName].Add(contacts);
                    Console.WriteLine("{0} {1}'s Contact Successfully Added to AddressBook : {2}", contacts.firstName, contacts.lastName, addressBookName);
                    personNum--;
                }
            }
        }

        public void EditContact(string addressBookName)
        {
            Contacts contact = new Contacts();
            if (myAddressBook[addressBookName].Count <= 0)
            {
                Console.WriteLine("Your Address Book is empty");
                return;
            }
            foreach (var data in myAddressBook[addressBookName])
            {
                Console.Write("Enter First Name To Edit Contact : ");
                string firstName = Convert.ToString(Console.ReadLine());
                if (data.firstName == firstName)
                {
                    contact = data;
                    Console.WriteLine("\n 1. Last name\n 2. Address\n 3. City\n 4. State\n 5. Zipcode\n 6. Phone number\n 7. Email ID\n 8. Exit");
                    bool flag = true;
                    while (flag)
                    {

                        int option = Convert.ToInt32(Console.ReadLine());
                        switch (option)
                        {
                            case 1:
                                Console.Write("Enter the Last name : ");
                                contact.lastName = Convert.ToString(Console.ReadLine());
                                break;
                            case 2:
                                Console.Write("Enter the Address : ");
                                contact.address = Convert.ToString(Console.ReadLine());
                                break;
                            case 3:
                                Console.Write("Enter the City : ");
                                contact.city = Convert.ToString(Console.ReadLine());
                                break;
                            case 4:
                                Console.Write("Enter the State : ");
                                contact.state = Convert.ToString(Console.ReadLine());
                                break;
                            case 5:
                                Console.Write("Enter the Zip Code : ");
                                contact.zipCode = Convert.ToString(Console.ReadLine());
                                break;
                            case 6:
                                Console.Write("Enter the Phone Number : ");
                                contact.phoneNunmber = Convert.ToString(Console.ReadLine());
                                break;
                            case 7:
                                Console.Write("Enter the Email : ");
                                contact.eMail = Convert.ToString(Console.ReadLine());
                                break;
                            case 8:
                                flag = false;
                                break;
                            default:
                                Console.WriteLine("Enter Correct option!!!");
                                break;
                        }
                        Console.WriteLine("{0}'s Contact Edited Successfully to AddressBook : {1} ", firstName, addressBookName);
                        return;
                    }

                }
                else
                {
                    Console.WriteLine("Contact of the person {0} does not exist : ", firstName);
                }
            }
        }

        public void DeleteContact(string addressBookName)
        {
            Contacts contact = new Contacts();
            if (myAddressBook[addressBookName].Count <= 0)
            {
                Console.WriteLine("Your Address Book is empty");
                return;
            }
            else
            {
                Console.Write("Enter First Name To Delete : ");
                string firstName = Convert.ToString(Console.ReadLine());
                foreach (var data in myAddressBook[addressBookName])
                {
                    if (data.firstName == firstName)
                    {
                        myAddressBook[addressBookName].Remove(data);
                        Console.WriteLine("{0}'s Contact Successfully Deleted from AddressBook : {1} ", firstName, addressBookName);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Contact of the person {0} does not exist : ", firstName);
                    }
                }
            }
        }
        public void Display(string addressBookName)
        {
            Contacts contact = new Contacts();
            if (myAddressBook[addressBookName].Count > 0)
            {
                foreach (var data in myAddressBook[addressBookName])
                {
                    Console.Write("Enter First Name of the Person to display all details of the contact : ");
                    string firstName = Convert.ToString(Console.ReadLine());
                    bool flag = false;
                    if (data.firstName == firstName)
                    {
                        flag = true;
                        Console.WriteLine("Displaying contact from AddressBook : {0}", addressBookName
                                        + "\nFirst Name   : " + data.firstName
                                        + "\nLast Name    : " + data.lastName
                                        + "\nAddress      : " + data.address
                                        + "\nCity         : " + data.city
                                        + "\nState        : " + data.state
                                        + "\nZip Code     : " + data.zipCode
                                        + "\nPhone Number : " + data.phoneNunmber
                                        + "\nEmail        : " + data.eMail);
                    }
                    if (flag == false)
                    {
                        Console.WriteLine("\nEntered Name Does'nt Exist!!!");
                    }
                }
            }
            else
            {
                Console.WriteLine("Address Book is empty!!!");
            }
        }
        public void SearchPersonByCityOrState(string addressBookName, string userData)
        {
            var searchResut = myAddressBook[addressBookName].FindAll(x => x.city == userData || x.state == userData);
            if (searchResut.Count != 0)
            {
                foreach (var item in searchResut)
                {
                    Console.WriteLine("First Name :" + item.firstName);
                }
            }
            else
            {
                Console.WriteLine("No person found for this city or state");
            }
        }

        public void ViewPersonByCityOrState(string addressBookName)
        {
            if (myAddressBook[addressBookName].Count <= 0)
            {
                Console.WriteLine("Your Address Book is empty");
                return;
            }
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Choose an option \n1. View Person by city \n2. View Person by state \n3.Exit");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter the city");
                        string city = Console.ReadLine();
                        var searchCity = myAddressBook[addressBookName].FindAll(x => x.city == city);
                        if (searchCity.Count != 0)
                        {
                            foreach (var item in searchCity)
                            {
                                Console.WriteLine("First Name :" + item.firstName);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No person found for this city");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter the state");
                        string state = Console.ReadLine();
                        var searchState = myAddressBook[addressBookName].FindAll(x => x.state == state);
                        if (searchState.Count != 0)
                        {
                            foreach (var item in searchState)
                            {
                                Console.WriteLine("First Name :" + item.firstName);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No person found for this state");
                        }
                        break;
                    case 3:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Choose correct option");
                        break;
                }
            }
        }

        public void CountPersonByCityOrState(string addressBookName)
        {
            if (myAddressBook[addressBookName].Count <= 0)
            {
                Console.WriteLine("Your Address Book is empty");
                return;
            }
            bool flag = true;
            while (flag)
            {
            Console.WriteLine("Choose an option \n1. Person count by city \n2. Person count by state \n3. Exit");
            int option = Convert.ToInt32(Console.ReadLine());
            int countCity=0, countState=0;
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter the city");
                        string city = Console.ReadLine();
                        var searchCity = myAddressBook[addressBookName].FindAll(x => x.city == city);
                        foreach (var book in searchCity)
                        {
                           countCity = searchCity.Count;
                        }
                        Console.WriteLine("Person count by city : " + countCity);
                        break;
                    case 2:
                        Console.WriteLine("Enter the state");
                        string state = Console.ReadLine();
                        var searchState = myAddressBook[addressBookName].FindAll(x => x.state == state);
                        foreach (var book in searchState)
                        {
                            countState = searchState.Count;
                        }
                        Console.WriteLine("Person count by state : " + countState);
                        break;
                    case 3:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Choose correct option");
                        break;
                }
            }
        }
        public void SortByName(string addressBookName)
        {
            foreach (var person in myAddressBook[addressBookName].OrderBy(x => x.firstName))
            {
                // Console.WriteLine("FirstName : " + person.firstName + "LastName : " + person.lastName);
                Console.WriteLine(person.ToString());
            }
        }

        public void SortByCityStateZipCode(string addressBookName)
        {
            if (myAddressBook[addressBookName].Count <= 0)
            {
                Console.WriteLine("Your Address Book is empty");
                return;
            }
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\nChoose an option \n1. Order by city \n2. Order by state \n3. Order by Zip \n4. Exit");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        foreach (var person in myAddressBook[addressBookName].OrderBy(x => x.city))
                        {
                            Console.WriteLine(person.ToString());
                        }
                        break;
                    case 2:
                        foreach (var person in myAddressBook[addressBookName].OrderBy(x => x.state))
                        {
                            Console.WriteLine(person.ToString());
                        }
                        break;
                    case 3:
                        foreach (var person in myAddressBook[addressBookName].OrderBy(x => x.zipCode))
                        {
                            Console.WriteLine(person.ToString());
                        }
                        break;
                    case 4:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Entry");
                        SortByCityStateZipCode(addressBookName);
                        break;
                }
            }

        }

        public void WriteToFile(string addressBookName)
        {
            foreach (var item in myAddressBook[addressBookName])
            {
                string path = @"D:\BridgeLabz\AddressBook-System\AddressBookSystem\FileIO.txt";
                if (File.Exists(path))
                {
                    StreamWriter sw = File.AppendText(path);
                    sw.WriteLine("AddressBook Name: " + addressBookName);
                    foreach (var person in myAddressBook[addressBookName])
                    {
                        sw.WriteLine(person.ToString());
                    }
                    sw.Close();
                    Console.WriteLine(File.ReadAllText(path));
                }
            }
        }
        public void ReadFile(string addressBookName)
        {
            string path = @"D:\BridgeLabz\AddressBook-System\AddressBookSystem\FileIO.txt";
            if (File.Exists(path))
            {
                StreamReader sr = File.OpenText(path);
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
                sr.Close();
            }
        }
        public void WriteCsvFile()
        {
            string csvPath = @"D:\BridgeLabz\AddressBook-System\AddressBookSystem\CSVAddressBook.csv";
            StreamWriter sw = new StreamWriter(csvPath);
            CsvWriter cw = new CsvWriter(sw, CultureInfo.InvariantCulture);

            foreach (var book in myAddressBook.Values)
            {
                cw.WriteRecords<Contacts>(book);
            }
            Console.WriteLine("Write the addressBook with person contact as CSV file is Successfull");
            sw.Flush();
            sw.Close();
        }
        public void ReadCsvFile()
        {
            string csvPath = @"D:\BridgeLabz\AddressBook-System\AddressBookSystem\CSVAddressBook.csv";
            StreamReader sr = new StreamReader(csvPath);
            CsvReader cr = new CsvReader(sr, CultureInfo.InvariantCulture);
            List<Contacts> readResult = cr.GetRecords<Contacts>().ToList();
            Console.WriteLine("Reading from CSV file");
            foreach (var item in readResult)
            {
                Console.WriteLine(item.ToString());
            }
            sr.Close();
        }
        public void WriteJsonFile()
        {
            string jsonPath = @"D:\BridgeLabz\AddressBook-System\AddressBookSystem\JSONAddressBook.json";
            foreach (var item in myAddressBook.Values)
            {
                string jsonData = JsonConvert.SerializeObject(item);
                File.WriteAllText(jsonPath, jsonData);
            }
            Console.WriteLine("Write the addressBook with person contact as JSON file is Successfull");
        }
        public void ReadJsonFile()
        {
            string jsonPath = @"D:\BridgeLabz\AddressBook-System\AddressBookSystem\JSONAddressBook.json";
            string jsonData = File.ReadAllText(jsonPath);
            var jsonResult = JsonConvert.DeserializeObject<List<Contacts>>(jsonData).ToList();
            Console.WriteLine("Reading from Json file");
            foreach (var item in jsonResult)
            {
                Console.WriteLine(item);
            }
        }
    }
}