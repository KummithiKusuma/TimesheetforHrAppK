﻿using Microsoft.EntityFrameworkCore;
using TimeSheetHrEmployeeApp.Context;
using TimeSheetHrEmployeeApp.Interface;
using TimeSheetHrEmployeeApp.Models;

namespace TimeSheetHrEmployeeApp.Repositories
{
    public class ProfileRepository : IRepository<int, Profile>
    {
        private readonly TimeSheetHrEmployeeContext _context;

        public ProfileRepository(TimeSheetHrEmployeeContext context)
        {
            _context = context;
        }

        public Profile Add(Profile entity)
        {
            _context.Profiles.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Profile Delete(int key)
        {
            var profile = GetById(key);
            if (profile != null)
            {
                _context.Profiles.Remove(profile);
                _context.SaveChanges();
                return profile;
            }
            return null;
        }

        public IList<Profile> GetAll()
        {
            if (_context.Profiles.Count() == 0)
                return null;
            return _context.Profiles.ToList();
        }

        public Profile GetById(int key)
        {
            var profile = _context.Profiles.SingleOrDefault(p => p.ProfileId == key);
            return profile;
        }

        public Profile Update(Profile entity)
        {
            var existingProfile = GetById(entity.ProfileId);
            if (existingProfile != null)
            {
                _context.Entry<Profile>(existingProfile).State = EntityState.Modified;
                _context.SaveChanges();
                return existingProfile;
            }
            return null;
        }
    }
}