using eShopSolution.ApiIntegration;
using eShopSolution.Utilities.Constants;
using eShopSolution.ViewModels.Sales;
using eShopSolution.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eShopSolution.WebApp.Controllers
{
	public class CartController : Controller
	{
        private readonly IProductApiClient _productApiClient;
        private readonly IUserApiClient _userApiClient;
        private readonly IOrderApiClient _orderApiClient;

        public CartController(IProductApiClient productApiClient, IUserApiClient userApiClient, IOrderApiClient orderApiClient)
        {
            _productApiClient = productApiClient;
            _userApiClient = userApiClient;
            _orderApiClient = orderApiClient;
        }
        public IActionResult Index()
		{
			return View();
		}

        public IActionResult Checkout()
        {
            return View(GetCheckoutViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(CheckOutViewModel request)
        {
            var model = GetCheckoutViewModel();
            var orderDetails = new List<OrderDetailVm>();
            foreach (var item in model.CartItems)
            {
                orderDetails.Add(new OrderDetailVm()
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                });
            }
            var checkoutRequest = new CheckOutRequest()
            {
                Address = request.CheckOutRequest.Address,
                Name = request.CheckOutRequest.Name,
                Email = request.CheckOutRequest.Email,
                PhoneNumber = request.CheckOutRequest.PhoneNumber,
                OrderDetails = orderDetails
            };
            //TODO: Add to API
            var result = await _orderApiClient.Create(checkoutRequest, null);
            if (result == false)
                TempData["SuccessMsg"] = "Đặt hàng thất bại";
            else
                TempData["SuccessMsg"] = "Đặt hàng thành công";
            return View(model);
        }


        private CheckOutViewModel GetCheckoutViewModel()
        {
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            if (session != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);
            var checkoutVm = new CheckOutViewModel()
            {
                CartItems = currentCart,
                CheckOutRequest = new CheckOutRequest()
            };
            return checkoutVm;
        }

        [HttpGet]
		public IActionResult GetListItem()
		{
			var session = HttpContext.Session.GetString(SystemConstants.CartSession);
			List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
			if (session != null)
			{
				currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);
			}
			return Ok(currentCart);
		}
		public async Task<IActionResult> AddToCart(int id, string languageId)
		{
			var product = await _productApiClient.GetById(id, languageId);
			var session = HttpContext.Session.GetString(SystemConstants.CartSession);
			List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
			if (session != null)
			{
				currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);
			}
            var quantity = 1;

            if (currentCart.Any(x => x.ProductId == id))
            {
                var cartItem = currentCart.First(x => x.ProductId == id);
                cartItem.Quantity += 1;
            }
            else
            {
                var cartItem = new CartItemViewModel()
                {
                    ProductId = id,
                    Description = product.Description,
                    Name = product.Name,
                    Image = product.ThumbnailImage,
                    Quantity = quantity,
                    Price = product.Price
                };
                currentCart.Add(cartItem);
            }

            HttpContext.Session.SetString(SystemConstants.CartSession, JsonConvert.SerializeObject(currentCart));
			return Ok(currentCart);
		}

		public  IActionResult UpdateToCart(int id, int quantity)
		{
			var session = HttpContext.Session.GetString(SystemConstants.CartSession);
			List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
			if (session != null)
			{
				currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);
			}
			foreach(var item in currentCart)
			{
				if(item.ProductId == id)
				{
					if(quantity == 0) {
						currentCart.Remove(item);
						break;
					}
					item.Quantity = quantity;
				}

			}
			HttpContext.Session.SetString(SystemConstants.CartSession, JsonConvert.SerializeObject(currentCart));
			return Ok(currentCart);
		}
	}
}
