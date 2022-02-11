using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Services.Base;
using System;
using System.Threading.Tasks;

namespace HR.LeaveManagement.MVC.Services
{
    public class LeaveAllocationService : BaseHttpService, ILeaveAllocationService

    {
        private readonly ILocalStorageService _storageService;
        private readonly IClient _httpClient;

        public LeaveAllocationService(ILocalStorageService localStorage, IClient client, ILocalStorageService storageService, IClient httpClient) : base(localStorage, client)
        {
            _storageService = storageService;
            _httpClient = httpClient;
        }

        public async Task<Response<int>> CreateLeaveAllocations(int leaveTypeId)
        {
            try
            {
                var response = new Response<int>();
                CreateLeaveAllocationDto createLeaveAllocationDto = new CreateLeaveAllocationDto()
                {
                    LeaveTypeId = leaveTypeId
                };
                AddBearerToken();
                var apiResponse = await _client.LeaveAllocationsPOSTAsync(createLeaveAllocationDto);
                if (apiResponse.Success)
                {
                    response.Success = true;
                }
                else {
                    foreach (var error in apiResponse.Errors)
                    {
                        response.ValidationErrors += error + Environment.NewLine;
                    }
                }
                return response;
            }
            catch (ApiException  ex)
            {

                ConvertApiExceptions<int>(ex);
            }
        }
    }
}
