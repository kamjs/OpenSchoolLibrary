using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenSchoolLibrary.Domain
{
    public class Patron
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Grade { get; set; }
        public string HomeRoomTeacher { get; set; }
        public string LibraryCard { get; set; }
        public string OptionalSecret { get; set; }

    }
}