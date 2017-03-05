using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyChoose.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GiftContext(
                serviceProvider.GetRequiredService<DbContextOptions<GiftContext>>()))
            {
                if (!context.Prices.Any())
                {
                    context.Prices.Add(
                        new Price { Value = 1000 }
                    );
                    context.SaveChanges();
                }

                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(
                        new Category { CategoryName = "Man" },
                        new Category { CategoryName= "Woman" }
                    );
                    context.SaveChanges();
                }

                if (!context.Gifts.Any())
                {
                    context.Gifts.AddRange(
                        new Gift
                        {
                            GiftName = @"Чай\кофе",
                            CreateDate = DateTime.Now,
                            UpdateDate = DateTime.Now,
                            PriceFrom = context.Prices.First(),
                            PriceTo = context.Prices.First()
                        },

                        new Gift
                        {
                            GiftName = "Подставки под ложку",
                            CreateDate = DateTime.Now,
                            UpdateDate = DateTime.Now,
                            PriceFrom = context.Prices.First(),
                            PriceTo = context.Prices.First()
                        },

                        new Gift
                        {
                            GiftName = "Набор инструментов",
                            CreateDate = DateTime.Now,
                            UpdateDate = DateTime.Now,
                            PriceFrom = context.Prices.First(),
                            PriceTo = context.Prices.First()
                        }
                    );
                    context.SaveChanges();
                }
                if (!context.CategoryDetails.Any())
                {
                    context.CategoryDetails.AddRange(
                        new CategoryDetail
                        {
                            Category = context.Categories.First(c => c.CategoryName == "Man"),
                            Gift = context.Gifts.First(g => g.GiftName == @"Чай\кофе")
                        },
                        new CategoryDetail
                        {
                            Category = context.Categories.First(c => c.CategoryName == "Woman"),
                            Gift = context.Gifts.First(g => g.GiftName == @"Чай\кофе")
                        },
                        new CategoryDetail
                        {
                            Category = context.Categories.First(c => c.CategoryName == "Woman"),
                            Gift = context.Gifts.First(g => g.GiftName == "Подставки под ложку")
                        },
                        new CategoryDetail
                        {
                            Category = context.Categories.First(c => c.CategoryName == "Man"),
                            Gift = context.Gifts.First(g => g.GiftName == "Набор инструментов")
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
