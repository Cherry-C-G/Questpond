using EventApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApplication.Repository
{
    public interface IBookLightRepository
    {
        IEnumerable<Light> LightList(string LightType);
        int BookLight(BookingLight Light);
    }
}
