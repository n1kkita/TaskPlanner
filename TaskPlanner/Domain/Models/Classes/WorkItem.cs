
using TaskPlanner.Domain.Models.Enums;

namespace TaskPlanner.Domain.Models.Classes
{
    public class WorkItem
    {
        public DateTime CreationDate { get; set; }
        public DateTime DueDate { get; set; }
        public Priority Priority { get; set; }
        public Complexity Complexity { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public override string ToString()
        {
            string priorityDescription = Priority.ToString().ToLower();
            return $"{Title}: due {DueDate:dd.MM.yyyy}, {priorityDescription} priority";
        }

        public WorkItem(DateTime CreationDate, DateTime DueDate, Priority Priority, string Title, string Description, bool IsCompleted) {
            this.CreationDate = CreationDate;
            this.DueDate = DueDate;
            this.Priority = Priority;
            this.Title = Title;
            this.Description = Description;
            this.IsCompleted = IsCompleted;   
        }
    }
}
