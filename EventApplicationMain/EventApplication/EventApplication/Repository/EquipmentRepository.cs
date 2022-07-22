using EventApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace EventApplication.Repository
{
    public class EquipmentRepository : IEquipmentRepository
    {
        EventDBEntities _db;
        public EquipmentRepository(EventDBEntities objcontext)
        {
            _db = objcontext;
        }

        public void SaveEquipment(Models.Equipment Equipment)
        {
            try
            {
                _db.Equipments.Add(Equipment);
                _db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Models.Equipment> ShowEquipment()
        {
            try
            {
                var EquipmentList = from equipment in _db.Equipments select equipment;
                return EquipmentList.ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void DeleteEquipment(int id)
        {
            try
            {
                Equipment equipment = _db.Equipments.Find(id);
                _db.Equipments.Remove(equipment);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public Equipment GetEquipmentByID(int id)
        {
            try
            {

                if (id != 0)
                {
                    return _db.Equipments.Find(id);
                }
                else
                {
                    return new Equipment();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void UpdateEquipment(Equipment Equipment)
        {
            try
            {
                if (Equipment.EquipmentFilename != null)
                {
                    _db.Entry(Equipment).State = System.Data.EntityState.Modified;
                    _db.SaveChanges();
                }
                else
                {
                    _db.Equipments.Attach(Equipment);
                    _db.Entry(Equipment).Property(x => x.EquipmentName).IsModified = true;
                    _db.Entry(Equipment).Property(x => x.EquipmentCost).IsModified = true;
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