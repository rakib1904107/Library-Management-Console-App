using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class BorrowHistory
    {
        public BorrowHistory(int userid, int itemid, DateTime? issuedate, DateTime? duedate, DateTime? returndate) {
            UserId = userid;
            ItemId = itemid;
            IssueDate = issuedate;
            DueDate = duedate;
            ReturnDate = returndate;
        }
        public int UserId { get; }
        public int ItemId { get; }
        public DateTime? IssueDate { get; }
        public DateTime? DueDate { get; }
        public DateTime? ReturnDate { get; }

    }
}
