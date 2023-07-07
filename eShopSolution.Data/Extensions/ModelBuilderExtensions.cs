using eShopSolution.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //Data seeding 
            modelBuilder.Entity<AppConfig>().HasData(
                new AppConfig { Key = "HomeTitle", Value = "This is home page of eShopSolution" },
                new AppConfig { Key = "HomeKeyword", Value = "This is keyword of eShopSolution" },
                new AppConfig { Key = "HomeDescription", Value = "This is description of eShopSolution" }
                );

            modelBuilder.Entity<Language>().HasData(
                new Language { Id = "vi", Name = "Tiếng Việt", IsDefault = true},
                new Language { Id = "en", Name = "English", IsDefault = false}
                );

            modelBuilder.Entity<Category>().HasData(
                new Category { 
                    Id = 1,
                    IsShowOnHome = true, 
                    ParentId = null, 
                    SortOrder = 1, 
                    Status = Enums.Status.Active,
                },
                new Category
                {
                    Id = 2,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 2,
                    Status = Enums.Status.Active,
                });

            modelBuilder.Entity<CategoryTranslation>().HasData(
                     new CategoryTranslation()
                     {  
                        Id = 1, CategoryId = 1,Name = "Áo nam",LanguageId = "vi",SeoAlias = "ao-nam",SeoDescription = "Sản phẩm thời trang nam", SeoTitle = "Sản phẩm thời trang nam"
                     },
                     new CategoryTranslation()
                     {
                         Id = 2,CategoryId = 1,Name = "Men Shirt", LanguageId = "en",SeoAlias = "men-shirt",SeoDescription = "The Shirt product for men",SeoTitle = "The Shirt product for men"
                     },
                     new CategoryTranslation()
                     {
                         Id = 3, CategoryId = 2, Name = "Áo nữ", LanguageId = "vi",SeoAlias = "ao-nu",SeoDescription = "Sản phẩm thời trang nu",SeoTitle = "Sản phẩm thời trang nu"
                     },
                     new CategoryTranslation()
                     {
                         Id = 4, CategoryId = 2,Name = "Women Shirt",LanguageId = "en",SeoAlias = "women-shirt",SeoDescription = "The Shirt product for women", SeoTitle = "The Shirt product for women"
                     }
                );
            modelBuilder.Entity<Product>().HasData(
               new Product
               {
                   Id = 1,
                   DateCreated = DateTime.Now,
                   OriginalPrice = 100000,
                   Price = 200000,
                   Stock = 0,
                   ViewCount = 0,
                  
               });
            modelBuilder.Entity<ProductTranslation>().HasData(
                new ProductTranslation()
                {
                    Id = 1, ProductId = 1 ,Name = "Áo nam",LanguageId = "vi",SeoAlias = "ao-nam",SeoDescription = "Sản phẩm thời trang nam",SeoTitle = "Sản phẩm thời trang nam", Details = "Mô tả sản phẩm",Description = ""
                },
                new ProductTranslation()
                {
                    Id = 2, ProductId = 1, Name = "Men Shirt",LanguageId = "en",SeoAlias = "men-shirt", SeoDescription = "The Shirt product for men", SeoTitle = "The Shirt product for men",Details = "Description for product",Description = ""
                });
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { ProductId = 1, CategoryId = 1 }
                );

            var ADMIN_ID = new Guid("F84C11E3-1C71-4E40-B87A-1A58D1B9EB75");
            var ROLE_ID = new Guid("8748B902-AD9D-4F5C-9F9F-39A05E967BE5");
            // any guid, but nothing is against to use the same one
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = ROLE_ID,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = ADMIN_ID,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "hdhthanh.20it3@vku.udn.vn",
                NormalizedEmail = "hdhthanh.20it3@vku.udn.vn",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null!, "123456"),
                SecurityStamp = string.Empty,
                FirstName = "Ho",
                LastName = "Thanh",
                Dob = new DateTime(2023,06,14)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
        }

    }
}
