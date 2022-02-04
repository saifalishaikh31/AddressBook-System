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
            Console.WriteLine("Created Contact :\n" + contacts.firstName
                            + "\n" + contacts.lastName
                            + "\n" + contacts.address
                            + "\n" + contacts.city
                            + "\n" + contacts.state
                            + "\n" + contacts.zipCode
                            + "\n" + contacts.phoneNunmber
                            + "\n" + contacts.eMail);
            addressBook.Add(contacts);
            Console.WriteLine("{0}'s Contact Successfully Added", contacts.firstName);
        }

        public void EditContact(string firstName)
        {
            Contacts contact = new Contacts();
            
            foreach (var data in addressBook)
            {
                if (data.firstName == firstName)
                {
                    contact = data;
                    Console.WriteLine("\n 1. First name\n 2. Last name\n 3. Address\n 4. City\n 5. State\n 6. Zipcode\n 7. Phone number\n 8. Email ID\n 9. Exit");
                    bool flag = true;
                    while (flag)
                    {

                        int option = Convert.ToInt32(Console.ReadLine());
                        switch (option)
                        {
                            case 1:
                                Console.WriteLine("Enter the First name");
                                contact.firstName = Convert.ToString(Console.ReadLine());
                                break;
                            case 2:
                                Console.WriteLine("Enter the Last name");
                                contact.lastName = Convert.ToString(Console.ReadLine());
                                break;
                            case 3:
                                Console.WriteLine("Enter the Address");
                                contact.address = Convert.ToString(Console.ReadLine());
                                break;
                            case 4:
                                Console.WriteLine("Enter the City");
                                contact.city = Convert.ToString(Console.ReadLine());
                                break;
                            case 5:
                                Console.WriteLine("Enter the State");
                                contact.state = Convert.ToString(Console.ReadLine());
                                break;
                            case 6:
                                Console.WriteLine("Enter the Zip Code");
                                contact.zipCode = Convert.ToString(Console.ReadLine());
                                break;
                            case 7:
                                Console.WriteLine("Enter the Phone Number");
                                contact.phoneNunmber = Convert.ToString(Console.ReadLine());
                                break;
                            case 8:
                                Console.WriteLine("Enter the Email");
                                contact.eMail = Convert.ToString(Console.ReadLine());
                                break;
                            case 9:
                                flag = false;
                                break;
                            default:
                                Console.WriteLine("Enter Correct option!!!");
                                break;
                        }
                        Display();
                        return;
                    }

                }
            }
        }

        public void DeleteContact(string firsName)
        {
            Contacts contact = new Contacts();
            foreach (var data in addressBook)
            {
                if (data.firstName == firsName)
                {
                    contact = data;                
                    addressBook.Remove(contact);
                    Console.WriteLine("{0}'s Contact Successfully Deleted", contact.firstName);
                    return;
                }
            }
        }
        public void Display()
        {
            foreach (var data in addressBook)
            {
                Console.WriteLine("Created Contact :\n" + data.firstName
                            + "\n" + data.lastName
                            + "\n" + data.address
                            + "\n" + data.city
                            + "\n" + data.state
                            + "\n" + data.zipCode
                            + "\n" + data.phoneNunmber
                            + "\n" + data.eMail);
            }
        }
    }
}
           
          
