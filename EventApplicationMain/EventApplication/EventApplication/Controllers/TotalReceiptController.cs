using EventApplication.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApplication.Controllers
{
    public class TotalReceiptController : Controller
    {
        EventDBEntities _db = new EventDBEntities();
        public ActionResult TotalReceipt(string BookingNo)
        {

            try
            {
                if (BookingNo != null && BookingNo != "0")
                {

                    var BookingDT = (from BD in _db.BookingDetails
                                     where BD.BookingNo == BookingNo
                                     select new { BD.BookingNo, BD.BookingDate, BD.BookingID }).Single();


                    int? TotalVenueCost = (from BD in _db.BookingVenues
                                           join Vn in _db.Venues on BD.VenueID equals Vn.VenueID
                                           where BD.BookingID == BookingDT.BookingID
                                           select Vn.VenueCost).Sum();

                    int? TotalEquipmentCost = (from BD in _db.BookingEquipments
                                               join Eq in _db.Equipments on BD.EquipmentID equals Eq.EquipmentID
                                               where BD.BookingID == BookingDT.BookingID
                                               select Eq.EquipmentCost).Sum();

                  

                    int? TotalFlowerCost = (from BD in _db.BookingFlowers
                                            join Fl in _db.Flowers on BD.FlowerID equals Fl.FlowerID
                                            where BD.BookingID == BookingDT.BookingID
                                            select Fl.FlowerCost).Sum();

                    int? TotalLightCost = (from BD in _db.BookingLights
                                           join Lg in _db.Lights on BD.LightIDSelected equals Lg.LightID
                                           where BD.BookingID == BookingDT.BookingID
                                           select Lg.LightCost).Sum();


                    int? TotalGuest = (from BD in _db.BookingVenues
                                       join Vn in _db.Venues on BD.VenueID equals Vn.VenueID
                                       where BD.BookingID == BookingDT.BookingID
                                       select BD.GuestCount).SingleOrDefault();


                    int? TotalFoodCost = (from BD in _db.BookingFoods
                                          join Fo in _db.Foods on BD.DishName equals Fo.FoodID
                                          where BD.BookingID == BookingDT.BookingID
                                          select Fo.FoodCost).Sum();

                    int? TotalAmount = TotalVenueCost +
                                       TotalEquipmentCost +
                                       TotalFoodCost * TotalGuest +
                                       TotalFlowerCost +
                                       TotalLightCost;

                    DateTime? BDT = BookingDT.BookingDate;
                    string BookingDate = BDT.Value.ToString("dd/MM/yyyy");

                    var Data = new
                    {
                        BookingNo = BookingDT.BookingNo,
                        BookingDate = BookingDate,
                        TotalVenueCost = TotalVenueCost,
                        TotalEquipmentCost = TotalEquipmentCost,
                        TotalFoodCost = TotalFoodCost * TotalGuest,
                        TotalFlowerCost = TotalFlowerCost,
                        TotalLightCost = TotalLightCost,
                        TotalAmount = TotalAmount
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

    }
}
