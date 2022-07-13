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
    public class PostTypeController : ApiController
    {
        PostTypeDAL posttypeDAL = new PostTypeDAL();

        [Authorize]
        public HttpResponseMessage Get()//https://localhost:44378/api/posttype?apiKey=1
        {
            var posttype = posttypeDAL.GetAllPostType();
            if (posttype != null)
                return Request.CreateResponse(HttpStatusCode.OK, posttype);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Kayıt bulunamadı");
        }

        [Authorize]
        public HttpResponseMessage Get(int id)//https://localhost:44378/api/posttype/get/1?apiKey=1
        {
            var posttype = posttypeDAL.GetPostTypeById(id);
            if (posttype != null)
                return Request.CreateResponse(HttpStatusCode.OK, posttypeDAL.GetPostTypeById(id));
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
        public HttpResponseMessage PostType(PostType posttype)//https://localhost:44378/api/post?apiKey=1 ---> Content: {"product_name":"BüyükPizza", "image_name":"pizza.jpeg", "detail":"4-6 Kişilik", "price":"80", "discounted_price":"70", "campaign_status":"1", "creation_date":"01.01.2022", "status":"Aktif", "category_id":"1"}
        {
            //validation kurallarını sağlamıyorsa
            if (ModelState.IsValid)
            {
                var createdPostType = posttypeDAL.CreatedPostType(posttype);
                return Request.CreateResponse(HttpStatusCode.Created, createdPostType);
            }
            //OK
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [Authorize]
        public HttpResponseMessage Put(int id, PostType posttype)//https://localhost:44378/api/posttype/put/3?apiKey=1 ---> Content: {"product_name":"BüyükPizza", "image_name":"pizza.jpeg", "detail":"4-6 Kişilik", "price":"80", "discounted_price":"70", "campaign_status":"1", "creation_date":"01.01.2022", "status":"Aktif", "category_id":"1"}
        {
            //id ye ait kayıt yoksa
            if (!posttypeDAL.IsThereAnyPostType(id))
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
                return Request.CreateResponse(HttpStatusCode.OK, posttypeDAL.UpdatePostType(posttype));
            }
        }

        [Authorize]
        public HttpResponseMessage Delete(int id)//https://localhost:44378/api/posttype/delete/3?apiKey=1
        {
            //id ye ait kayıt yoksa
            if (posttypeDAL.IsThereAnyPostType(id) == false)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kayıt bulunamadı");
            }
            //OK
            else
            {
                posttypeDAL.DeletePostType(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
        }

    }
}
