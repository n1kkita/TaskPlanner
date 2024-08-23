
using TaskPlanner.Domain.Models.Enums;

namespace TaskPlanner.Domain.Models.Classes
{
    public class WorkItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DueDate { get; set; }
        public Priority Priority { get; set; }
        public Complexity Complexity { get; set; }
        public bool IsCompleted { get; set; }

        // Конструктор для ініціалізації всіх властивостей
        public WorkItem(Guid id, string title, string description, DateTime creationDate, DateTime dueDate, Priority priority, Complexity complexity, bool isCompleted)
        {
            Id = id;
            Title = title;
            Description = description;
            CreationDate = creationDate;
            DueDate = dueDate;
            Priority = priority;
            Complexity = complexity;
            IsCompleted = isCompleted;
        }

        // Пустий конструктор, якщо потрібно
        public WorkItem()
        {
        }

        public override string ToString()
        {
            string priorityDescription = Priority.ToString().ToLower();
            return $"{Title}: due {DueDate:dd.MM.yyyy}, {priorityDescription} priority";
        }
    }
}
