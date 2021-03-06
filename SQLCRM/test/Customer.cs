﻿using System;
using System.Data.SqlClient;

namespace SQLCRM
{


    class Customer
    {
        //public enum _Type
        //{
        //    Potential,
        //    New,
        //    Discount,
        //};

        private string Firstname { get; set; }
        public string Surname { get; set; }
        private string Email { get; set; }
        public int CustomerId { get; set; }
        public string Type { get; set; }

        public Customer(string firstname, string efternamn, string email, string type, int customerId)
        {
            Firstname = firstname;
            Surname = efternamn;
            Email = email;
            Type = type;
            CustomerId = customerId;

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
