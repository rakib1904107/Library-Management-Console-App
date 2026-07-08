namespace Library_Management_System
{
    public class Book : LibraryItem, IBorrowable
    {
        private const int LOAN_PERIOD = 14;
        public Book(string title, string author, string isbn) : base(title) {
            Author = author;

            if (!(isbn.Length == 10 | isbn.Length == 13))
                throw new ArgumentException("The ISBN must be a 10- or 13-character string.");
            ISBN = isbn;
        }
        public string Author { get; }
        public string ISBN { get; }

        public DateTime? DueDate { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public override int LoanPeriod() => LOAN_PERIOD;

        public void BorrowItem()
        {
            if (!IsAvailable)
                throw new InvalidOperationException("Item is not available.");

            DueDate = DateTime.Now.AddDays(LOAN_PERIOD);
            IssueDate = DateTime.Now;
            IsAvailable = false;
            //UpdateAvailablity(false);
        }

        public void ReturnItem()
        {
            if(DateTime.Now > DueDate)
            {
                Console.WriteLine($"The book '{Title}' is returned late. Please pay the fine.");
            }
            ReturnDate = DateTime.Now;
            IsAvailable = true;
            //UpdateAvailablity(true);
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Author : {Author}");
            Console.WriteLine($"ISBN   : {ISBN}");
            Console.WriteLine($"Due Date: {DueDate}");
        }

    }
}
