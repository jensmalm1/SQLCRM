using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Data.SqlClient;


namespace SQLCRM
{
    class Telefon
    {
        private string Telefonnummer { get; set; }

    }
    class Program
    {
        private static string Constring;
        static void Main(string[] args)
        {
            Constring= @"Server = (localdb)\mssqllocaldb; Database = Kundregister; Trusted_Connection = True";
            UserChoice();
        }

        static void UserChoice()
        {
            while (true)
            {
                Console.WriteLine(
                    $"{"|",-50}What do you want to do?\n1.Add Customer \n2.Edit Customer \n3.Delete Customer \n4.Show Customers");
                string input = Console.ReadLine();
                if (input != "Quit")
                {
                    int caseSwitch = Int32.Parse(input);
                    switch (caseSwitch)
                    {
                        case 1:
                            Add();
                            break;
                        case 2:
                            EditCustomer();
                            break;
                        case 3:
                            DeleteCustomer();
                            break;
                        default:
                            PrintAll();
                            break;
                    }
                }
                break;
            }
        }

        static void PrintAll()
        {
            var list = GetCustromerFromDB();

            list.ForEach(item => Console.WriteLine(item.ToString()));
        }

        static List<Kund> GetCustromerFromDB()
        {
            var list=new List<Kund>();
            string sql = "SELECT * from Kundregister";

            using (SqlConnection connection = new SqlConnection(Constring))
            using (SqlCommand command =new SqlCommand(sql,connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var Förnamn = reader.GetString(0);
                    var Efternamn = reader.GetString(1);
                    var Epost = reader.GetString(2);
                    var Telefonnummer = reader.GetString(3);
                    var KundID = reader.GetInt32(4);

                    list.Add(new Kund(Förnamn, Efternamn, Epost, Telefonnummer, KundID));

                }
            }
            return list;
        }

        public static void Add()
        {

            Console.WriteLine("Ge förnamn, efternamn, epost, telefonnummer");
            string[] input = Console.ReadLine().Split(',');
            string sql = $"INSERT INTO Kundregister (Förnamn,Efternamn,Epost,Telefonnummer) VALUES ('{input[0]}','{input[1]}','{input[2]}','{input[3]}');";
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
            int iD=Int32.Parse(Console.ReadLine());
            Console.WriteLine("Write new input? (Ge förnamn, efternamn, epost, telefonnummer)");
            string[] input = Console.ReadLine().Split(',');
            string sql = $"UPDATE Kundregister SET Förnamn='{input[0]}',Efternamn='{input[1]}',Epost='{input[2]}',Telefonnummer='{input[3]}' where KundID={iD}";

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
            string sql = $"DELETE FROM Kundregister WHERE KundID={iD}";

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
        //        if (item.Efternamn== lookUpName)
        //        {
        //            item.KundID=
        //            Kund found=Kund()
        //        }
        //    }
        //}
    }
}
