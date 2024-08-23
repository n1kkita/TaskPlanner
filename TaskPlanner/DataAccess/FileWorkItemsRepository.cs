using Newtonsoft.Json;
using TaskPlanner.DataAccess;
using TaskPlanner.Domain.Models.Classes;

public class FileWorkItemsRepository : IWorkItemsRepository
{
    private const string FileName = "work-items.json";
    private List<WorkItem> _workItems;
    private readonly Dictionary<Guid, WorkItem> _workItemsDictionary = new Dictionary<Guid, WorkItem>();

   // Конструктор: зчитування даних з файлу при створенні об'єкта
   public FileWorkItemsRepository()
    {
        if (File.Exists(FileName))
        {
            string fileContent = File.ReadAllText(FileName);
            if (!string.IsNullOrEmpty(fileContent))
            {
                _workItems = JsonConvert.DeserializeObject<List<WorkItem>>(fileContent);
                foreach (var item in _workItems)
                {
                    _workItemsDictionary.Add(item.Id, item);
                }
            }
            else
            {
                _workItems = new List<WorkItem>();
            }
        }
        else
        {
            _workItems = new List<WorkItem>();
        } 
    }

    public WorkItem getItemFromHashTableByGuid(Guid id)
    {
        return _workItemsDictionary.GetValueOrDefault(id, new WorkItem());
    }
    // Додавання нового WorkItem
    public Guid Add(WorkItem workItem)
    {
        _workItems.Add(workItem);
        SaveChanges();
        return workItem.Id;
    }

    // Отримання WorkItem за Id
    

    // Отримання всіх WorkItems
    public WorkItem[] GetAll()
    {
        return _workItems.ToArray();
    }

    private WorkItem Get(Guid id)
    {
        return _workItems.Find(item => item.Id == id);
    }
    // Оновлення WorkItem
    public bool Update(WorkItem workItem)
    {
        var existingItem = Get(workItem.Id);
        if (existingItem != null)
        {
            existingItem.Title = workItem.Title;
            existingItem.Description = workItem.Description;
            SaveChanges();
            return true;
        }
        return false;
    }

    // Видалення WorkItem за Id
    public bool Remove(Guid id)
    {
        var itemToRemove = Get(id);
        if (itemToRemove != null)
        {
            _workItems.Remove(itemToRemove);
            SaveChanges();
            return true;
        }
        return false;
    }
    public void RemoveAll()
    {
        _workItems.Clear();
        SaveChanges(); 
        
    }

    // Збереження змін
    public void SaveChanges()
    {
        string jsonData = JsonConvert.SerializeObject(_workItems, Newtonsoft.Json.Formatting.Indented);
        

        File.WriteAllText(FileName, jsonData);

        _workItemsDictionary.Clear();
        foreach (var item in _workItems)
        {
            _workItemsDictionary.Add(item.Id, item);
        }

    }
}
