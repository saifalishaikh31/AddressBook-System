using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBookSystem
{
    class AddressBookMain
    {
        List<Contacts> addressBook = new List<Contacts>();
        public void AddContact()
        {
            Contacts contacts = new Contacts();
            Console.Write("Enter First Name : ");
            contacts.firstName = Console.ReadLine();
            Console.Write("Enter Last Name : ");
            contacts.lastName = Console.ReadLine();
            Console.Write("Enter Address : ");
            contacts.address = Console.ReadLine();
            Console.Write("Enter City : ");
            contacts.city = Console.ReadLine();
            Console.Write("Enter State : ");
            contacts.state = Console.ReadLine();
            Console.Write("Enter Zip Code : ");
            contacts.zipCode = Console.ReadLine();
            Console.Write("Enter Phone Number : ");
            contacts.phoneNunmber = Console.ReadLine();
            Console.Write("Enter Email : ");
            contacts.eMail = Console.ReadLine();
            Console.WriteLine("\n" + contacts.firstName
                            + "\n" + contacts.lastName
                            + "\n" + contacts.address
                            + "\n" + contacts.city
                            + "\n" + contacts.state
                            + "\n" + contacts.zipCode
                            + "\n" + contacts.phoneNunmber
                            + "\n" + contacts.eMail);
            addressBook.Add(contacts);
            Console.WriteLine("{0}'s Contact Successfully Added",contacts.firstName);
        }
    }
}
