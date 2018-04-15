using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data.SqlClient;
using System.Linq;
using SQLCRM;


namespace SQLCRM
{
    class Program
    {
        private static string Constring;
        
        static void Main(string[] args)
        {
            Constring = @"Server = (localdb)\mssqllocaldb; Database = Kundregister; Trusted_Connection = True";
      
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
                    $"\n{"|",0}What do you want to do?|\n\n{"",1}Type Quit to quit\n1.Add new Customer \n2.Add Phones to existing customer\n3.Add Product\n4.Edit Customer \n5.Edit Phone \n6.Edit Product \n7.Delete Customer \n8.Delete Phone \n9.Delete Product \n10.Show Customers \n11.Show Phones \n12.Show Products \n else show all");
                string input = Console.ReadLine();
                if (input !="Quit")
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
                            AddProduct();
                            break;
                        case 4:
                            EditCustomer();
                            break;
                        case 5:
                            EditPhone();
                            break;
                        case 6:
                            EditProduct();
                            break;
                        case 7:
                            DeleteCustomer();
                            break;
                        case 8:
                            DeletePhone();
                            break;
                        case 9:
                            DeleteProduct();
                            break;
                        case 10:
                            PrintCustomers();
                            break;
                        case 11:
                            PrintPhones();
                            break;
                        case 12:
                            PrintProducts();
                            break;
                        default:
                            PrintAll();
                            break;
                    }
                }

                break;
            }
        }

        //static void PrintCustomers()
        //{
        //    var customerList = GetCustomersFromDB();
        //    customerList.ForEach(item => Console.WriteLine(item.ToString()));
        //}
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

        static void PrintProducts()
        {
            var productList = GetProductsFromDB();
            productList.ForEach(item => Console.WriteLine(item.ToString()));
        }

        static void PrintAll()
        {

            var allList = GetAllFromDB();

            allList.ForEach(item => Console.WriteLine(item));
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
                    string EmergencyContactPhone = null;
                    var Type = reader.GetString(0);
                    var Firstname = reader.GetString(1);
                    var Surname = reader.GetString(2);
                    var Email = reader.GetString(3);
                    var CustomerId = reader.GetInt32(4);



                    Phone CustPhoneNumbers;
                    Product CustProduct;

                    foreach (Phone phone in GetPhoneFromDB())
                    {

                        if (CustomerId == phone.CustomerId)
                        {
                            CustPhoneNumbers = phone;
                        }
                        else
                        {
                            CustPhoneNumbers = new Phone("0", "0", "0", "0", CustomerId);
                        }

                        list.Add(new Customers(Type, Firstname, Surname, Email, CustomerId, CustPhoneNumbers));
                    }
                }
            }

            return list;
            }
        //static List<Customers> GetCustomersFromDB()
        //{

        //    var list = new List<Customers>();
        //    string sql = "update CustProd ProductID,CustomerID from Customer Inner join Product on Customer.CustomerID = Product.CustomerID";

        //    using (SqlConnection connection = new SqlConnection(Constring))
        //    using (SqlCommand command = new SqlCommand(sql, connection))
        //    {
        //        connection.Open();

        //        SqlDataReader reader = command.ExecuteReader();

        //        while (reader.Read())
        //        {

        //            var CustomerId = reader.GetInt32(0);
        //            var CustomerId = reader.GetInt32(1);


        //            foreach (Phone phone in GetPhoneFromDB())
        //            {

        //                if (CustomerId == phone.CustomerId)
        //                {
        //                    CustPhoneNumbers = phone;
        //                }
        //                else
        //                {
        //                    CustPhoneNumbers = new Phone("0", "0", "0", "0", CustomerId);
        //                }

        //                list.Add(new Customers(Type, Firstname, Surname, Email, CustomerId, CustPhoneNumbers));
        //            }
        //        }
        //    }

        //    return list;
        //}

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
                    string EmergencyContactPhone = null;

                    var HomePhone = reader.GetString(1);
                    var MobilePhone = reader.GetString(2);
                    var WorkingPhone = reader.GetString(3);

                    if (!reader.GetSqlString(4).IsNull)
                        EmergencyContactPhone = reader.GetString(4);
                    var CustomerId = reader.GetInt32(5);

                    phoneList.Add(new Phone(HomePhone, MobilePhone, WorkingPhone, EmergencyContactPhone, CustomerId));

                }
            }

            return phoneList;
        }

        public static List<Product> GetProductsFromDB()
        {
            var prodList = new List<Product>();
            
            string sql = "SELECT * from Product";

            using (SqlConnection connection = new SqlConnection(Constring))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                  

                    var ProductName = reader.GetString(1);
                    var ProductType= reader.GetString(2);
                  
                 

                    prodList.Add(new Product(ProductName, ProductType));

                }
            }

            return prodList;
        }

        static List<string> GetAllFromDB()
        {
            var list = new List<string>();
            string sql =
                "select Firstname,Surname,Email,Type,HomePhone,MobilePhone,WorkingPhone,EmergencyContactPhone,Customer.CustomerID from Phones Inner join Customer on Phones.CustomerID = Customer.CustomerID";

            using (SqlConnection connection = new SqlConnection(Constring))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                string EmergencyContactPhone = null;
                while (reader.Read())
                {

                    var Firstname = reader.GetString(0);
                    var Surname = reader.GetString(1);
                    var Email = reader.GetString(2);
                    var Type = reader.GetString(3);
                    var HomePhone = reader.GetString(4);
                    var MobilePhone = reader.GetString(5);
                    var WorkingPhone = reader.GetString(6);
                    if (!reader.GetSqlString(7).IsNull)
                    {
                        EmergencyContactPhone = reader.GetString(7);
                    }


                    list.Add($"{"",-5}{Firstname}{"|",5}, {Surname}, {Email}, {Type},{HomePhone}, {MobilePhone}, {WorkingPhone}, {EmergencyContactPhone}");

                }
            }

            return list;
        }


        public static void AddCustomer()
        {

            Console.WriteLine("Give firstname, surname ,type, and email");
            string[] input = Console.ReadLine().Split(',');
  
            string sql =
                $"INSERT INTO Customer (Firstname,Surname,Type,Email) VALUES('{input[0]}','{input[1]}','{input[2]}','{input[3]}');";
            using (SqlConnection connection = new SqlConnection(Constring))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
            }

         


            

            AddPhone();
        }

        public static void AddProduct()
        {
            var prodCustId=new List<int>();
            Console.WriteLine("Give product name and product type");
            string[] input = Console.ReadLine().Split(',');
          
            string sql =
                $"INSERT INTO Product (ProductName,ProductType) VALUES('{input[0]}','{input[1]}');";
            using (SqlConnection connection = new SqlConnection(Constring))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
            }

            

        }
        public static void AddPhone()
        {
            Console.WriteLine(
                "Give Home-Phonenumber, Mobilenumber, Working Phonenumber, Emergency-Contact Phonenumner and Customer-ID");
            string[] input = Console.ReadLine().Split(',');
            string sql =
                $"INSERT INTO Phones (HomePhone,MobilePhone,WorkingPhone,EmergencyContactPhone,CustomerID) VALUES ('{input[0]}','{input[1]}','{input[2]}','{input[3]}','{input[4]}');";
            using (SqlConnection connection = new SqlConnection(Constring))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
            }
        }
        static void EditCustomer()
        {
            Console.WriteLine("Which ID do you want to edit?");
            int iD = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Write new input? (Ge firstname, surname, Type, email)");
            string[] input = Console.ReadLine().Split(',');
            string sql =
                $"UPDATE Customer SET Firstname='{input[0]}',Surname='{input[1]}',Type='{input[2]}',Email='{input[3]}', where CustomerId={iD}";

            using (SqlConnection connection = new SqlConnection(Constring))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
            }
        }


        static void EditPhone()
        {
            Console.WriteLine("Which Phone-ID do you want to edit?");
            int iD = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Write new input? (Give Home-Phonenumber, Mobilenumber, Working Phonenumber and Emergency-Contact Phonenumner");
            string[] input = Console.ReadLine().Split(',');
            string sql =
                $"UPDATE Phones SET HomePhone='{input[0]}',MobilePhone='{input[1]}',WorkingPhone='{input[2]}',EmergencyContactPhone='{input[3]}', where PhoneId={iD}";

            using (SqlConnection connection = new SqlConnection(Constring))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
            }
        }

        static void EditProduct()
        {
            Console.WriteLine("Which product-ID do you want to edit?");
            int iD = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Write new input? (Give ProductName and Type)");
            string[] input = Console.ReadLine().Split(',');
            string sql =
                $"UPDATE Kundregister SET ProductName='{input[0]}',ProductType='{input[1]}' where ProductId={iD}";

            using (SqlConnection connection = new SqlConnection(Constring))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
            }
        }

        static void DeleteCustomer()
        {
            Console.WriteLine("Which Customer-ID do you want to delete?");
            int iD = Int32.Parse(Console.ReadLine());
            string sql = $"DELETE FROM Customer WHERE CustomerId={iD}";

            using (SqlConnection connection = new SqlConnection(Constring))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
            }
        }
        static void DeletePhone()
        {
            Console.WriteLine("Which Phone-ID do you want to delete?");
            int iD = Int32.Parse(Console.ReadLine());
            string sql = $"DELETE FROM Phones WHERE CustomerId={iD}";

            using (SqlConnection connection = new SqlConnection(Constring))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
            }
        }
        static void DeleteProduct()
        {
            Console.WriteLine("Which Product-ID do you want to delete?");
            int iD = Int32.Parse(Console.ReadLine());
            string sql = $"DELETE FROM Product WHERE CustomerId={iD}";

            using (SqlConnection connection = new SqlConnection(Constring))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
            }
        }
        static void Search()
        {
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
        }
    }

}