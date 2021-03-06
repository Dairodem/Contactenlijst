﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contactenlijst.Models
{
    public class ContactDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string TelNr { get; set; }
        public string Address { get; set; }
        public string Annotation { get; set; }
    }
}
