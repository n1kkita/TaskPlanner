
using TaskPlanner.Domain.Models.Classes;

namespace TaskPlanner.Domain.Logic
{
    public class SimpleTaskPlanner
    {
        public List<WorkItem> CreatePlan(List<WorkItem> workItems)
        {
            return workItems
                .OrderByDescending(wi => wi.Priority)   // Спочатку сортуємо за Priority за спаданням
                .ThenBy(wi => wi.DueDate)              // Потім сортуємо за DueDate за зростанням
                .ThenBy(wi => wi.Title)
                .ToList();                             // І нарешті сортуємо за Title в алфавітному порядку
               
        }
    }
}
