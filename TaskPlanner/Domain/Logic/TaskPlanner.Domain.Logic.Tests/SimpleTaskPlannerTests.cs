using TaskPlanner.DataAccess; // Замість TaskPlanner.Domain.Logic, якщо інтерфейс тут
using Moq;
using Xunit;
using TaskPlanner.Domain.Models.Classes;
using TaskPlanner.Domain.Models.Enums;

namespace TaskPlanner.Domain.Logic.Tests
{
    public class SimpleTaskPlannerTests

    {
        List<WorkItem> workItems = new List<WorkItem> {
                new WorkItem { Id = Guid.NewGuid(), Title = "Task A", Priority = Priority.High, DueDate = new DateTime(2024, 12, 1) }, // 3
                new WorkItem { Id = Guid.NewGuid(), Title = "Task B", Priority = Priority.High, DueDate = new DateTime(2024, 10, 15) }, // 4
                new WorkItem { Id = Guid.NewGuid(), Title = "Task C", Priority = Priority.Urgent, DueDate = new DateTime(2024, 11, 5) }, // 1
                new WorkItem { Id = Guid.NewGuid(), Title = "Task D", Priority = Priority.Low, DueDate = new DateTime(2024, 12, 1) }, // 5
                new WorkItem { Id = Guid.NewGuid(), Title = "Task E", Priority = Priority.Low, DueDate = new DateTime(2024, 9, 21) }, // 6
                new WorkItem { Id = Guid.NewGuid(), Title = "Task G", Priority = Priority.Urgent, DueDate = new DateTime(2023, 11, 5) } // 2
        };

        
        [Fact]
        public void CreatePlanShouldSortTasksCorrectly()
        {
             
            var mockRepo = new Mock<IWorkItemsRepository>();
     
            mockRepo.Setup(repo => repo.GetAll()).Returns(workItems.ToArray()); 

            var planner = new SimpleTaskPlanner(mockRepo.Object);
            var sortedPlan = planner.CreatePlan();

            Assert.Equal("Task C", sortedPlan[0].Title); 
            Assert.Equal("Task G", sortedPlan[1].Title); 
            Assert.Equal("Task A", sortedPlan[2].Title);
            Assert.Equal("Task B", sortedPlan[3].Title);
            Assert.Equal("Task D", sortedPlan[4].Title);
            Assert.Equal("Task E", sortedPlan[5].Title);
        }

        [Fact]
        public void FileWorkItemRepositorySavedTest()
        {

            var fileWorkItemsRepository = new FileWorkItemsRepository();
            fileWorkItemsRepository.RemoveAll();

            foreach (var workItem in workItems)
            {

                fileWorkItemsRepository.Add(workItem);
            }


            Assert.Equal(6, fileWorkItemsRepository.GetAll().Length);

        }

        [Fact]
        public void FileWorkItemRepositoryCheckHashTable()
        {

            var fileWorkItemsRepository = new FileWorkItemsRepository();
            Guid searchedId = fileWorkItemsRepository.GetAll()[0].Id;

            

            Assert.Equal(searchedId, fileWorkItemsRepository.getItemFromHashTableByGuid(searchedId).Id);

        }

       

    }
}
