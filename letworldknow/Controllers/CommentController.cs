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
    public class CommentController : ApiController
    {
        CommentDAL commentDAL = new CommentDAL();

        [Authorize]
        public HttpResponseMessage Get()//https://localhost:44378/api/comment?apiKey=1
        {
            var comment = commentDAL.GetAllComment();
            if (comment != null)
                return Request.CreateResponse(HttpStatusCode.OK, comment);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Kayıt bulunamadı");
        }

        [Authorize]
        public HttpResponseMessage Get(int id)//https://localhost:44378/api/comment/get/1?apiKey=1
        {
            var comment = commentDAL.GetCommentById(id);
            if (comment != null)
                return Request.CreateResponse(HttpStatusCode.OK, commentDAL.GetCommentById(id));
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
        public HttpResponseMessage Comment(Comment comment)//https://localhost:44378/api/comment?apiKey=1 ---> Content: {"product_name":"BüyükPizza", "image_name":"pizza.jpeg", "detail":"4-6 Kişilik", "price":"80", "discounted_price":"70", "campaign_status":"1", "creation_date":"01.01.2022", "status":"Aktif", "category_id":"1"}
        {
            //validation kurallarını sağlamıyorsa
            if (ModelState.IsValid)
            {
                var createdComment = commentDAL.CreatedComment(comment);
                return Request.CreateResponse(HttpStatusCode.Created, createdComment);
            }
            //OK
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [Authorize]
        public HttpResponseMessage Put(int id, Comment comment)//https://localhost:44378/api/comment/put/3?apiKey=1 ---> Content: {"product_name":"BüyükPizza", "image_name":"pizza.jpeg", "detail":"4-6 Kişilik", "price":"80", "discounted_price":"70", "campaign_status":"1", "creation_date":"01.01.2022", "status":"Aktif", "category_id":"1"}
        {
            //id ye ait kayıt yoksa
            if (!commentDAL.IsThereAnyComment(id))
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
                return Request.CreateResponse(HttpStatusCode.OK, commentDAL.UpdateComment(comment));
            }
        }

        [Authorize]
        public HttpResponseMessage Delete(int id)//https://localhost:44378/api/comment/delete/3?apiKey=1
        {
            //id ye ait kayıt yoksa
            if (commentDAL.IsThereAnyComment(id) == false)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kayıt bulunamadı");
            }
            //OK
            else
            {
                commentDAL.DeleteComment(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
        }

    }
}
