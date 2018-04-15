using System.Collections.Generic;

namespace SQLCRM
{
    class Product
    {
        public string ProductName { get; set; }
        public string ProductType { get; set; }
      
        public Product(string productName, string productType)
        {
            ProductName = productName;
            ProductType = productType;
         
        }
        public override string ToString()
        {

            string ret = $"Product name: {ProductName}\n";
            ret += $"Product type: {ProductType}\n";
            
            return ret;
        }
    }
}