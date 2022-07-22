using EventApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace EventApplication.Repository
{
    public class BookFoodRepository : IBookFoodRepository
    {
        EventDBEntities _db;
        public BookFoodRepository(EventDBEntities EventDBEntities)
        {
            _db = EventDBEntities;
        }

        public IEnumerable<Food> FoodList(Food Food)
        {
            try
            {

                if (Food != null)
                {
                    var FoodList = (from tempfood in _db.Foods
                                    where tempfood.FoodType == Food.FoodType && tempfood.MealType == Food.MealType && tempfood.DishType == Food.DishType
                                    select tempfood).ToList();
                    return FoodList;
                }
                else
                {
                    return Enumerable.Empty<Food>();
                }
            }
            catch (Exception)
            {
                
                throw;
            }

        }

        public int BookFood(BookingFood Food)
        {
            try
            {
                _db.BookingFoods.Add(Food);
                return _db.SaveChanges();
            }
            catch (Exception)
            {
                
                throw;
            }
        }


    }
}