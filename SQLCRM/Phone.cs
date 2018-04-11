﻿namespace SQLCRM
{
    class Phone
    {

        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkingPhone { get; set; }
        public string EmergencyContactPhone { get; set; }
        public int CustomerId { get; set; }

        public Phone(string homePhone, string mobilePhone, string workingPhone, string emergencyContactPhone,int customerId)
        {
            HomePhone = homePhone;
            MobilePhone = mobilePhone;
            WorkingPhone = workingPhone;
            EmergencyContactPhone = emergencyContactPhone;
            CustomerId = customerId;
        }

    }
}