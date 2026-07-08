using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class Member
    {
        private static int uid = 1;
        private List<int> _borrowedItems;
        public Member(string name)
        {
            UserId = uid++;
            UserName = name;
            _borrowedItems = new List<int>();
        }
        public string UserName { get; }
        public int UserId { get; }

        public void BorrowItem(LibraryItem item)
        {
            if (item is IBorrowable obj)
            {
                try
                {
                    obj.BorrowItem();
                    _borrowedItems.Add(item.ItemId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error borrowing item: {ex.Message}");
                }
            }
            else 
                Console.WriteLine("This item cannot be borrowed.");
        }

        public void ReturnItem(LibraryItem item)
        {
            if (item is IBorrowable obj)
            {
                try
                {
                    obj.ReturnItem();
                    _borrowedItems.Remove(item.ItemId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error returning item: {ex.Message}");
                }
            }
            else 
                Console.WriteLine("This item cannot be returned.");
        }

    }
}
