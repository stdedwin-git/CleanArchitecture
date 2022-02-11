using System.Collections.Generic;
using System.Threading.Tasks;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveAllocationRepository :IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLiveAllocationWithDetails(int id);
        Task<List<LeaveAllocation>> GetLiveAllocationsWithDetails();
        Task<bool> AllocationExists(string userId, int leaveTypeId, int period);
        Task AddAllocations(List<LeaveAllocation> allocations);
    }
}
