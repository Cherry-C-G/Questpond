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
    public class BookFoodController : Controller
    {
        IBookFoodRepository _IBF;
        public BookFoodController()
        {
            _IBF = new BookFoodRepository(new EventDBEntities());
        }

        public JsonResult ShowFoodList(Food Food)
        {
            try
            {

                if (Food != null)
                {
                    var FoodList = _IBF.FoodList(Food);
                    return Json(FoodList, JsonRequestBehavior.AllowGet);
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

        public JsonResult BookFood(BookingFood Food, List<string> SelectedFood)
        {
            try
            {
                if (Food != null && SelectedFood != null)
                {
                    var result = 0;

                    for (int i = 0; i < SelectedFood.Count(); i++)
                    {
                        BookingFood objFood = new BookingFood()
                        {
                            FoodType = Food.FoodType,
                            MealType = Food.MealType,
                            DishType = Food.DishType,
                            DishName = Convert.ToInt32(SelectedFood[i]),
                            BookingID = Convert.ToInt32(Session["BookingID"]),
                            Createdby = Convert.ToInt32(Session["UserID"]),
                            CreatedDate = DateTime.Now
                        };
                        result = _IBF.BookFood(objFood);
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
