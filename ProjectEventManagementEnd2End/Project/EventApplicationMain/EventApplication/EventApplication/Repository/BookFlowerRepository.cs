using EventApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventApplication.Repository
{
    public class BookFlowerRepository : IBookFlowerRepository
    {
        EventDBEntities _db;
        public BookFlowerRepository(EventDBEntities eventDBEntities)
        {
            _db = eventDBEntities;
        }

        public int BookFlower(Models.BookingFlower BookingFlower)
        {
            try
            {
                if (BookingFlower != null)
                {
                    _db.BookingFlowers.Add(BookingFlower);
                    _db.SaveChanges();
                    return BookingFlower.BookingFlowerID;
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