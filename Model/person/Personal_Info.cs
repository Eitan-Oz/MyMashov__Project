namespace Model.person
{
    public class Personal_Info
    {
        private string _personalID;
        private string _firstName;
        private string _lastName;
        private string _phoneNumber;
        private string _password;
        private Address _address;


        public string PersonalID
        {
            get { return _personalID; }
            protected set { _personalID = value; }
        }
        public string FirstName
        {
            get { return _firstName; }
            protected set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            protected set { _lastName = value; }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            protected set { _phoneNumber = value; }
        }

        public string Password
        {
            get { return _password; }
            protected set { _password = value; }
        }

        public Address Address
        {
            get { return _address; }
            protected set { _address = value; }
        }

        public Personal_Info()
        {
        }
        public Personal_Info(string personalID, string Fname, string Lname, string phoneNumber, Address address, string password)
        {
            this.PersonalID = personalID;
            this.FirstName = Fname;
            this.LastName = Lname;
            this.PhoneNumber = phoneNumber;
            this.Address = address;
            this.Password = password;

        }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public bool IsCorrectPassword(string writePass)
        {
            // השוואה פשוטה בין המאפיין Password לבין מה שהמשתמש הזין
            // שים לב ש-Password (באות גדולה) הוא המאפיין הציבורי שלך
            return this.Password == writePass;
        }

        public override string ToString()
        {
            // שימוש באופרטור ?. מונע קריסה אם Address הוא null בלי צורך ב-try-catch
            string addressStr = Address?.ToString() ?? "No Address Provided";
            return $"PersonalID: {PersonalID}, FullName: {GetFullName()}, Address: {addressStr}";
        }
    }
}
