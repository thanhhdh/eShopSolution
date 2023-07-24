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

app.MapControllerRoute(
	name: "default",
	pattern: "{culture=vi}/{controller=Home}/{action=Index}/{id?}");

app.Run();