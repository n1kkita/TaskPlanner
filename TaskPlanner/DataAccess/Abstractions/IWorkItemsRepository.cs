
using TaskPlanner.Domain.Models.Classes;

namespace TaskPlanner.DataAccess
{
    public interface IWorkItemsRepository
    {
        Guid Add(WorkItem workItem);
        WorkItem getItemFromHashTableByGuid(Guid id);
        WorkItem[] GetAll();
        bool Update(WorkItem workItem);
        bool Remove(Guid id);
        void SaveChanges();
    }
}
