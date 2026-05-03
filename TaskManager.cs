using System;
using System.Collections.Generic;
using System.IO;

namespace TaskFlowManager
{
    public class TaskManager
    {
        private List<TaskItem> tasks = new List<TaskItem>();
        private string filePath = "tasks.txt";

        public TaskManager()
        {
            LoadTasks();
        }

        public void AddTask()
        {
            Console.Write("Enter Task Title: ");
            string title = Console.ReadLine();

            tasks.Add(new TaskItem(title));
            SaveTasks();

            Console.WriteLine("Task Added Successfully!");
        }

        public void ViewTasks()
        {
            Console.WriteLine("\n===== TASK LIST =====");

            if (tasks.Count == 0)
            {
                Console.WriteLine("No Tasks Found.");
                return;
            }

            for (int i = 0; i < tasks.Count; i++)
            {
                string status = tasks[i].IsCompleted ? "✔" : "✘";
                Console.WriteLine($"{i + 1}. {tasks[i].Title} [{status}]");
            }
        }

        public void CompleteTask()
        {
            ViewTasks();
            Console.Write("Enter Task Number: ");
            int num = int.Parse(Console.ReadLine());

            if (num > 0 && num <= tasks.Count)
            {
                tasks[num - 1].IsCompleted = true;
                SaveTasks();
                Console.WriteLine("Task Completed!");
            }
        }

        public void DeleteTask()
        {
            ViewTasks();
            Console.Write("Enter Task Number: ");
            int num = int.Parse(Console.ReadLine());

            if (num > 0 && num <= tasks.Count)
            {
                tasks.RemoveAt(num - 1);
                SaveTasks();
                Console.WriteLine("Task Deleted!");
            }
        }

        private void SaveTasks()
        {
            List<string> lines = new List<string>();

            foreach (var task in tasks)
            {
                lines.Add(task.ToString());
            }

            File.WriteAllLines(filePath, lines);
        }

        private void LoadTasks()
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    tasks.Add(TaskItem.FromString(line));
                }
            }
        }
    }
}
