using EventApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApplication.Repository
{
    public interface ILightRepository
    {
        void SaveLight(Light Light);
        IEnumerable<Light> ShowLight();
        void DeleteLight(int id);
        Light LightByID(int id);
        void UpdateLight(Light Light);
    }
}
