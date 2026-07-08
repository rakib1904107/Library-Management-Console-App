using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public interface IBorrowable
    {
        DateTime? IssueDate { get; set; }
        DateTime? DueDate { get; set; }
        DateTime? ReturnDate { get; set; }
        void BorrowItem();
        void ReturnItem();
    }
}
