using OpenSchoolLibrary.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenSchoolLibrary.Models.BooksViewModels
{
    public class AddNewBookViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string ISBN13 { get; set; }
        public int Condition { get; set; }
        public string CatalogID { get; set; }
        public List<Genre> Genres { get; set; }
        public List<int> GenreIDs { get; set; }


    }
}