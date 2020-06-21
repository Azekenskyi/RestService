using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestService.Models
{
    public class Person
    {
        public int Id { get; set; }
        public long Iin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Otchestvo { get; set; }
        public DateTime dateBirthday { get; set; }
    }
}