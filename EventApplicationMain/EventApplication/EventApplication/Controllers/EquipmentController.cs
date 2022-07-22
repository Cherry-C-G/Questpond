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
    public class EquipmentController : Controller
    {
        IEquipmentRepository _IEquipmentRepository;
        public EquipmentController()
        {
            _IEquipmentRepository = new EquipmentRepository(new EventDBEntities());
        }

        [HttpPost]
        public JsonResult SaveEquipment(Equipment Equipment)
        {
            if (Equipment != null)
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

                        Equipment objEqu = new Equipment
                        {
                            EquipmentFilename = actualFileName,
                            EquipmentFilePath = fileName,
                            EquipmentID = 0,
                            EquipmentName = Equipment.EquipmentName,
                            EquipmentCost = Equipment.EquipmentCost,
                            Createdby = Convert.ToInt32(Session["UserID"])
                        };

                        _IEquipmentRepository.SaveEquipment(objEqu);

                        Message = "Equipments Saved successfully";
                        flag = true;
                    }
                    catch (Exception)
                    {
                        Message = "Equipments Save failed! Please try again";
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
        public JsonResult UpdateEquipment(Equipment Equipment)
        {
            if (Equipment != null)
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

                        Equipment objEqu = new Equipment
                        {
                            EquipmentFilename = actualFileName,
                            EquipmentFilePath = fileName,
                            EquipmentID = Equipment.EquipmentID,
                            EquipmentName = Equipment.EquipmentName,
                            EquipmentCost = Equipment.EquipmentCost,
                            Createdby = Convert.ToInt32(Session["UserID"])
                        };

                        _IEquipmentRepository.UpdateEquipment(objEqu);

                    }
                    else
                    {

                        Equipment objEqu = new Equipment
                        {
                            EquipmentID = Equipment.EquipmentID,
                            EquipmentName = Equipment.EquipmentName,
                            EquipmentCost = Equipment.EquipmentCost
                        };
                        _IEquipmentRepository.UpdateEquipment(objEqu);
                    }

                    Message = "Equipment Updated Successfully";
                    flag = true;
                }
                catch (Exception)
                {
                    Message = "Equipment Update failed! Please try again";
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
