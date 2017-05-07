using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenSchoolLibrary.Domain
{
    public class Book
    {
        public int ID { get; set; }
        public string ISBN { get; set; }
        public string ISBN13 { get; set; }
    }
}