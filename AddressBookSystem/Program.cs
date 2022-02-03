using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBookSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program");
            Contacts contact = new Contacts();
            Console.Write("Enter First Name : ");
            contact.firstName = Console.ReadLine();
            Console.Write("Enter Last Name : ");
            contact.lastName = Console.ReadLine();
            Console.Write("Enter Address : ");
            contact.address = Console.ReadLine();
            Console.Write("Enter City : ");
            contact.city = Console.ReadLine();
            Console.Write("Enter State : ");
            contact.state = Console.ReadLine();
            Console.Write("Enter Zip Code : ");
            contact.zipCode = Console.ReadLine();
            Console.Write("Enter Phone Number : ");
            contact.phoneNunmber = Console.ReadLine();
            Console.Write("Enter Email : ");
            contact.eMail = Console.ReadLine();

            Console.WriteLine("\n" + contact.firstName
                            + "\n" + contact.lastName
                            + "\n" + contact.address
                            + "\n" + contact.city
                            + "\n" + contact.state
                            + "\n" + contact.zipCode
                            + "\n" + contact.phoneNunmber
                            + "\n" + contact.eMail);
            Console.ReadKey();
        }
    }
}
