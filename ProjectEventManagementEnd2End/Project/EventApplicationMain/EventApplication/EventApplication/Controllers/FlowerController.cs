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
    public class FlowerController : Controller
    {
        IFlowerRepository _IFlowerRepository;
       
        public FlowerController()
        {
            _IFlowerRepository = new FlowerRepository(new EventDBEntities());
           
        }

        [HttpPost]
        public JsonResult SaveFlower(string FlowerName, int FlowerCost)
        {
            if (FlowerName != null && FlowerCost != 0)
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

                        Flower objflower = new Flower
                        {
                            FlowerFilename = actualFileName,
                            FlowerFilePath = fileName,
                            FlowerID = 0,
                            FlowerName = FlowerName,
                            FlowerCost = FlowerCost,
                            Createdby = Convert.ToInt32(Session["UserID"])
                        };


                     

                        _IFlowerRepository.SaveFlower(objflower);

                        Message = "Flower Saved Successfully";
                        flag = true;
                    }
                    catch (Exception)
                    {
                        Message = "Flower Save failed! Please try again";
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
        public JsonResult UpdateFlower(string FlowerName, int FlowerID, string file1, int FlowerCost)
        {
            if (FlowerName != null && FlowerCost != 0 && FlowerID != 0 && file1 != null)
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

                        Flower objflower = new Flower
                        {
                            FlowerFilename = actualFileName,
                            FlowerFilePath = fileName,
                            FlowerID = FlowerID,
                            FlowerName = FlowerName,
                            FlowerCost = FlowerCost,
                            Createdby = Convert.ToInt32(Session["UserID"])
                        };

                        _IFlowerRepository.UpdateFlower(objflower);

                    }
                    else
                    {

                        Flower objflower = new Flower
                         {
                             FlowerID = FlowerID,
                             FlowerName = FlowerName,
                             FlowerCost = FlowerCost
                         };



                        _IFlowerRepository.UpdateFlower(objflower);
                    }

                    Message = "Flower Updated Successfully";
                    flag = true;
                }
                catch (Exception)
                {
                    Message = "Flower Update failed! Please try again";
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
