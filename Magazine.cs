using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class Magazine: LibraryItem, IBorrowable
    {
        private const int LOAN_PERIOD = 7;

        public Magazine(string title, string issuenumber):base(title) { 
            IssueNumber = issuenumber;
        }

        public string IssueNumber { get; }

        public DateTime? DueDate { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public override int LoanPeriod() => LOAN_PERIOD;

        public void BorrowItem()
        {
            if (!IsAvailable)
                throw new InvalidOperationException("Item is not available.");

            DueDate = DateTime.Now.AddDays(LOAN_PERIOD);
            IsAvailable = false;
            IssueDate = DateTime.Now;
        }

        public void ReturnItem()
        {
            if (DateTime.Now > DueDate)
            {
                Console.WriteLine($"The book '{Title}' is returned late. Please pay the fine.");
            }
            ReturnDate = DateTime.Now;
            IsAvailable = true;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Issue Number : {IssueNumber}");
        }
    }
}
