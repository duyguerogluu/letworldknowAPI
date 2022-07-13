using letworldknow.DAL;
using letworldknow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace letworldknow.Controllers
{
    public class AdvertisementController : ApiController
    {
        AdvertisementDAL advertisementDAL = new AdvertisementDAL();

        [Authorize]
        public HttpResponseMessage Get()//https://localhost:44378/api/advertisement?apiKey=1
        {
            var advertisement = advertisementDAL.GetAllAdvertisement();
            if (advertisement != null)
                return Request.CreateResponse(HttpStatusCode.OK, advertisement);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Kayıt bulunamadı");
        }

        [Authorize]
        public HttpResponseMessage Get(int id)//https://localhost:44378/api/advertisement/get/1?apiKey=1
        {
            var advertisement = advertisementDAL.GetAdvertisementById(id);
            if (advertisement != null)
                return Request.CreateResponse(HttpStatusCode.OK, advertisementDAL.GetAdvertisementById(id));
            else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kayıt bulunamadı");
        }

        /* [Authorize]
         public HttpResponseMessage GetCategoryPost(int categoryId)//https://localhost:44378/api/category/getcategorypost/1?apiKey=1
         {
             var product = postDAL.GetPostByCategoryId(categoryId);
             if (product != null)
                 return Request.CreateResponse(HttpStatusCode.OK, postDAL.GetPostsByCategoryId(categoryId));
             else
                 return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kayıt bulunamadı");
         }*/

        [Authorize]
        public HttpResponseMessage Advertisement(Advertisement advertisement)//https://localhost:44378/api/like?apiKey=1 ---> Content: {"product_name":"BüyükPizza", "image_name":"pizza.jpeg", "detail":"4-6 Kişilik", "price":"80", "discounted_price":"70", "campaign_status":"1", "creation_date":"01.01.2022", "status":"Aktif", "category_id":"1"}
        {
            //validation kurallarını sağlamıyorsa
            if (ModelState.IsValid)
            {
                var createdAdvertisement = advertisementDAL.CreatedAdvertisement(advertisement);
                return Request.CreateResponse(HttpStatusCode.Created, createdAdvertisement);
            }
            //OK
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [Authorize]
        public HttpResponseMessage Put(int id, Advertisement advertisement)//https://localhost:44378/api/advertisement/put/3?apiKey=1 ---> Content: {"product_name":"BüyükPizza", "image_name":"pizza.jpeg", "detail":"4-6 Kişilik", "price":"80", "discounted_price":"70", "campaign_status":"1", "creation_date":"01.01.2022", "status":"Aktif", "category_id":"1"}
        {
            //id ye ait kayıt yoksa
            if (!advertisementDAL.IsThereAnyAdvertisement(id))
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Kayıt bulunamadı");
            }
            //validation kurallarını sağlamıyorsa
            else if (ModelState.IsValid == false)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            //OK
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, advertisementDAL.UpdateAdvertisement(advertisement));
            }
        }

        [Authorize]
        public HttpResponseMessage Delete(int id)//https://localhost:44378/api/advertisement/delete/3?apiKey=1
        {
            //id ye ait kayıt yoksa
            if (advertisementDAL.IsThereAnyAdvertisement(id) == false)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kayıt bulunamadı");
            }
            //OK
            else
            {
                advertisementDAL.DeleteAdvertisement(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
        }

    }
}
