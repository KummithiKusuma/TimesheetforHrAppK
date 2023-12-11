using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using TimeSheetHrEmployeeApp.Context;
using TimeSheetHrEmployeeApp.Interface;
using TimeSheetHrEmployeeApp.Models;
using TimeSheetHrEmployeeApp.Models.DTO;
using TimeSheetHrEmployeeApp.Repositories;
using TimeSheetHrEmployeeApp.Services;

namespace TimeSheetHrEmployeeTesting
{
    [TestFixture]
    public class ProfileServiceTest
    {
        IRepository<int, Profile> repository;

        [SetUp]
        public void Setup()
        {
            var dbOptions = new DbContextOptionsBuilder<TimeSheetHrEmployeeContext>()
                               .UseInMemoryDatabase("dbTestCustomer")
                               .Options;
            TimeSheetHrEmployeeContext context = new TimeSheetHrEmployeeContext(dbOptions);
            repository = new ProfileRepository(context);
        }

        [Test]
        public void AddProfileTest()
        {
            IProfileService profileService = new ProfileService(repository);
            var profileDTO = new ProfileDTO
            {
                Username = "testUser",
                FirstName = "Test",
                LastName = "User",
                ContactNumber = "1234567890",
                JobTitle = "Tester",
            };

            // Act
            var result = profileService.AddProfile(profileDTO);

            // Assert
            Assert.IsTrue(result);
        }
        [Test]
        public void GetUserProfileTest()
        {
            IProfileService profileService = new ProfileService(repository);

            // Add a profile for testing
            var profileDTO = new ProfileDTO
            {
                Username = "testUser",
                FirstName = "Test",
                LastName = "User",
                ContactNumber = "1234567890",
                JobTitle = "Tester",
            };
            profileService.AddProfile(profileDTO);

            // Act
            var userProfile = profileService.GetUserProfile("testUser");

            // Assert
            Assert.IsNotNull(userProfile);
            Assert.AreEqual("testUser", userProfile.Username);
            Assert.AreEqual("Test", userProfile.FirstName);
            Assert.AreEqual("User", userProfile.LastName);
            Assert.AreEqual("1234567890", userProfile.ContactNumber);
            Assert.AreEqual("Tester", userProfile.JobTitle);
        }


        [Test]
        public void UpdateProfileTest()
        {
            IProfileService profileService = new ProfileService(repository);

            // Add a profile for testing
            var profileDTO = new ProfileDTO
            {
                Username = "testUser",
                FirstName = "Test",
                LastName = "User",
                ContactNumber = "1234567890",
                JobTitle = "Tester",
            };
            profileService.AddProfile(profileDTO);

            // Act
            profileDTO.FirstName = "UpdatedTest";
            profileDTO.ContactNumber = "9876543210";
            var updatedProfile = profileService.UpdateProfile(profileDTO);

            // Assert
            Assert.IsNotNull(updatedProfile);
            Assert.AreEqual("UpdatedTest", updatedProfile.FirstName);
            Assert.AreEqual("9876543210", updatedProfile.ContactNumber);

            // Additional Assert to verify the updated values in the repository
            var fetchedProfile = repository.GetById(updatedProfile.ProfileId);
            Assert.IsNotNull(fetchedProfile);
            Assert.AreEqual("UpdatedTest", fetchedProfile.FirstName);
            Assert.AreEqual("9876543210", fetchedProfile.ContactNumber);
        }


        [Test]
        public void DeleteProfileTest()
        {
            IProfileService profileService = new ProfileService(repository);

            // Add a profile for testing
            var profileDTO = new ProfileDTO
            {
                Username = "testUser",
                FirstName = "Test",
                LastName = "User",
                ContactNumber = "1234567890",
                JobTitle = "Tester",
            };
            profileService.AddProfile(profileDTO);

            // Act
            var result = profileService.DeleteProfile("testUser");

            // Assert
            Assert.IsTrue(result);
        }
    }
}
