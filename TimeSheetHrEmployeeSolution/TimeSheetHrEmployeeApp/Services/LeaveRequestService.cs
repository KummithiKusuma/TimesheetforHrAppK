using System.Collections.Generic;
using TimeSheetHrEmployeeApp.Exceptions;
using TimeSheetHrEmployeeApp.Interface;
using TimeSheetHrEmployeeApp.Models;
using TimeSheetHrEmployeeApp.Repositories;

namespace TimeSheetHrEmployeeApp.Services
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly IRepository<int, LeaveRequest> _leaverequestRepository;

        public LeaveRequestService(IRepository<int, LeaveRequest> leaverequestRepository)
        {
            _leaverequestRepository = leaverequestRepository;
        }

        /// <summary>
        /// adding leave
        /// </summary>
        /// <param name="leaverequest"></param>
        /// <returns></returns>
        public bool AddLeave(LeaveRequest leaverequest)
        {
            // Create a new LeaveRequest object using the provided data
            var newLeaveRequest = new LeaveRequest
            {
                Username = leaverequest.Username,
                StartDate = leaverequest.StartDate,
                EndDate = leaverequest.EndDate,
                Status = leaverequest.Status
            };

            // Add the new LeaveRequest to the repository
            var result = _leaverequestRepository.Add(newLeaveRequest);

            // Check if the operation was successful
            return result != null;
        }

        /// <summary>
        /// list of requests
        /// </summary>
        /// <returns></returns>
        public IList<LeaveRequest> GetAllLeaves(string username)
        {
            // Retrieve leaves based on the provided username
            var leaves = _leaverequestRepository.GetAll().Where(u => u.Username == username).ToList();
            return leaves.Any() ? leaves.ToList() : null;
        }
    }
}
