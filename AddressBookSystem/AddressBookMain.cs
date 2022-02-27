using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBookSystem
{
    class AddressBookMain
    {
        List<Contacts> addressBook = new List<Contacts>();
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
                                + "\n 6.Search by city or state"
                                + "\n 7.View by City or state"
                                + "\n 8.Exit.\n");
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
            Contacts contact = new Contacts();
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
    }
}
    





           
          
