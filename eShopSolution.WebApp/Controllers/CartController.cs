using eShopSolution.ApiIntegration;
using eShopSolution.Utilities.Constants;
using eShopSolution.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eShopSolution.WebApp.Controllers
{
	public class CartController : Controller
	{
		private readonly IProductApiClient _productApiClient;
		public CartController(IProductApiClient productApiClient) 
		{
			_productApiClient = productApiClient;
		}
		public IActionResult Index()
		{
			return View();
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
