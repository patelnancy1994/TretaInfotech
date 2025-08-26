using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulkLetters.Models
{
    public class LetterRequest
    {
            public List<Addressee> Addressees { get; set; }
    }
}