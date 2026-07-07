using Library_Management_System;

public class Management
{
    public static void Main()
    {
        var library= new Library();
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
                    library.PrintAllItems();
                    break;

                case "2":
                    Console.Write("Which item want to add: ");
                    string ItemName = Console.ReadLine();
                    LibraryItem item = null;
                    if(ItemName == "book")
                    {
                        item = new Book("C# Learing", "Rakib", "1234567890");
                    }
                    else if(ItemName == "magazine")
                    {
                        LibraryItem magazine = new Magazine("The ABC", "243536554");
                    }
                    else 
                        Console.WriteLine("Invalid item type");
                    library.AddItem(item);
                    break;

                case "3":
                    Console.Write("Enter id of item: ");
                    LibraryItem BorrowItem = null;
                    try
                    {
                        int ItemId = int.Parse(Console.ReadLine());
                        BorrowItem = library.FindItem(ItemId);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    if(BorrowItem is IBorrowable borrowableItem)
                    {
                        borrowableItem.BorrowItem();
                    }
                    else
                    {
                        Console.WriteLine("Item is not borrowable.");
                    }
                    break;

                case "4":
                    Console.Write("Enter id of item: ");
                    LibraryItem ReturnItem = null;
                    try
                    {
                        int ItemId = int.Parse(Console.ReadLine());
                        ReturnItem = library.FindItem(ItemId);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    if (ReturnItem is IBorrowable returnableItem)
                    {
                        returnableItem.ReturnItem();
                    }
                    else
                    {
                        Console.WriteLine("Item is not returnable.");
                    }
                    break;

                case "5":
                    Console.Write("Enter Title: ");
                    string searchtext = Console.ReadLine();
                    library.SearchItems(searchtext);
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
