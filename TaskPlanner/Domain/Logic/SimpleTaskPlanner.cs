
using TaskPlanner.DataAccess;
using TaskPlanner.Domain.Models.Classes;

namespace TaskPlanner.Domain.Logic
{
    public class SimpleTaskPlanner
    {
        private readonly IWorkItemsRepository _repository;

        // Конструктор, який приймає IWorkItemsRepository через Dependency Injection
        public SimpleTaskPlanner(IWorkItemsRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // Метод для створення плану задач, який витягує задачі з репозиторія
        public List<WorkItem> CreatePlan()
        {
            // Отримання всіх задач з репозиторію
            var workItems = _repository.GetAll();

            // Сортування задач за приорітетом, назвою і датою
            return workItems
                .OrderByDescending(wi => wi.Priority)  // Спочатку сортуємо за приорітетом по спадній
                .ThenBy(wi => wi.Title)                // Далі сортуємо за назвою в алфавітному порядку
                .ThenBy(wi => wi.DueDate)              // Нарешті, сортуємо за датою виконання
                .ToList();
        }
    }
}

