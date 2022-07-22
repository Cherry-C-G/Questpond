using EventApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventApplication.Repository
{
    public class FlowerRepository : IFlowerRepository
    {
        EventDBEntities _db;
        public FlowerRepository(EventDBEntities EventDBEntities)
        {
            _db = EventDBEntities;
        }

        public void SaveFlower(Models.Flower Flower)
        {
            try
            {
                _db.Flowers.Add(Flower);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void UpdateFlower(Models.Flower Flower)
        {
            try
            {
                if (Flower.FlowerFilename != null)
                {
                    _db.Entry(Flower).State = System.Data.EntityState.Modified;
                    _db.SaveChanges();
                }
                else
                {
                    _db.Flowers.Attach(Flower);
                    _db.Entry(Flower).Property(x => x.FlowerName).IsModified = true;
                    _db.Entry(Flower).Property(x => x.FlowerCost).IsModified = true;
                    _db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Models.Flower> ShowFlower()
        {
            try
            {
                return (from flower in _db.Flowers
                        select flower).ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void DeleteFlower(int id)
        {
            try
            {
                Flower flower = _db.Flowers.Find(id);
                _db.Flowers.Remove(flower);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public Models.Flower FlowerByID(int id)
        {
            try
            {
                Flower Flower = _db.Flowers.Find(id);
                return Flower;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}