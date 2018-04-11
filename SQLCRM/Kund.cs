using System;
using System.Data.SqlClient;

namespace SQLCRM
{
    class Kund
    {
        private string Förnamn { get; set; }
       public string Efternamn { get; set; }
        private string Epost { get; set; }
      
       public int KundID { get; set; }

        public Kund(string förnamn, string efternamn, string epost, string telefonnummer, int kundId)
        {
            Förnamn = förnamn;
            Efternamn = efternamn;
            Epost = epost;
            Telefonnummer = telefonnummer;
            KundID = kundId;
        }

        public override string ToString()
        {

            string ret = $"Förnamn: {Förnamn}\n";
            ret += $"Efternamn: {Efternamn}\n";
            ret += $"Epost: {Epost}\n";
            ret += $"Telefonnummer: {Telefonnummer}\n";
            ret += $"KundID: {KundID}\n";
            return ret;
        }
    }
}
