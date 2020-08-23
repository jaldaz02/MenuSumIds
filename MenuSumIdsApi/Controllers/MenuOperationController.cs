using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MenuSumIdsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuOperationController : Controller
    {
        public IMenuService menuService { get; set; }
        public MenuOperationController(IMenuService _menuService)
        {
            menuService = _menuService;
        }

        [HttpPost("ReadMenuFile")]
        public IActionResult ReadMenuFile(IFormFile inputFile)
        {
            var fileStr = new StringBuilder();
            using (var reader = new StreamReader(inputFile.OpenReadStream()))
            {
                fileStr.Append(reader.ReadToEnd().Trim());
            }

            var answer = menuService.GetMenuServiceModel(fileStr.ToString());
            string result = menuService.SumValidMenuIds(answer);

            return Ok (result);
        }
    }

}