using System;

namespace todoapp
{
    class Program
    {
    #if DEBUG    
        static TodoLists dataStore = new TodoLists(true);
    #else
        static TodoLists dataStore = new TodoLists(false);
    #endif
    
        static void Main(string[] args)
        {
            ShowMainMenu();
        }

        static void ShowMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                if (dataStore.HasLists())
                { 
                    Console.WriteLine(dataStore);
                } 
                else 
                {
                    Console.WriteLine("Please create a new list!");
                }
                PrintMainMenu();
                var input = Console.ReadLine();
                var selectedOption = -1;
                try {
                    selectedOption = int.Parse(input);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Input!");
                    continue;
                }

                switch ((MenuOptions)selectedOption)
                {
                    case MenuOptions.SelectList:
                        HandleOptionSelectList();
                        break;
                    case MenuOptions.NewList:
                        HandleOptionNewList();
                        break;
                    case MenuOptions.Exit:
                        HandleOptionExit();
                        break;
                    default:
                        break;
                }

            }
        }

        static void ShowListMenu(TodoList selectedList)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                if (selectedList.HasItems())
                { 
                    Console.WriteLine(selectedList);
                } 
                else 
                {
                    Console.WriteLine("Your list is empty!");
                }

                PrintListMenu();
                var input = Console.ReadLine();
                var selectedOption = -1;
                try {
                    selectedOption = int.Parse(input);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Input!");
                    continue;
                }

                switch ((MenuOptions)selectedOption)
                {
                    case MenuOptions.MainMenu:
                        return;
                    case MenuOptions.AddItem:
                        HandleOptionAddItem(selectedList);
                        break;
                    case MenuOptions.DeleteItem:
                        HandleOptionDeleteItem(selectedList);
                        break;
                    case MenuOptions.ToggleComplete:
                        HandleOptionToggleComplete(selectedList);
                        break;
                    case MenuOptions.ClearList:
                        selectedList.ClearAll();
                        break;
                    case MenuOptions.DeleteList:
                        HandleOptionDeleteList(selectedList);
                        break;
                    case MenuOptions.Exit:
                        HandleOptionExit();
                        break;
                    default:
                        Console.WriteLine("Invalid Input!");
                        break;
                }
            }
        }

        static void PrintMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Main Menu");
            Console.WriteLine("  {0}) Select List", (int)MenuOptions.SelectList);
            Console.WriteLine("  {0}) New List", (int)MenuOptions.NewList);
            Console.WriteLine("  {0}) Exit", (int)MenuOptions.Exit);
            Console.WriteLine();
            Console.Write("Please select an option: ");
        }

        static void PrintListMenu()
        {
            Console.WriteLine();
            Console.WriteLine("List Menu");
            Console.WriteLine("  {0}) Back to Main Menu", (int)MenuOptions.MainMenu);
            Console.WriteLine("  {0}) Add Item", (int)MenuOptions.AddItem);
            Console.WriteLine("  {0}) Delete Item", (int)MenuOptions.DeleteItem);
            Console.WriteLine("  {0}) Toggle Complete", (int)MenuOptions.ToggleComplete);
            Console.WriteLine("  {0}) Clear List", (int)MenuOptions.ClearList);
            Console.WriteLine("  {0}) DELETE LIST", (int)MenuOptions.DeleteList);
            Console.WriteLine("  {0}) Exit", (int)MenuOptions.Exit);
            Console.WriteLine();
            Console.Write("Please select an option: ");
        }

        static void HandleOptionSelectList()
        {
            TodoList selectedList;
            Console.Write("Enter list number: ");
            var input = Console.ReadLine();
            try
            {
                selectedList = dataStore[int.Parse(input)];
                ShowListMenu(selectedList);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Item!");
            }
        }

        static void HandleOptionNewList()
        {
            TodoList newList;
            Console.Write("Enter list title: ");
            var input = Console.ReadLine();
            try
            {
                newList = new TodoList(input);
                dataStore.AddList(newList);
                ShowListMenu(newList);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Item!");
            }
        }

        static void HandleOptionDeleteList(TodoList selectedList)
        {
            dataStore.DeleteList(selectedList);
            ShowMainMenu();
        }

        static void HandleOptionExit()
        {
            Environment.Exit(0);
        }

        static void HandleOptionAddItem(TodoList selectedList)
        {
            Console.Write("Enter text for the new item: ");
            var input = Console.ReadLine();
            if (input.Length > 0)
            {
                selectedList.AddItem(new TodoItem(input));
            }
            else
            {
                Console.WriteLine("Invalid Input!");
            }
        }

        static void HandleOptionDeleteItem(TodoList selectedList)
        {
            Console.Write("Enter item number to delete: ");
            var input = Console.ReadLine();
            try
            {
                TodoItem selectedItem = selectedList[int.Parse(input)];
                selectedList.DeleteItem(selectedItem);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Item!");
            }
        }

        static void HandleOptionToggleComplete(TodoList selectedList)
        {
            Console.Write("Enter item number toggle completion: ");
            var input = Console.ReadLine();
            try
            {
                TodoItem selectedItem = selectedList[int.Parse(input)];
                selectedItem.ToggleComplete();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Item!");
            }
        }

        enum MenuOptions
        {
            SelectList = 1,
            NewList = 2,
            MainMenu = 3,
            AddItem = 4,
            DeleteItem = 5,
            ToggleComplete = 6,
            ClearList = 7,
            DeleteList = 8,
            Exit = 9
        }
    }
}
