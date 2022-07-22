using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApplication.Repository
{
    public interface IBookEquipmentRepository
    {
        int BookEquipment(Models.BookingEquipment BookingEquipment);
    }
}
