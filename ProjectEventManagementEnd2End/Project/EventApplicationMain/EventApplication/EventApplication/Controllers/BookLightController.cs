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
    public class BookLightController : Controller
    {
        IBookLightRepository _IBL;
        public BookLightController()
        {
            _IBL = new BookLightRepository(new EventDBEntities());
        }

        public JsonResult ShowFoodList(Light Light)
        {
            try
            {
                var LightingList = _IBL.LightList(Light.LightType);
                return Json(LightingList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public JsonResult BookLight(BookingLight objLight, List<string> SelectedLight)
        {
            try
            {
                if (objLight != null && SelectedLight != null)
                {
                    var result = 0;

                    for (int i = 0; i < SelectedLight.Count(); i++)
                    {
                        BookingLight objBL = new BookingLight()
                        {
                            LightType = objLight.LightType,
                            LightIDSelected = Convert.ToInt32(SelectedLight[i]),
                            BookingID = Convert.ToInt32(Session["BookingID"]),
                            Createdby = Convert.ToInt32(Session["UserID"]),
                            CreatedDate = DateTime.Now
                        };
                        result = _IBL.BookLight(objBL);
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
