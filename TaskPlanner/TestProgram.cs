
using TaskPlanner.Domain.Logic;
using TaskPlanner.Domain.Models.Classes;
using TaskPlanner.Domain.Models.Enums;

internal static class Program
{
    public static void Main(string[] args)
    {
        
        var planner = new SimpleTaskPlanner();
        var sortedWorkItems = planner.CreatePlan(GenerateItems());

        Console.WriteLine("\nSorted Work Items:");
        foreach (var item in sortedWorkItems)
        {
            Console.WriteLine(item.ToString());
        }
    }
    private static List<WorkItem> GenerateItems()
    {
        var workItems = new List<WorkItem>();
        var random = new Random();

        for (int i = 0; i < 100; i++)
        {
            var creationDate = DateTime.Now.AddDays(-random.Next(1, 100)); // Випадкова дата створення
            var dueDate = creationDate.AddDays(random.Next(1, 30)); // Випадкова дата виконання

            var priority = (Priority)random.Next(1, 5); // Випадковий пріоритет
            var complexity = (Complexity)random.Next(1, 5); // Випадкова складність

            var title = $"Task {i + 1}";
            var description = $"Description for task {i + 1}";

            var isCompleted = random.Next(0, 2) == 0; // Випадкове значення для IsCompleted

            var workItem = new WorkItem(creationDate, dueDate, priority, title, description, isCompleted);
            workItems.Add(workItem);
        }

        return workItems;
    }

   /* private static WorkItem[] ReadWorkItemsFromConsole()
    {
        var workItems = new List<WorkItem>();

        while (true)
        {
            Console.WriteLine("Enter a new work item:");

            Console.Write("Title: ");
            string title = Console.ReadLine();

            Console.Write("Due Date (dd.MM.yyyy): ");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Priority (None, Low, Medium, High, Urgent): ");
            Priority priority = Enum.Parse<Priority>(Console.ReadLine(), true);

            Console.Write("Complexity (None, Minutes, Hours, Days, Weeks): ");
            Complexity complexity = Enum.Parse<Complexity>(Console.ReadLine(), true);

            Console.Write("Description: ");
            string description = Console.ReadLine();

            var workItem = new WorkItem
            {
                Title = title,
                DueDate = dueDate,
                Priority = priority,
                Complexity = complexity,
                Description = description,
                CreationDate = DateTime.Now,
                IsCompleted = false
            };

            workItems.Add(workItem);

            Console.Write("Do you want to add another work item? (y/n): ");
            if (Console.ReadLine().ToLower() != "y")
            {
                break;
            }

            Console.WriteLine();
        }

        return workItems.ToArray();
    }*/
}
