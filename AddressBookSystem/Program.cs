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
            AddressBookMain addressbook = new AddressBookMain();
            addressbook.AddContact();
            Console.ReadKey();
        }
    }
}
