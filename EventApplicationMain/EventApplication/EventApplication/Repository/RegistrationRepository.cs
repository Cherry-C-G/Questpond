using EventApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventApplication.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        EventDBEntities _db;
        public RegistrationRepository(EventDBEntities eventDBEntities)
        {
            _db = eventDBEntities;
        }

        public string NEW_Customer(Registration registration)
        {
            try
            {
                var RoleID = (from role in _db.Roles
                              where role.RoleID == 2
                              select role.RoleID).Single();

                var registrationdata = registration;
                registrationdata.RoleID = RoleID;

                _db.Registrations.Add(registrationdata);
                _db.SaveChanges();

                return "Success";
            }
            catch (Exception)
            {
                return "Fail";
                throw;
            }
        }

        public string NEW_Admin(Registration registration)
        {
            try
            {
                var RoleID = (from role in _db.Roles
                              where role.RoleID == 1
                              select role.RoleID).Single();

                var registrationdata = registration;
                registrationdata.RoleID = RoleID;

                _db.Registrations.Add(registrationdata);
                _db.SaveChanges();

                return "Success";
            }
            catch (Exception)
            {
                return "Fail";
                throw;
            }
        }
    }
}