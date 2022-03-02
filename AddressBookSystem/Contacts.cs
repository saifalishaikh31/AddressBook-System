using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AddressBookSystem
{
    class Contacts
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }
        public string phoneNunmber { get; set; }
        public string eMail { get; set; }

        public Contacts()
        { }
        public Contacts(string FirstName, string LastName, string Address, string City, string State, string ZipCode, string PhoneNumber, string Email)
        {
            this.firstName = FirstName;
            this.lastName = LastName;
            this.address = Address;
            this.city = City;
            this.state = State;
            this.zipCode = ZipCode;
            this.phoneNunmber = PhoneNumber;
            this.eMail = Email;
        }
        public override string ToString()
        {
           // return $"{firstName} {lastName} {address} {city} {state} {zipCode} {phoneNunmber} {eMail}";
            return "\nFirstName     : " + firstName + 
                   "\nLastName      : " + lastName +
                   "\nAddress       : " + address +
                   "\nCity          : " + city +
                   "\nState         : " + state +
                   "\nZipCode       : " + zipCode +
                   "\nPhoneNumber   : " + phoneNunmber +
                   "\nEmail         : " + eMail;
        }
    }
}
