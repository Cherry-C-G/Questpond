using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EventApplication.Models;
namespace EventApplication.Repository
{
    public class LoginRepository : ILoginRepository
    {
        EventDBEntities _db;
        public LoginRepository(EventDBEntities objcontext)
        {
            _db = objcontext;
        }

        public Registration ValidateUser(string Username, string Password)
        {
            try
            {
                var validate = (from user in _db.Registrations
                                where user.Username == Username && user.Password == Password
                                select user).SingleOrDefault();

                return validate;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}