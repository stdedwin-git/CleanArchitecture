using HR.LeaveManagement.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Persistence.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLiveRequestWithDetails(int id);
        Task<List<LeaveRequest>> GetLiveRequestsWithDetails();
        Task ChangeApporvalStatus(LeaveRequest leaveRequest,bool? ApprovalStatus);
    }
}
