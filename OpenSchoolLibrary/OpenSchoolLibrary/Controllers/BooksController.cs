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
using System.Threading.Tasks;

namespace OpenSchoolLibrary.Controllers 
{
    public class BooksController : Controller
    {        
        public enum BookConditions
        {
            Excellent,
            Good,
            Fair,
            Used,
            Bad
        }

        // GET: Books/Add
        [HttpGet, Route("books/add")]
        public ViewResult Add()
        {
            return View();
        }

        // GET: Books/AddNewBook
        [HttpGet]
        public ActionResult AddNewBook(string isbn, string isbn13)
        {
            var model = new AddNewBookViewModel()
            {
               // GenreList = new SelectList(db.Generes.Select(b => new { b.ID, b.Name }).ToList(), "ID", "Name"),
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
    }
}
