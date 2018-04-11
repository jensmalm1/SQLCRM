namespace SQLCRM
{
    class Phone
    {
        private int PhoneId { get; set; }
        private string HomePhone { get; set; }
        private string MobilePhone { get; set; }
        private string WorkingPhone { get; set; }
        private string EmergencyContactPhone { get; set; }
        private int CustomerId { get; set; }

        public Phone(int phoneId, string homePhone, string mobilePhone, string workingPhone, string emergencyContactPhone,int customerId)
        {
            PhoneId = phoneId;
            HomePhone = homePhone;
            MobilePhone = mobilePhone;
            WorkingPhone = workingPhone;
            EmergencyContactPhone = emergencyContactPhone;
            CustomerId = customerId;
        }

        public override string ToString()
        {

            string ret = $"HomePhone: {HomePhone}\n";
            ret += $"CustomerId: {CustomerId}\n";
            return ret;
        }
    }
}