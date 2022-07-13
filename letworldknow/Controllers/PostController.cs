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
    public class PostController : ApiController
    {
        PostDAL postDAL = new PostDAL();

        [Authorize]
        public HttpResponseMessage Get()//https://localhost:44378/api/post?apiKey=1
        {
            var post = postDAL.GetAllPosts();
            if (post != null)
                return Request.CreateResponse(HttpStatusCode.OK, post);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Kayıt bulunamadı");
        }

        [Authorize]
        public HttpResponseMessage Get(int id)//https://localhost:44378/api/post/get/1?apiKey=1
        {
            var post = postDAL.GetPostsById(id);
            if (post != null)
                return Request.CreateResponse(HttpStatusCode.OK, postDAL.GetPostsById(id));
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
        public HttpResponseMessage Post(Post post)//https://localhost:44378/api/post?apiKey=1 ---> Content: {"product_name":"BüyükPizza", "image_name":"pizza.jpeg", "detail":"4-6 Kişilik", "price":"80", "discounted_price":"70", "campaign_status":"1", "creation_date":"01.01.2022", "status":"Aktif", "category_id":"1"}
        {
            //validation kurallarını sağlamıyorsa
            if (ModelState.IsValid)
            {
                var createdPost = postDAL.CreatePost(post);
                return Request.CreateResponse(HttpStatusCode.Created, createdPost);
            }
            //OK
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [Authorize]
        public HttpResponseMessage Put(int id, Post post)//https://localhost:44378/api/post/put/3?apiKey=1 ---> Content: {"product_name":"BüyükPizza", "image_name":"pizza.jpeg", "detail":"4-6 Kişilik", "price":"80", "discounted_price":"70", "campaign_status":"1", "creation_date":"01.01.2022", "status":"Aktif", "category_id":"1"}
        {
            //id ye ait kayıt yoksa
            if (!postDAL.IsThereAnyPost(id))
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
                return Request.CreateResponse(HttpStatusCode.OK, postDAL.UpdatePost(post));
            }
        }

        [Authorize]
        public HttpResponseMessage Delete(int id)//https://localhost:44378/api/post/delete/3?apiKey=1
        {
            //id ye ait kayıt yoksa
            if (postDAL.IsThereAnyPost(id) == false)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kayıt bulunamadı");
            }
            //OK
            else
            {
                postDAL.DeletePost(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
        }

    }
}
