using eShopSolution.ViewModels.Catalog.Categories;
using eShopSolution.ViewModels.Common;
using System.Net.Http;
using System.Net.Http.Headers;

namespace eShopSolution.AdminApp.Services
{
    public class CategoryApiClient : BaseApiClient, ICategoryApiClient
    {
        public CategoryApiClient(
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor) 
            : base(httpClientFactory, httpContextAccessor, configuration)
        {}

        public async Task<List<CategoryVm>> GetAll(string languageId)
        {
            return await GetListAsync<CategoryVm>("/api/categories?languageId=" + languageId);
        }
    }
}
