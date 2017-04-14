﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenSchoolLibrary.Models.BooksViewModels
{
    public class CreateBookViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Author { get; set; }
        public int ISBN { get; set; }
        public int ISBN13 { get; set; }
        public int Condition { get; set; }
        public string CatalogID { get; set; }
        public string Genre { get; set; }
    }
}