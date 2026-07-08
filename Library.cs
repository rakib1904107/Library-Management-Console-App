using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class Library
    {
        private List<LibraryItem> _allLibraryItem;
        private List<BorrowHistory> _borrowHistory;
        private List<Member> _allMembers;

        public Library()
        {
            _allLibraryItem = new List<LibraryItem>();
            _borrowHistory = new List<BorrowHistory>();
        }

        public void AddItem(LibraryItem item)
        {
            _allLibraryItem.Add(item);
        }
        public void RemoveItem(LibraryItem item)
        {
            _allLibraryItem.Remove(item);
        }
        public LibraryItem FindItem(int itemid)
        {
            LibraryItem? item = _allLibraryItem.FirstOrDefault(item => item.ItemId == itemid);
            if (item != null)
                return item;
            else
                throw new KeyNotFoundException("Item not found");
        }
        public void SearchItems(string searchtext){
            var items = _allLibraryItem.FindAll(
                    item => item.Title.Contains(searchtext)
            );

            if(items.Count > 0)
            {
                foreach (LibraryItem item in items)
                    Console.WriteLine($"{item.ItemId} - {item.Title}");
            }
            else Console.WriteLine("No items found");
        }

        public void AddBorrowHistory(BorrowHistory history)
        {
            _borrowHistory.Add(history);
        }
        public void UpdateBorrowHistory(int userid, int itemid, DateTime? issuedate, DateTime? duedate, DateTime? returndate)
        {
            BorrowHistory? history = _borrowHistory.FirstOrDefault(h => h.ItemId == itemid && h.IssueDate == issuedate);
            if (history != null)
            {
                _borrowHistory.Remove(history);
                _borrowHistory.Add(new BorrowHistory(userid, itemid, issuedate, duedate,returndate));
            }
            else
                throw new KeyNotFoundException("Borrow history not found");
        }
        public void AddMember(Member member)
        {
            _allMembers.Add(member);
        }
        public void RemoveMember(Member member)
        {
            _allMembers.Remove(member);
        }
        public void PrintBorrowHistory()
        {
            foreach(BorrowHistory history in _borrowHistory)
            {
                Console.WriteLine($"User ID: {history.UserId}, Item ID: {history.ItemId}, Issue Date: {history.IssueDate}, Due Date: {history.DueDate}, Return Date: {history.ReturnDate}");
            }
        }

        public void PrintAllItems()
        {
            foreach(LibraryItem item in _allLibraryItem)
            {
                item.Display();
            }
        }
    }
}
