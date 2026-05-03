using System;

namespace TaskFlowManager
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager manager = new TaskManager();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== TASKFLOW MANAGER =====");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Complete Task");
                Console.WriteLine("4. Delete Task");
                Console.WriteLine("5. Exit");
                Console.Write("Choose Option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        manager.AddTask();
                        break;
                    case "2":
                        manager.ViewTasks();
                        break;
                    case "3":
                        manager.CompleteTask();
                        break;
                    case "4":
                        manager.DeleteTask();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid Option!");
                        break;
                }

                Console.WriteLine("\nPress Enter...");
                Console.ReadLine();
            }
        }
    }
}
