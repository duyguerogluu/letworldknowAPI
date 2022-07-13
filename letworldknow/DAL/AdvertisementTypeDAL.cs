using letworldknow.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace letworldknow.DAL
{
    public class AdvertisementTypeDAL : BaseDAL
    {

        public IEnumerable<AdvertisementType> GetAllAdvertisementType()
        {
            return db.AdvertisementType.ToList();
        }

        public IEnumerable<AdvertisementType> GetAdvertisementTypeById(int id)
        {
            return db.AdvertisementType.Where(x => x.id == id).ToList();
        }

        public AdvertisementType CreatedLike(AdvertisementType advertisementtype)
        {
            db.AdvertisementType.Add(advertisementtype);
            db.SaveChanges();
            return advertisementtype;
        }

        public AdvertisementType UpdateAdvertisementType(AdvertisementType advertisementtype)
        {
            db.Entry(advertisementtype).State = EntityState.Modified;
            //db.SaveChanges();
            return advertisementtype;
        }

        public void DeleteAdvertisementType(int id)
        {
            db.AdvertisementType.Remove(db.AdvertisementType.Find(id));
            db.SaveChanges();
        }

        public bool IsThereAnyAdvertisementType(int id)
        {
            return db.AdvertisementType.Any(x => x.id == id);
        }

    }
}