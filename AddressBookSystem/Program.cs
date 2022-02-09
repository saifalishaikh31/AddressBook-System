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
            string s1 = "Welcome to Address Book Program";
            Console.SetCursorPosition((Console.WindowWidth - s1.Length) / 2, Console.CursorTop);
            Console.WriteLine(s1);
            string s2 = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";
            Console.SetCursorPosition((Console.WindowWidth - s2.Length) / 2, Console.CursorTop);
            Console.WriteLine(s2);
            AddressBookMain addressbook = new AddressBookMain();
            addressbook.AddAddressBook();
            Console.ReadKey();
        }
    }
}
