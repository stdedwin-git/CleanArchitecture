using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Moq;
using System.Collections.Generic;

namespace HR.LeaveManagement.Application.UnitTests.Mocks
{
    public static class MockLeaveTypeRepository
    {
        public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
        {
            var leaveTypes = new List<LeaveType> 
            { 
                new LeaveType { Id = 1, Name ="Test vacation", DefaultDays = 10},
                new LeaveType { Id = 1, Name ="Test Sick", DefaultDays = 15}
            };

            var mockRepo = new Mock<ILeaveTypeRepository>();
            mockRepo.Setup(x => x.GetAll()).ReturnsAsync(leaveTypes);
            mockRepo.Setup(r => r.Add(It.IsAny<LeaveType>())).ReturnsAsync((LeaveType leaveType) => { leaveTypes.Add(leaveType); return leaveType;});
            

            return mockRepo;
        }
    }
}
