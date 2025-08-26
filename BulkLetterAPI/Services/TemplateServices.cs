using BulkLetters.Models;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web;

namespace BulkLetterAPI.Services
{
    public class TemplateService
    {
        private readonly string _template;

        public TemplateService()
        {
            var path = HttpContext.Current.Server.MapPath("~/Templates/SixtyDaysLetterPrompt.html");
            _template = File.ReadAllText(path);
        }

        public string GenerateLetters(IEnumerable<Addressee> addressees)
        {
            var myCompanyPhone = ConfigurationManager.AppSettings["MyCompanyNumber"];
            var sb = new StringBuilder();
            foreach (var addr in addressees)
            {
                var letter = _template
                    .Replace("$ContactPerson", addr.ContactPerson)
                    .Replace("$FirstName", addr.FirstName)
                    .Replace("$StreetAddress", addr.StreetAddress)
                    .Replace("$Suburb", addr.Suburb)
                    .Replace("$State", addr.State)
                    .Replace("$PostCode", addr.PostCode)
                    .Replace("$CardNunber", addr.CardNumber)
                    .Replace("$ExpireDate", addr.ExpireDate)
                    .Replace("$MyCompanyPhoneNumber", myCompanyPhone); 

                sb.Append("<div style='page-break-after: always;'>");
                sb.Append(letter);
                sb.Append("</div>");
            }

            return sb.ToString();
        }
    }

}