using HR.LeaveManagement.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Persistence.Contracts
{
    public interface ILeaveAllocationRepository :IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLiveAllocationWithDetails(int id);
        Task<List<LeaveAllocation>> GetLiveAllocationsWithDetails();
    }
}
