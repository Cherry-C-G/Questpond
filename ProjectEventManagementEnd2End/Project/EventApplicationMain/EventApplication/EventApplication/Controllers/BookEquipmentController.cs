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
    public class BookEquipmentController : Controller
    {
        IBookEquipmentRepository _IBK;
        public BookEquipmentController()
        {
            _IBK = new BookEquipmentRepository(new EventDBEntities());
        }


        //
        // GET: /BookEquipment/

        [HttpPost]
        public JsonResult BookEquipment(List<string> SelectedEquipmentsID)
        {
            try
            {
                if (SelectedEquipmentsID != null)
                {

                    var result = 0;

                    for (int i = 0; i < SelectedEquipmentsID.Count(); i++)
                    {
                        BookingEquipment bk = new BookingEquipment()
                        {
                            EquipmentID = Convert.ToInt32(SelectedEquipmentsID[i]),
                            BookingID = Convert.ToInt32(Session["BookingID"]),
                            Createdby = Convert.ToInt32(Session["UserID"]),
                            CreatedDate = DateTime.Now
                        };

                        result = _IBK.BookEquipment(bk);
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
