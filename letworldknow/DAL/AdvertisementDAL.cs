using letworldknow.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace letworldknow.DAL
{
    public class AdvertisementDAL : BaseDAL
    {

        public IEnumerable<Advertisement> GetAllAdvertisement()
        {
            return db.Advertisement.ToList();
        }

        public IEnumerable<Advertisement> GetAdvertisementById(int id)
        {
            return db.Advertisement.Where(x => x.id == id).ToList();
        }

        public Advertisement CreatedAdvertisement(Advertisement advertisement)
        {
            db.Advertisement.Add(advertisement);
            db.SaveChanges();
            return advertisement;
        }

        public Advertisement UpdateAdvertisement(Advertisement advertisement)
        {
            db.Entry(advertisement).State = EntityState.Modified;
            //db.SaveChanges();
            return advertisement;
        }

        public void DeleteAdvertisement(int id)
        {
            db.Advertisement.Remove(db.Advertisement.Find(id));
            db.SaveChanges();
        }

        public bool IsThereAnyAdvertisement(int id)
        {
            return db.Advertisement.Any(x => x.id == id);
        }

    }
}