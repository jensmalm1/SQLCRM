using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SQLCRM
{


    class Customers
    {
        //public enum _Type
        //{
        //    Potential,
        //    New,
        //    Discount,
        //};

       public string Firstname { get; set; }
       public string Surname { get; set; }
       public string Email { get; set; }
       public int CustomerId { get; set; }
       public string Type { get; set; }
       public Phone PhoneNumbers { get; set; }

        public Customers(string type, string firstname, string surname,  string email, int customerId, Phone phone) 
        {
            Firstname = firstname;
            Surname = surname;
            Email = email;
            Type = type;
            CustomerId = customerId;
            PhoneNumbers = phone;

        }

        public override string ToString()
        {

            string ret = $"Firstname: {Firstname}\n";
            ret += $"Surname: {Surname}\n";
            ret += $"Email: {Email}\n";
            //ret += $"Telefonnummer: {Telefonnummer}\n";
            ret += $"CustomerId: {CustomerId}\n";
            return ret;
        }
    }
}
