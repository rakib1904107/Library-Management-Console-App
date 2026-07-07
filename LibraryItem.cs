using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public abstract class LibraryItem
    {
        private static int uid = 1;

        public LibraryItem(string title)
        {
            if(string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException("title is required");
            Title = title;
            ItemId = uid++;
            IsAvailable = true;
            //UpdateAvailablity(true);
        }

        public string Title { get; }
        public int ItemId { get; }

        public bool IsAvailable { get; protected set; }

        //public void UpdateAvailablity(bool available)
        //{
        //    IsAvailable = available;
        //}

        public virtual void Display()
        {
            Console.WriteLine($"Item ID   : {ItemId}");
            Console.WriteLine($"Title     : {Title}");
            Console.WriteLine($"Available : {IsAvailable}");
        }

        public abstract int LoanPeriod();

    }
}
