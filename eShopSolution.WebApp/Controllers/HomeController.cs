﻿using eShopSolution.ApiIntegration;
using eShopSolution.Utilities.Constants;
using eShopSolution.WebApp.Models;
using LazZiya.ExpressLocalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace eShopSolution.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISlideApiClient _slideApiClient;
        private readonly IProductApiClient _productApiClient;

        public HomeController(
            ILogger<HomeController> logger, 
            ISlideApiClient slideApiClient,
            IProductApiClient productApiClient
            )
        {
            _logger = logger;
            _slideApiClient = slideApiClient;
            _productApiClient = productApiClient;
        }

        public async Task<IActionResult> Index()
        {
			var culture = CultureInfo.CurrentCulture.Name;

			var slides = await _slideApiClient.GetAll();
            var featuredProducts = await _productApiClient.GetFeaturedProducts(culture, SystemConstants.ProductSettings.NumberOfFeaturedProducts);
            var latestProducts = await _productApiClient.GetLatestProducts(culture, SystemConstants.ProductSettings.NumberOfLatestProducts);
            var viewModel = new HomeViewModel
            {
                Slides = slides,
                FeaturedProducts = featuredProducts,
                LatestProducts = latestProducts
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    //    public IActionResult SetCultureCookie(string cltr, string returnUrl)
    //    {
    //        Response.Cookies.Append(
    //            CookieRequestCultureProvider.DefaultCookieName,
				//CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cltr)),
    //            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
				//);
    //        return LocalRedirect(returnUrl);
    //    }
    }
}