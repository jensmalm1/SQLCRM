using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data.SqlClient;
using System.Linq;
using SQLCRM;


namespace SQLCRM
{
}
    class Program
    {
        private static string Constring;
        static void Main(string[] args)
        {
            Constring= @"Server = (localdb)\mssqllocaldb; Database = Kundregister; Trusted_Connection = True";
            bool cont = true;
            while (cont)
            {
                UserChoice();
            }
        }
        static void UserChoice()
        {
            while (true)
            {
                Console.WriteLine(
                    $"\n{"|",0}What do you want to do?|\n\n{"",1}Type Quit to quit\n1.Add new Customer \n2.Add Phones to existing customer\n3.Edit Customer \n4.Delete Customer \n5.Show Phones \n6.Show Customers \n else show all");
                string input = Console.ReadLine();
                if (input != "Quit")
                {
                    int caseSwitch = Int32.Parse(input);
                    switch (caseSwitch)
                    {
                        case 1:
                            AddCustomer();
                            break;
                        case 2:
                            AddPhone();
                            break;
                        case 3:
                            EditCustomer();
                            break;
                        case 4:
                            DeleteCustomer();
                            break;
                        case 5:
                            PrintPhones();
                            break;
                        case 6:
                            PrintCustomers();
                            break;
                    default:
                            PrintAll();
                            break;
                    }
                }
                break;
            }
        }

        static void PrintCustomers()
        {
            var customerList = GetCustomersFromDB();
            customerList.ForEach(item => Console.WriteLine(item.ToString()));
        }

        static void PrintPhones()
        {
            var phoneList = GetPhoneFromDB();
            phoneList.ForEach(item => Console.WriteLine(item.ToString()));
        }

        static void PrintAll()
        {

            var allList = GetAllFromDB();

            allList.ForEach(item => Console.WriteLine(item));
        }
    static List<string> GetAllFromDB()
        {
            var list=new List<string>();
            string sql = "select Firstname,Surname,Email,Type,HomePhone,MobilePhone,WorkingPhone,EmergencyContactPhone from Phones Inner join Customer on Phones.CustomerID = Customer.CustomerID";

            using (SqlConnection connection = new SqlConnection(Constring))
            using (SqlCommand command =new SqlCommand(sql,connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    
                    var Firstname = reader.GetString(0);
                    var Surname = reader.GetString(1);
                    var Email = reader.GetString(2);
                    var Type = reader.GetString(3);
                    var HomePhone = reader.GetString(4);
                    var MobilePhone = reader.GetString(5);
                    var WorkingPhone = reader.GetString(6);
                    var EmergencyContactPhone = reader.GetString(4);

                list.Add($"{"",-5}{Firstname}{"|",5}, {Surname}, {Email}, {Type},{HomePhone}, {MobilePhone},{WorkingPhone},{EmergencyContactPhone}");

                }
            }

            return list;
       }
       public static List<Phone> GetPhoneFromDB()
        {
            var phoneList = new List<Phone>();
            string sql = "SELECT * from Phones";

            using (SqlConnection connection = new SqlConnection(Constring))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                   
                    var HomePhone = reader.GetString(1);
                    var MobilePhone = reader.GetString(2);
                    var WorkingPhone = reader.GetString(3);
                    var EmergencyContactPhone = reader.GetString(4);
                    var CustomerId = reader.GetInt32(5);

                phoneList.Add(new Phone( HomePhone, MobilePhone, WorkingPhone, EmergencyContactPhone, CustomerId));

                }
            }

            return phoneList;
        }
        static List<Customers> GetCustomersFromDB()
        {
            var list = new List<Customers>();
            string sql = "SELECT * from Customer";

            using (SqlConnection connection = new SqlConnection(Constring))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
        
                while (reader.Read())
                {
                    var Type = reader.GetString(0);
                    var Firstname = reader.GetString(1);
                    var Surname = reader.GetString(2);
                    var Email = reader.GetString(3);
                    var CustomerId = reader.GetInt32(4);
                    Phone CustPhoneNumbers;

                    foreach (Phone phone in GetPhoneFromDB())
                    {
                       
                        if (CustomerId == phone.CustomerId)
                        {
                          CustPhoneNumbers = phone;
                        }
                        else
                        {
                        CustPhoneNumbers = new Phone(null,null,null,null,CustomerId);
                    }
                        list.Add(new Customers(Type, Firstname, Surname, Email, CustomerId, CustPhoneNumbers));
                }
            }
            }

            return list;
        }

    public static void AddPhone()
        {
            Console.WriteLine("Give Home-Phonenumber, Mobilenumber, Working Phonenumber, Emergency-Contact Phonenumner and Customer-ID");
            string[] input = Console.ReadLine().Split(',');
            string sql = $"INSERT INTO Phones (HomePhone,MobilePhone,WorkingPhone,EmergencyContactPhone,CustomerID) VALUES ('{input[0]}','{input[1]}','{input[2]}','{input[3]}','{input[4]}');";
            using (SqlConnection connection = new SqlConnection(Constring))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
            }
        }

        public static void AddCustomer()
        {

            Console.WriteLine("Give firstname, surname ,type, and email");
            string[] input = Console.ReadLine().Split(',');
            string sql = $"INSERT INTO Customer (Firstname,Surname,Type,Email) VALUES('{input[0]}','{input[1]}','{input[2]}','{input[3]}');";
            using (SqlConnection connection = new SqlConnection(Constring))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
            }
            AddPhone();
        }

        static void EditCustomer()
        {
            Console.WriteLine("Which ID do you want to edit?");
            int iD=Int32.Parse(Console.ReadLine());
            Console.WriteLine("Write new input? (Ge firstname, surname, Type, email)");
            string[] input = Console.ReadLine().Split(',');
            string sql = $"UPDATE Kundregister SET Firstname='{input[0]}',Surname='{input[1]}',Surname='{input[12]}',Email='{input[3]}', where CustomerId={iD}";

            using (SqlConnection connection = new SqlConnection(Constring))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
            }
        }

        static void DeleteCustomer()
        {
            Console.WriteLine("Which ID do you want to delete?");
            int iD = Int32.Parse(Console.ReadLine());
            string sql = $"DELETE FROM Kundregister WHERE CustomerId={iD}";

            using (SqlConnection connection = new SqlConnection(Constring))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
            }
        }
        //static void Search()
        //{
        //    var list = GetCustromerFromDB();
        //    Console.WriteLine("What Lastname are you looking for?");
        //    string lookUpName = Console.ReadLine();
        //    list.ForEach(item =>
        //    {
        //        if (item.Surname== lookUpName)
        //        {
        //            item.CustomerId=
        //            Kund found=Kund()
        //        }
        //    }
        //}
    }

