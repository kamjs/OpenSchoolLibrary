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
using OpenSchoolLibrary.Domain.Validations;
using System.Collections;

namespace OpenSchoolLibrary.Controllers
{
    public class BooksController : Controller
    {
        private LibraryContext db = new LibraryContext();

        public BooksController(LibraryContext db)
        {
            this.db = db;
        }

        public BooksController()
        {

        }

        public enum BookConditions
        {
            Excellent,
            Good,
            Fair,
            Used,
            Bad
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


        // GET: Books/Add
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }


        // POST: Books/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(string isbn, string isbn13)
        {
            if (isbn == "" && isbn13 == "")
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Both ISBNs were blank. Do not disable JavaScript and please try again.");

            if (BookAlreadyExists(isbn, isbn13))
            {
                return Redirect($@"/Books/IncrementBook/?isbn={HttpUtility.UrlEncode(isbn)}&isbn13={HttpUtility.UrlEncode(isbn13)}");
            }
            else
            {
                return Redirect($@"/Books/AddNewBook/?isbn={HttpUtility.UrlEncode(isbn)}&isbn13={HttpUtility.UrlEncode(isbn13)}");
            }
        }

        private bool BookAlreadyExists(string isbn, string isbn13) => db.Books.Any(b => b.ISBN == isbn || b.ISBN13 == isbn13);

        // GET: Books/AddNewBook
        [HttpGet]
        public ActionResult AddNewBook(string isbn, string isbn13)
        {
            var model = new AddNewBookViewModel()
            {
                GenreList = new SelectList(db.Generes.Select(b => new { b.ID, b.Name }).ToList(), "ID", "Name"),
                ISBN = isbn,
                ISBN13 = isbn13
            };

            return View(model);
        }

        // POST: Books/AddNewBook
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewBook(AddNewBookViewModel book)
        {
            if (ModelState.IsValid)
            {
                //db.Books.Add(book);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

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
