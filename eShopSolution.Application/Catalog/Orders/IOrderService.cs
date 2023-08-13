using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Orders
{
    public interface IOrderService
    {
        Task<int> Create(CheckOutRequest request, Guid? userId);

        Task<List<OrderInforVm>> GetAll(string languageId);

        Task<OrderInforVm> GetOrderById(int orderId, string languageId);

        Task<ApiResult<bool>> UpdateOrderStatus(int orderId);

        Task<ApiResult<bool>> CancelOrderStatus(int orderId);
    }
}
