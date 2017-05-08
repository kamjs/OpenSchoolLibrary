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

    }
}
