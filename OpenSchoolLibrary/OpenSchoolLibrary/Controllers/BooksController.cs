using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OpenSchoolLibrary.Domain;
using OpenSchoolLibrary.Models;
using OpenSchoolLibrary.Models.BooksViewModels;
using System.Collections;

namespace OpenSchoolLibrary.Controllers
{
    public class BooksController : Controller
    {
        private LibraryContext db = new LibraryContext();

        public enum BookConditions
        {
            Excellent,
            Good,
            Fair,
            Used,
            Bad
        }

        enum NewBookStatus
        {
            Unknown,
            Add,
            Increment
        }

        // GET: Books
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Add()
        {

            var model = new AddBookViewModel()
            {
                GenreList = new SelectList(db.Generes.Select(b => new { b.ID, b.Name }).ToList(), "ID", "Name"),
                Entry = NewBookStatus.Unknown
            };
            

            return View(model);
        }

        

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddBookViewModel book)
        {
            if (ModelState.IsValid)
            {
                //db.Books.Add(book);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        // GET: ISBN Check
        [HttpGet]
        public ActionResult ISBNCheck(string isbn, long? isbn13)
        {
            var isbnResult = CheckForExistingISBN(isbn);

            var isbn13Result = CheckForExistingISBN13(isbn13);

            

            var model = new AddBookViewModel()
            {
                GenreList = new SelectList(db.Generes.Select(b => new { b.ID, b.Name }).ToList(), "ID", "Name"),
                Entry = NewBookStatus.Add
            };

            return View("Add", model);
        }

        public bool CheckForExistingISBN(string isbn) => db.Books.Any(b => b.ISBN == isbn);

        public bool CheckForExistingISBN13(long? isbn13) => db.Books.Any(b => b.ISBN13 == isbn13);

        //TODO
        //public bool CheckForExistingISBN13(long isbn13)
        //{

        //}

        // POST: Books
        [HttpPost]
        public ActionResult IncrementBook()
        {
            return View();
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,SubTitle,Author,ISBN,ISBN13,Condition,CatalogID,Genre")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
