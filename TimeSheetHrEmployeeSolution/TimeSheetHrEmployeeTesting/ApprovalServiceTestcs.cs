using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;
using TimeSheetHrEmployeeApp.Context;
using TimeSheetHrEmployeeApp.Interface;
using TimeSheetHrEmployeeApp.Models;
using TimeSheetHrEmployeeApp.Repositories;
using TimeSheetHrEmployeeApp.Services;

namespace TimeSheetHrEmployeeTesting
{
    [TestFixture]
    public class ApprovalServiceTest
    {
        IRepository<int, Approval> repository;

        [SetUp]
        public void Setup()
        {
            var dbOptions = new DbContextOptionsBuilder<TimeSheetHrEmployeeContext>()
                               .UseInMemoryDatabase("dbTestCustomer")
                               .Options;
            TimeSheetHrEmployeeContext context = new TimeSheetHrEmployeeContext(dbOptions);
            repository = new ApprovalRepository(context);
        }

        [Test]
        public void AddApprovalTest()
        {
            IApprovalService approvalService = new ApprovalService(repository);
            var approval = new Approval
            {
                Approvedby = "jhon",
                AprrovedDate = DateTime.Now.AddDays(1),
                Status = "Approved",
                Comment = "No"
            };
            var result = approvalService.AddApproval(approval);

            // Assert
            Assert.IsTrue(result);
        }
        [Test]
        public void GetAllApprovalsTest()
        {
            IApprovalService approvalService = new ApprovalService(repository);

            // Add some approvals for testing
            var approval1 = new Approval
            {
                Approvedby = "user1",
                AprrovedDate = DateTime.Now.AddDays(1),
                Status = "Approved",
                Comment = "No",
                TimesheetID = 1 // Assigning a TimesheetID for testing
            };
            var approval2 = new Approval
            {
                Approvedby = "user2",
                AprrovedDate = DateTime.Now.AddDays(2),
                Status = "Pending",
                Comment = "Yes",
                TimesheetID = 1 // Assigning a TimesheetID for testing
            };
            approvalService.AddApproval(approval1);
            approvalService.AddApproval(approval2);

            // Act
            var approvals = approvalService.GetAllApprovals(1); // Assuming TimesheetID is 1

            // Assert
            Assert.IsNotNull(approvals);
            Assert.That(approvals.Count, Is.EqualTo(2));
            Assert.IsTrue(approvals.Any(a => a.Approvedby == "user1"));
            Assert.IsTrue(approvals.Any(a => a.Approvedby == "user2"));
            Assert.That(approvals[0].Status, Is.EqualTo("Approved"));
            Assert.That(approvals[1].Status, Is.EqualTo("Pending"));
        }

    }
}
