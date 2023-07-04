using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.System.Users;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using eShopSolution.ViewModels.Catalog.Products;

namespace eShopSolution.AdminApp.Services
{
    public class ProductApiClient : BaseApiClient, IProductApiClient
    {
        
        public ProductApiClient(
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor
            ) : base(httpClientFactory, configuration, httpContextAccessor) { }

        public async Task<PagedResult<ProductVm>> GetPagings(GetManageProductPagingRequest request)
        {
            var data = await GetAsync<PagedResult<ProductVm>>($"/api/products/paging?pageIndex={request.PageIndex}&pageSize={request.PageSize}&keyword={request.Keyword}&languageId={request.LanguageId}");
            return data!;
        }

        
    }
}
