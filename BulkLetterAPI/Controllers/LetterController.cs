using BulkLetterAPI.Services;
using BulkLetters.Models;
using System.Linq;
using System.Text;
using System.Web.Http;

namespace BulkLetterAPI.Controllers
{
    [RoutePrefix("api/Letter")]
    public class LetterController : ApiController
    {
        private readonly TemplateService _templateService;

        public LetterController()
        {
            _templateService = new TemplateService();
        }

        [HttpPost]
        [Route("GenerateLetters")]
        public string GenerateLetters([FromBody]LetterRequest request)
        {
            if (request?.Addressees == null || !request.Addressees.Any())
            {
                return "";
            }
            var html = _templateService.GenerateLetters(request.Addressees);
            var bytes = Encoding.UTF8.GetBytes(html);
            return html;
        }
    }
}