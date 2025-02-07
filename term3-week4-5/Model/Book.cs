namespace Model
{
    public class Book
    {
        private int id;
        public string Author { get; set; }
        public string Title { get; set; }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Book(int id, string author, string title)
        {
            Id = id;
            Author = author;
            Title = title;
        }

        public string ToString()
        {
            return $"'{Title}' by {Author}";
        }
    }
}
