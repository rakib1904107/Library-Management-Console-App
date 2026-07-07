using Library_Management_System;

public class Management
{
    public static void Main()
    {
        Library item = new Library();
        while (true)
        {
            Console.WriteLine(".... Library Management System....");
            Console.WriteLine("1. View Catalog");
            Console.WriteLine("2. Add Item");
            Console.WriteLine("3. Borrow Item");
            Console.WriteLine("4. Return Item");
            Console.WriteLine("5. Search by Title");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    item.PrintAllItems();
                    break;

                case "2":
                    Console.Write("Which item want to add: ");
                    string libraryitem = Console.ReadLine();
                    //Console.WriteLine(libraryitem);
                    if(libraryitem == "book")
                    {
                        LibraryItem book = new Book("C# Learing", "Rakib", "1234567890");
                        item.AddItem(book);
                    }
                    else if(libraryitem == "magazine")
                    {
                        LibraryItem magazine = new Magazine("The ABC", "243536554");
                        item.AddItem(magazine);
                    }
                    break;

                case "3":
                    Console.Write("Enter id of item: ");
                    int itemid = int.Parse(Console.ReadLine());
                    LibraryItem libitem = item.FindItem(itemid);
                    ((IBorrowable)libitem).BorrowItem();
                    break;

                case "4":
                    Console.Write("Enter id of item: ");
                    int itemId = int.Parse(Console.ReadLine());
                    LibraryItem libItem = item.FindItem(itemId);
                    ((IBorrowable)libItem).ReturnItem();
                    break;

                case "5":
                    Console.Write("Enter Title: ");
                    string searchtext = Console.ReadLine();
                    item.SearchItems(searchtext);
                    break;

                case "6":
                    Console.WriteLine("Exit");
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
