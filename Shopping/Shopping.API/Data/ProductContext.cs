using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Shopping.API.Models;
using System.Collections.Generic;

namespace Shopping.API.Data
{
    public /*static*/ class ProductContext
    {
        public ProductContext(IConfiguration _configuration)
        {
            var client = new MongoClient(_configuration["DatabaseSettings:ConnectionString"]);
            var databse = client.GetDatabase(_configuration["DatabaseSettings:DatabaseName"]);

            Products = databse.GetCollection<ProductModel>(_configuration["DatabaseSettings:CollectionName"]);
            SeedData(Products);
        }

        public IMongoCollection<ProductModel> Products { get; }


        public static void SeedData(IMongoCollection<ProductModel> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<ProductModel> GetPreconfiguredProducts()
        {
            return new List<ProductModel>()
            {
                new ProductModel()
                {
                    Name = "IPhone X",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-1.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                },
                new ProductModel()
                {
                    Name = "Samsung 10",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-2.png",
                    Price = 840.00M,
                    Category = "Smart Phone"
                },
                new ProductModel()
                {
                    Name = "Huawei Plus",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-3.png",
                    Price = 650.00M,
                    Category = "White Appliances"
                },
                new ProductModel()
                {
                    Name = "Xiaomi Mi 9",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-4.png",
                    Price = 470.00M,
                    Category = "White Appliances"
                },
                new ProductModel()
                {
                    Name = "HTC U11+ Plus",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-5.png",
                    Price = 380.00M,
                    Category = "Smart Phone"
                },
                new ProductModel()
                {
                    Name = "LG G7 ThinQ EndofCourse",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageFile = "product-6.png",
                    Price = 240.00M,
                    Category = "Home Kitchen"
                }
            };
        }

        //public static readonly List<ProductModel> Products = new List<ProductModel>
        //{
        //    new ProductModel()
        //        {
        //            Name = "IPhone X",
        //            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
        //            ImageFile = "product-1.png",
        //            Price = 950.00M,
        //            Category = "Smart Phone"
        //        },
        //        new ProductModel()
        //        {
        //            Name = "Samsung 10",
        //            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
        //            ImageFile = "product-2.png",
        //            Price = 840.00M,
        //            Category = "Smart Phone"
        //        },
        //        new ProductModel()
        //        {
        //            Name = "Huawei Plus",
        //            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
        //            ImageFile = "product-3.png",
        //            Price = 650.00M,
        //            Category = "White Appliances"
        //        },
        //        new ProductModel()
        //        {
        //            Name = "Xiaomi Mi 9",
        //            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
        //            ImageFile = "product-4.png",
        //            Price = 470.00M,
        //            Category = "White Appliances"
        //        },
        //        new ProductModel()
        //        {
        //            Name = "HTC U11+ Plus",
        //            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
        //            ImageFile = "product-5.png",
        //            Price = 380.00M,
        //            Category = "Smart Phone"
        //        },
        //        new ProductModel()
        //        {
        //            Name = "LG G7 ThinQ EndofCourse",
        //            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
        //            ImageFile = "product-6.png",
        //            Price = 240.00M,
        //            Category = "Home Kitchen"
        //        }
        //};
    }
}
