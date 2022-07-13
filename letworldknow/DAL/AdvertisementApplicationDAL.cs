using letworldknow.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace letworldknow.DAL
{
    public class AdvertisementApplicationDAL :BaseDAL
    {

        public IEnumerable<AdvertisementApplication> GetAllAdvertisementApplication()
        {
            return db.AdvertisementApplication.ToList();
        }

        public IEnumerable<AdvertisementApplication> GetAdvertisementApplicationById(int id)
        {
            return db.AdvertisementApplication.Where(x => x.id == id).ToList();
        }

        public AdvertisementApplication CreatedAdvertisementApplication(AdvertisementApplication advertisementapplication)
        {
            db.AdvertisementApplication.Add(advertisementapplication);
            db.SaveChanges();
            return advertisementapplication;
        }

        public AdvertisementApplication UpdateAdvertisementApplication(AdvertisementApplication advertisementapplication)
        {
            db.Entry(advertisementapplication).State = EntityState.Modified;
            //db.SaveChanges();
            return advertisementapplication;
        }

        public void DeleteAdvertisementApplication(int id)
        {
            db.AdvertisementApplication.Remove(db.AdvertisementApplication.Find(id));
            db.SaveChanges();
        }

        public bool IsThereAnyAdvertisementApplication(int id)
        {
            return db.AdvertisementApplication.Any(x => x.id == id);
        }

    }
}