using EventApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApplication.Repository
{
    interface IRegistrationRepository
    {
        string NEW_Customer(Registration Registration);
        string NEW_Admin(Registration registration);
    }
}
