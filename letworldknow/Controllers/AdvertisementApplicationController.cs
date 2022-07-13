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
    public class AdvertisementApplicationController : ApiController
    {
        AdvertisementApplicationDAL advertisementapplicationDAL = new AdvertisementApplicationDAL();

        [Authorize]
        public HttpResponseMessage Get()//https://localhost:44378/api/advertisementapplication?apiKey=1
        {
            var advertisementapplication = advertisementapplicationDAL.GetAllAdvertisementApplication();
            if (advertisementapplication != null)
                return Request.CreateResponse(HttpStatusCode.OK, advertisementapplication);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Kayıt bulunamadı");
        }

        [Authorize]
        public HttpResponseMessage Get(int id)//https://localhost:44378/api/advertisementapplication/get/1?apiKey=1
        {
            var advertisementapplication = advertisementapplicationDAL.GetAdvertisementApplicationById(id);
            if (advertisementapplication != null)
                return Request.CreateResponse(HttpStatusCode.OK, advertisementapplicationDAL.GetAdvertisementApplicationById(id));
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
        public HttpResponseMessage AdvertisementApplication(AdvertisementApplication advertisementapplication)//https://localhost:44378/api/like?apiKey=1 ---> Content: {"product_name":"BüyükPizza", "image_name":"pizza.jpeg", "detail":"4-6 Kişilik", "price":"80", "discounted_price":"70", "campaign_status":"1", "creation_date":"01.01.2022", "status":"Aktif", "category_id":"1"}
        {
            //validation kurallarını sağlamıyorsa
            if (ModelState.IsValid)
            {
                var createdAdvertisementApplication = advertisementapplicationDAL.CreatedAdvertisementApplication(advertisementapplication);
                return Request.CreateResponse(HttpStatusCode.Created, createdAdvertisementApplication);
            }
            //OK
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [Authorize]
        public HttpResponseMessage Put(int id, AdvertisementApplication advertisementapplication)//https://localhost:44378/api/advertisementapplication/put/3?apiKey=1 ---> Content: {"product_name":"BüyükPizza", "image_name":"pizza.jpeg", "detail":"4-6 Kişilik", "price":"80", "discounted_price":"70", "campaign_status":"1", "creation_date":"01.01.2022", "status":"Aktif", "category_id":"1"}
        {
            //id ye ait kayıt yoksa
            if (!advertisementapplicationDAL.IsThereAnyAdvertisementApplication(id))
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
                return Request.CreateResponse(HttpStatusCode.OK, advertisementapplicationDAL.UpdateAdvertisementApplication(advertisementapplication));
            }
        }

        [Authorize]
        public HttpResponseMessage Delete(int id)//https://localhost:44378/api/like/delete/3?apiKey=1
        {
            //id ye ait kayıt yoksa
            if (advertisementapplicationDAL.IsThereAnyAdvertisementApplication(id) == false)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kayıt bulunamadı");
            }
            //OK
            else
            {
                advertisementapplicationDAL.DeleteAdvertisementApplication(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
        }

    }
}
