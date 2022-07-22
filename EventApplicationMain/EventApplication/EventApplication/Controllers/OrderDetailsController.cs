using EventApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApplication.Controllers
{
    public class OrderDetailsController : Controller
    {
        EventDBEntities _db = new EventDBEntities();

        public ActionResult OrderDisplay(string BookingNo)
        {
            try
            {


                if (BookingNo != null && BookingNo != "0")
                {

                    var BookingDT = (from BD in _db.BookingDetails
                                     where BD.BookingNo == BookingNo
                                     select new { BD.BookingNo, BD.BookingDate, BD.BookingID }).Single();


                    var TotalVenueList = (from BD in _db.BookingVenues
                                          join Vn in _db.Venues on BD.VenueID equals Vn.VenueID
                                          where BD.BookingID == BookingDT.BookingID
                                          select new { Vn.VenueCost, Vn.VenueName }).ToList();

                    var TotalEquipmentList = (from BD in _db.BookingEquipments
                                              join Eq in _db.Equipments on BD.EquipmentID equals Eq.EquipmentID
                                              where BD.BookingID == BookingDT.BookingID
                                              select new { Eq.EquipmentCost, Eq.EquipmentName }).ToList();

                    var TotalFoodList = (from BD in _db.BookingFoods
                                         join Fo in _db.Foods on BD.DishName equals Fo.FoodID
                                         where BD.BookingID == BookingDT.BookingID
                                         select new { Fo.FoodCost, Fo.FoodName, Fo.MealType, Fo.FoodType, Fo.DishType }).ToList();

                    var TotalFlowerList = (from BD in _db.BookingFlowers
                                           join Fl in _db.Flowers on BD.FlowerID equals Fl.FlowerID
                                           where BD.BookingID == BookingDT.BookingID
                                           select new { Fl.FlowerCost, Fl.FlowerName }).ToList();

                    var TotalLightList = (from BD in _db.BookingLights
                                          join Lg in _db.Lights on BD.LightIDSelected equals Lg.LightID
                                          where BD.BookingID == BookingDT.BookingID
                                          select new { Lg.LightCost, Lg.LightName }).ToList();




                    DateTime? BDT = BookingDT.BookingDate;
                    string BookingDate = BDT.Value.ToString("dd/MM/yyyy");

                    var Data = new
                    {
                        BookingNo = BookingDT.BookingNo,
                        BookingDate = BookingDate,
                        TotalVenueList = TotalVenueList,
                        TotalEquipmentList = TotalEquipmentList,
                        TotalFoodList = TotalFoodList,
                        TotalFlowerList = TotalFlowerList,
                        TotalLightList = TotalLightList,
                        TotalAmount = TotalAmount(BookingDT.BookingID)
                    };
                    return new JsonResult { Data = Data };

                }
                else
                {
                    return Json("Failed");
                }
            }
            catch (Exception)
            {
                
                throw;
            }

        }

        public int? TotalAmount(int BookingID=0)
        {
            try
            {
                int? TotalVenueCost = (from BD in _db.BookingVenues
                                       join Vn in _db.Venues on BD.VenueID equals Vn.VenueID
                                       where BD.BookingID == BookingID
                                       select Vn.VenueCost).Sum();

              

                int? TotalEquipmentCost = (from BD in _db.BookingEquipments
                                           join Eq in _db.Equipments on BD.EquipmentID equals Eq.EquipmentID
                                           where BD.BookingID == BookingID
                                           select Eq.EquipmentCost).Sum();

                int? TotalFoodCost = (from BD in _db.BookingFoods
                                      join Fo in _db.Foods on BD.DishName equals Fo.FoodID
                                      where BD.BookingID == BookingID
                                      select Fo.FoodCost).Sum();

                int? TotalFlowerCost = (from BD in _db.BookingFlowers
                                        join Fl in _db.Flowers on BD.FlowerID equals Fl.FlowerID
                                        where BD.BookingID == BookingID
                                        select Fl.FlowerCost).Sum();

                int? TotalLightCost = (from BD in _db.BookingLights
                                       join Lg in _db.Lights on BD.LightIDSelected equals Lg.LightID
                                       where BD.BookingID == BookingID
                                       select Lg.LightCost).Sum();

                int? TotalGuest = (from BD in _db.BookingVenues
                                   join Vn in _db.Venues on BD.VenueID equals Vn.VenueID
                                   where BD.BookingID == BookingID
                                   select BD.GuestCount).SingleOrDefault();




                int? TotalAmount = TotalVenueCost +
                                   TotalEquipmentCost +
                                   TotalFoodCost * TotalGuest +
                                   TotalFlowerCost +
                                   TotalLightCost;

                return TotalAmount;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
