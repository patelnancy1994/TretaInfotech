﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulkLetters.Models
{
    public class Addressee
    {
        public string ContactPerson { get; set; }
        public string FirstName { get; set; }
        public string StreetAddress { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string CardNumber { get; set; }
        public string ExpireDate { get; set; }
    }
}