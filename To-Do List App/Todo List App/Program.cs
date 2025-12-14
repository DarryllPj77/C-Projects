//To-Do List App

using System;
using System.Xml.Serialization;


List<(string, bool)> tasks = new List<(string, bool)>();

// ------------------------------------
// LOAD TASKS FROM FILE
// ------------------------------------

if(File.Exists("tasks.txt")){
    using (StreamReader reader = new StreamReader("tasks.txt"))
    {
        string line;
        while((line = reader.ReadLine() ?? "") != "")
        {
            string[] parts = line.Split('|');
            if(parts.Length == 2)
            {
                string taskName = parts[0];
                bool isCompleted = bool.Parse(parts[1]);
                tasks.Add((taskName, isCompleted));
            }
        }
    }
}

// ------------------------------------
// MAIN MENU LOOP
// ------------------------------------

int choice = 0;
do
{
    Console.WriteLine("===========================");
    Console.WriteLine("TO-DO LIST MENU");
    Console.WriteLine("1. View Tasks");
    Console.WriteLine("2. Add Task");
    Console.WriteLine("3. Delete Task");
    Console.WriteLine("4. Edit Task");
    Console.WriteLine("5. Mark Task Completed");
    Console.WriteLine("6. Save Tasks");
    Console.WriteLine("7. Exit");
    Console.WriteLine("Choose option: ");

    int.TryParse(Console.ReadLine() ?? "0", out choice);

    switch(choice){
        case 1:
            Console.WriteLine("Your Tasks:");
            for(int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + tasks[i].Item1 + 
                        " [" + (tasks[i].Item2 ? "Completed" : "Pending") + "]");
            }
            break;

        case 2:
            Console.WriteLine("Enter new task name: ");
            string newTask = Console.ReadLine() ?? "";
            tasks.Add((newTask, false));
            Console.WriteLine("Task added.");
            break;

        case 3:
            Console.WriteLine("Enter task number to delete: ");
            int deleteIndex = int.Parse(Console.ReadLine() ?? "0") - 1;
            if(deleteIndex >= 0 && deleteIndex < tasks.Count)
            {
                tasks.RemoveAt(deleteIndex);
                Console.WriteLine("Task deleted.");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
            break;

        case 4:
            Console.WriteLine("Enter task number to edit: ");
            int editIndex = int.Parse(Console.ReadLine() ?? "0") - 1;
            if(editIndex >= 0 && editIndex < tasks.Count)
            {
                Console.WriteLine("Enter new task name: ");
                string updatedName = Console.ReadLine() ?? "";
                tasks[editIndex] = (updatedName, tasks[editIndex].Item2);
                Console.WriteLine("Task updated.");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
            break;

        case 5:
            Console.WriteLine("Enter task number to mark complete: ");
            int completeIndex = int.Parse(Console.ReadLine() ?? "0") - 1;
            if(completeIndex >= 0 && completeIndex < tasks.Count)
            {
                tasks[completeIndex] = (tasks[completeIndex].Item1, true);
                Console.WriteLine("Task marked as completed.");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }
            break;

        case 6:
            using(StreamWriter writer = new StreamWriter("tasks.txt"))
            {
                foreach(var task in tasks)
                {
                    writer.WriteLine(task.Item1 + "|" + task.Item2);
                }
            }
            Console.WriteLine("Tasks saved.");
            break;

        case 7:
            Console.WriteLine("Goodbye!");
            break;

        default:
            Console.WriteLine("Invalid option. Try again.");
            break;
    }

}while(choice != 7);