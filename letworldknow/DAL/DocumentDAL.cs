using letworldknow.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace letworldknow.DAL
{
    public class DocumentDAL : BaseDAL
    {

        public IEnumerable<Document> GetAllDocument()
        {
            return db.Document.ToList();
        }

        public IEnumerable<Document> GetDocumentById(int id)
        {
            return db.Document.Where(x => x.id == id).ToList();
        }

        public Document CreatedDocument(Document document)
        {
            db.Document.Add(document);
            db.SaveChanges();
            return document;
        }

        public Document UpdateDocument(Document document)
        {
            db.Entry(document).State = EntityState.Modified;
            //db.SaveChanges();
            return document;
        }

        public void DeleteDocument(int id)
        {
            db.Document.Remove(db.Document.Find(id));
            db.SaveChanges();
        }

        public bool IsThereAnyDocument(int id)
        {
            return db.Document.Any(x => x.id == id);
        }

        internal Document UpdateDocument(object document)
        {
            throw new NotImplementedException();
        }
    }
}