namespace Model
{
    public class Reservation
    {
        private int id;
        public DateTime ReservationDateTime { get; set; }
        public Customer customer { get; set; }
        public Book book { get; set; }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Reservation(int id, Customer customer, Book book)
        {
            Id = id;
            ReservationDateTime = DateTime.Now;
            this.customer = customer;
            this.book = book;
        }

        public string ToString()
        {
            return $"{customer.ToString()} -> {book.ToString()}";
        }
    }
}
