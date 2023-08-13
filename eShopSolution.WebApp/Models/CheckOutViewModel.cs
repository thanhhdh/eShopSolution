using eShopSolution.ViewModels.Sales;

namespace eShopSolution.WebApp.Models
{
	public class CheckOutViewModel
	{
        public List<CartItemViewModel> CartItems { get; set; }
		public CheckOutRequest CheckOutRequest { get; set; }
	}
}
