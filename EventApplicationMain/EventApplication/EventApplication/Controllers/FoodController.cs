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
    public class FoodController : Controller
    {
        IFoodRepository _IFoodRepository;
        public FoodController()
        {
            _IFoodRepository = new FoodRepository(new EventDBEntities());
        }


        [HttpPost]
        public JsonResult SaveFood(Food Food)
        {
            if (Food != null)
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

                        Food objfood = new Food
                        {
                            FoodFilename = actualFileName,
                            FoodFilePath = fileName,
                            FoodID = 0,
                            FoodName = Food.FoodName,
                            FoodCost = Food.FoodCost,
                            FoodType = Food.FoodType,
                            MealType = Food.MealType,
                            DishType = Food.DishType,
                            Createdby = Convert.ToInt32(Session["UserID"])
                        };

                        _IFoodRepository.SaveFood(objfood);

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
        public JsonResult UpdateFood(Food Food)
        {
            if (Food != null)
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

                        Food objFood = new Food
                        {
                            FoodType = Food.FoodType,
                            MealType = Food.MealType,
                            DishType = Food.DishType,
                            FoodName = Food.FoodName,
                            FoodFilename = actualFileName,
                            FoodFilePath = fileName,
                            FoodID = Food.FoodID,
                            FoodCost = Food.FoodCost,
                            Createdby = Convert.ToInt32(Session["UserID"])
                        };
                        _IFoodRepository.UpdateFood(objFood);

                    }
                    else
                    {
                        Food objFood = new Food
                        {
                            FoodID = Food.FoodID,
                            FoodName = Food.FoodName,
                            FoodType = Food.FoodType,
                            MealType = Food.MealType,
                            DishType = Food.DishType,
                            FoodCost = Food.FoodCost
                        };
                        _IFoodRepository.UpdateFood(objFood);
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
