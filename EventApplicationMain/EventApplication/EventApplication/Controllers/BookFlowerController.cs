using EventApplication.Filters;
using EventApplication.Models;
using EventApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApplication.Controllers
{
    [ValidateUserSession]
    public class BookFlowerController : Controller
    {
        IBookFlowerRepository _IBF;
        IBookingRepository Ibook;
        public BookFlowerController()
        {
            _IBF = new BookFlowerRepository(new EventDBEntities());
            Ibook = new BookingRepository(new EventDBEntities());
        }

        //
        // GET: /BookFlower/

        [HttpPost]
        public JsonResult BookFlower(List<string> SelectedFlowerID)
        {

            try
            {

                if (SelectedFlowerID != null)
                {

                    var result = 0;
                    for (int i = 0; i < SelectedFlowerID.Count(); i++)
                    {
                        BookingFlower BF = new BookingFlower()
                        {
                            FlowerID = Convert.ToInt32(SelectedFlowerID[i]),
                            BookingID = Convert.ToInt32(Session["BookingID"]),
                            Createdby = Convert.ToInt32(Session["UserID"]),
                            CreatedDate = DateTime.Now
                        };
                        Ibook.UpdateCompleted_Event_Status(Convert.ToInt32(Session["BookingID"]), "C");

                        result = _IBF.BookFlower(BF);
                    }

                    if (result > 0)
                    {
                        return Json("Success");
                    }
                    else
                    {
                        return Json("Failed");
                    }
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
