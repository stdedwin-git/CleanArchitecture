using System.Collections.Generic;
using System.Threading.Tasks;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLiveRequestWithDetails(int id);
        Task<List<LeaveRequest>> GetLiveRequestsWithDetails();
        Task ChangeApprovalStatus(LeaveRequest leaveRequest,bool? approvalStatus);
    }
}
