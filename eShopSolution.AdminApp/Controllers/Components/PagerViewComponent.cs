using eShopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;

namespace eShopSolution.AdminApp.Controllers.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(PagedResultBase result)
        {
            return await Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}
