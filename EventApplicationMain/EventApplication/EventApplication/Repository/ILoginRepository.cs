using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventApplication.Models;
namespace EventApplication.Repository
{
     interface ILoginRepository
    {
        Registration ValidateUser(string Username, string Password);
    }
}
