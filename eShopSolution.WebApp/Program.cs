using eShopSolution.ApiIntegration;
using eShopSolution.WebApp.LocalizationResources;
using LazZiya.ExpressLocalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

var cultures = new[]
{
	new CultureInfo("vi"),
	new CultureInfo("en"),
};
builder.Services.AddHttpClient();

// Add services to the container.
builder.Services.AddControllersWithViews()
	.AddExpressLocalization<ExpressLocalizationResource, ViewLocalizationResource>(
	ops =>
	{
		ops.ResourcesPath = "LocalizationResources";
		ops.RequestLocalizationOptions = o =>
		{
			o.SupportedCultures = cultures;
			o.SupportedUICultures = cultures;
			o.DefaultRequestCulture = new RequestCulture("vi");
		};
	});
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromSeconds(300);
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<ISlideApiClient, SlideApiClient>();
builder.Services.AddTransient<IProductApiClient, ProductApiClient>();
builder.Services.AddTransient<ICategoryApiClient, CategoryApiClient>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseRequestLocalization();
app.UseSession();

app.MapControllerRoute(
	name: "Product Category En",
	pattern: "{culture}/categories/{id}", new
	{
		controller = "Product", 
		action = "Category"
	});
app.MapControllerRoute(
	name: "Product Category Vi",
	pattern: "{culture}/danh-muc/{id}", new
	{
		controller = "Product",
		action = "Category"
	});
app.MapControllerRoute(
	name: "Product Detail En",
	pattern: "{culture}/products/{id}", new
	{
		controller = "Product",
		action = "Detail"
	});
app.MapControllerRoute(
	name: "Product Detail Vi",
	pattern: "{culture}/san-pham/{id}", new
	{
		controller = "Product",
		action = "Detail"
	});
app.MapControllerRoute(
	name: "default",
	pattern: "{culture=vi}/{controller=Home}/{action=Index}/{id?}");

app.Run();