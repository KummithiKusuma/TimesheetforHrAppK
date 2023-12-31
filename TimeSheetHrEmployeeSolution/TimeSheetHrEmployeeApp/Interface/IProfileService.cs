﻿using TimeSheetHrEmployeeApp.Models;
using TimeSheetHrEmployeeApp.Models.DTO;

namespace TimeSheetHrEmployeeApp.Interface
{
    public interface IProfileService
    {
        bool AddProfile(ProfileDTO profileDTO);
        ProfileDTO UpdateProfile(ProfileDTO profileDTO);
        bool DeleteProfile(string username);
        Profile GetUserProfile(string username);
    }
}