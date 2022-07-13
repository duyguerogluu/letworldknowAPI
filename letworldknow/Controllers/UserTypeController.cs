using letworldknow.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using letworldknow.Models;

namespace letworldknow.Controllers
{
    public class UserTypeController : ApiController
    {
        UserTypeDAL userTypeDAL = new UserTypeDAL();

        [Authorize]
        public HttpResponseMessage Get()//https://localhost:44378/api/usertype?apiKey=1
        {
            var userType = userTypeDAL.GetAllUserType();
            if (userType != null)
                return Request.CreateResponse(HttpStatusCode.OK, userType);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Kayıt bulunamadı");
        }

        [Authorize]
        public HttpResponseMessage Get(int id)//https://localhost:44378/api/usertype/get/1?apiKey=1
        {
            var userType = userTypeDAL.GetUserTypeById(id);
            if (userType != null)
                return Request.CreateResponse(HttpStatusCode.OK, userTypeDAL.GetUserTypeById(id));
            else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kayıt bulunamadı");
        }

        [Authorize]
        public HttpResponseMessage Post(UserType userType)//https://localhost:44378/api/usertype?apiKey=1 ---> Content: {"type_name":"Fırın"}
        {
            //validation kurallarını sağlamıyorsa
            if (ModelState.IsValid)
            {
                var createdUserType = userTypeDAL.CreateUserType(userType);
                return Request.CreateResponse(HttpStatusCode.Created, createdUserType);
            }
            //OK
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [Authorize]
        public HttpResponseMessage Put(int id, UserType userType)//https://localhost:44378/api/usertype/put/3?apiKey=1 ---> Content: {"type_name":"Fırın"}
        {
            //id ye ait kayıt yoksa
            if (!userTypeDAL.IsThereAnyUserType(id))
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
                return Request.CreateResponse(HttpStatusCode.OK, userTypeDAL.UpdateUserType(userType));
            }
        }

        [Authorize]
        public HttpResponseMessage Delete(int id)//https://localhost:44378/api/usertype/delete/3?apiKey=1
        {
            //id ye ait kayıt yoksa
            if (userTypeDAL.IsThereAnyUserType(id) == false)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kayıt bulunamadı");
            }
            //OK
            else
            {
                userTypeDAL.DeleteUserType(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
        }

    }
}
