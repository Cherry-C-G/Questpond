using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventApplication.Models;
namespace EventApplication.Repository
{
    interface IEquipmentRepository
    {
        void SaveEquipment(Equipment Equipment);
        IEnumerable<Equipment> ShowEquipment();
        void DeleteEquipment(int id);
        Equipment GetEquipmentByID(int id);
        void UpdateEquipment(Equipment Equipment);
    }
}
