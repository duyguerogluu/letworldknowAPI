using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using letworldknow.Models;

namespace letworldknow.DAL
{
    public class AdminDAL : BaseDAL
    {
        public Admin GetAdminByApiKey(string apiKey)
        {
            return db.Admin.FirstOrDefault(x => x.admin_key.ToString() == apiKey);
        }
    }
}