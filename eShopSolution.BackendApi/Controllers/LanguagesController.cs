using eShopSolution.Application.Catalog.Products;
using eShopSolution.Application.System.Languages;
using eShopSolution.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguageService _languageService;

        public LanguagesController(ILanguageService LanguageService)
        {
            _languageService = LanguageService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var languages = await _languageService.GetAll();
            return Ok(languages);
        }
    }
}
