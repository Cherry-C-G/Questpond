using EventApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventApplication.Repository
{
    public class BookEquipmentRepository : IBookEquipmentRepository
    {

        EventDBEntities _db;
        public BookEquipmentRepository(EventDBEntities eventDBEntities)
        {
            _db = eventDBEntities;
        }

        public int BookEquipment(Models.BookingEquipment BookingEquipment)
        {
            try
            {
                if (BookingEquipment != null)
                {
                    _db.BookingEquipments.Add(BookingEquipment);
                    _db.SaveChanges();
                    return BookingEquipment.BookingID;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}