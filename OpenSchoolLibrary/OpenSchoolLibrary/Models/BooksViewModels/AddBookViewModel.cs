using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenSchoolLibrary.Models.BooksViewModels
{
    public class AddBookViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Title is Required")]
        public string Title { get; set; }

        [Display(Name = "Subtitle")]
        public string SubTitle { get; set; }

        [Required(ErrorMessage = "Author is Required")]
        public string Author { get; set; }

        public int ISBN { get; set; }

        [Display(Name = "ISBN-13")]
        public int ISBN13 { get; set; }

        [Required(ErrorMessage = "Condition is Required")]
        public int Condition { get; set; }

        public string CatalogID { get; set; }

        [Required(ErrorMessage = "Genre is Required")]
        public int Genre { get; set; }

        public SelectList GenreList { get; set; }
    }
}