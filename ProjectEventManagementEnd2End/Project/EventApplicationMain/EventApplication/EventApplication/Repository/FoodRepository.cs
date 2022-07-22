using EventApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventApplication.Repository
{
    public class FoodRepository : IFoodRepository
    {

        EventDBEntities _db;
        public FoodRepository(EventDBEntities EventDBEntities)
        {
            _db = EventDBEntities;
        }

        public void SaveFood(Models.Food Food)
        {
            try
            {
                _db.Foods.Add(Food);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public IEnumerable<Models.Food> ShowFood()
        {
            try
            {
                var foodlist = (from foods in _db.Foods select foods);
                return foodlist.ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void DeleteFood(int id)
        {
            try
            {
                Food Food = _db.Foods.Find(id);
                _db.Foods.Remove(Food);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public Food FoodByID(int id)
        {
            try
            {
                return _db.Foods.Find(id);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void UpdateFood(Food Food)
        {

            try
            {
                if (Food.FoodFilename != null)
                {
                    _db.Entry(Food).State = System.Data.EntityState.Modified;
                    _db.SaveChanges();
                }
                else
                {
                    _db.Foods.Attach(Food);
                    _db.Entry(Food).Property(x => x.FoodName).IsModified = true;
                    _db.Entry(Food).Property(x => x.FoodType).IsModified = true;
                    _db.Entry(Food).Property(x => x.DishType).IsModified = true;
                    _db.Entry(Food).Property(x => x.FoodCost).IsModified = true;
                    _db.Entry(Food).Property(x => x.MealType).IsModified = true;
                    _db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}