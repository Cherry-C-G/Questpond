using EventApplication.Filters;
using EventApplication.Models;
using EventApplication.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventApplication.Controllers
{
    [ValidateAdminSession]
    public class LightController : Controller
    {
        ILightRepository ILightRepository;
        public LightController()
        {
            ILightRepository = new LightRepository(new EventDBEntities());
        }

        [HttpPost]
        public JsonResult SaveLight(Light Light)
        {
            if (Light != null)
            {
                string Message, fileName, actualFileName;
                Message = fileName = actualFileName = string.Empty;
                bool flag = false;
                if (Request.Files != null)
                {
                    var file = Request.Files[0];
                    actualFileName = file.FileName;
                    fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    int size = file.ContentLength;
                    try
                    {
                        file.SaveAs(Path.Combine(Server.MapPath("~/UploadedFiles"), fileName));

                        Light objLight = new Light
                        {
                            LightFilename = actualFileName,
                            LightFilePath = fileName,
                            LightID = 0,
                            LightName = Light.LightName,
                            LightCost = Light.LightCost,
                            LightType = Light.LightType,
                            Createdby = Convert.ToInt32(Session["UserID"])
                        };

                        ILightRepository.SaveLight(objLight);

                        Message = "File uploaded successfully";
                        flag = true;
                    }
                    catch (Exception)
                    {
                        Message = "File upload failed! Please try again";
                    }
                }
                return new JsonResult { Data = new { Message = Message, Status = flag } };
            }
            else
            {
                return Json("Failed");
            }
        }

        [HttpPost]
        public JsonResult UpdateLight(Light Light)
        {

            if (Light != null)
            {
                string Message, fileName, actualFileName;
                Message = fileName = actualFileName = string.Empty;
                bool flag = false;
                try
                {
                    if (Request.Files.Count > 0)
                    {
                        var file = Request.Files[0];
                        actualFileName = file.FileName;
                        fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                        int size = file.ContentLength;
                        file.SaveAs(Path.Combine(Server.MapPath("~/UploadedFiles"), fileName));

                        Light objLight = new Light
                        {
                            LightFilename = actualFileName,
                            LightFilePath = fileName,
                            LightID = Light.LightID,
                            LightName = Light.LightName,
                            LightCost = Light.LightCost,
                            LightType = Light.LightType,
                            Createdby = Convert.ToInt32(Session["UserID"])
                        };
                        ILightRepository.UpdateLight(objLight);
                    }
                    else
                    {
                        Light objLight = new Light
                        {
                            LightID = Light.LightID,
                            LightName = Light.LightName,
                            LightCost = Light.LightCost,
                            LightType = Light.LightType
                        };
                        ILightRepository.UpdateLight(objLight);
                    }
                    Message = "Light Details Updated Successfully";
                    flag = true;
                }
                catch (Exception)
                {
                    Message = "Light Details Update failed! Please try again";
                }
                return new JsonResult { Data = new { Message = Message, Status = flag } };
            }
            else
            {
                return Json("Failed");
            }
        }
    }
}
