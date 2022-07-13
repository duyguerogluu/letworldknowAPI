using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace letworldknow.DAL
{
        public class BaseDAL
        {
            protected Models.LetWorldKnowEntities db;
            public BaseDAL()
            {
                db = new Models.LetWorldKnowEntities();
            }
        }
}