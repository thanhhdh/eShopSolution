using eShopSolution.ViewModels.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.ViewModels.Catalog.Products
{
    public class ProductVm
    {
        public int Id { set; get; }
        public decimal Price { set; get; }
        public decimal OriginalPrice { set; get; }
        public int Stock { set; get; }
        public int ViewCount { set; get; }
        public DateTime DateCreated { set; get; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Details { get; set; }
        public string? SeoDescription { get; set; }
        public string? SeoTitle { get; set; }
        public string? SeoAlias { get; set; }
        public string? LanguageId { get; set; }
		public bool? IsFeatured { get; set; }
        public string? ThumbnailImage { get; set; }
        public List<string> Categories { get; set; } = new List<string>();
    }
}
