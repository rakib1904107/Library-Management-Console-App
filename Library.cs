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

        public Library()
        {
            _allLibraryItem = new List<LibraryItem>();
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
            List<LibraryItem>? items = _allLibraryItem.FindAll(
                    item => item.Title.Contains(searchtext)
            );

            foreach(LibraryItem item in items)
                Console.WriteLine($"{item.ItemId} - {item.Title}");
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
