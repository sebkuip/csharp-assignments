namespace Model
{
    public class Customer
    {
        private int id;
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Customer(int id, string emailAddress, string firstName, string lastName)
        {
            Id = id;
            EmailAddress = emailAddress;
            FirstName = firstName;
            LastName = lastName;
        }

        public string ToString()
        {
            return $"{FullName} ({EmailAddress})";
        }
    }
}
