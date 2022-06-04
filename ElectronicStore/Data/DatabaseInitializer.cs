using ElectronicStore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicStore.Data
{
    public class DatabaseInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            // Get or send data to database
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DatabaseContext>();

                // Create database if not exits
                context.Database.EnsureCreated();

                //Seller
                if (!context.sellers.Any())
                {
                    context.sellers.AddRange(new List<Seller>()
                    {
                        new Seller()
                        {
                            sellerName = "Ahmet Elektroniks",
                            sellerPictureURL = "https://image.shutterstock.com/shutterstock/photos/1693673260/display_1500/stock-photo-grocery-store-in-guatemala-with-successful-man-celebrating-standing-in-a-boxing-position-1693673260.jpg",
                            sellerDescription = "Electronics from Ahmet."
                        },
                        new Seller()
                        {
                            sellerName = "Gul Computers",
                            sellerPictureURL = "https://image.shutterstock.com/image-photo/portrait-confident-female-butcher-standing-600w-165698459.jpg",
                            sellerDescription = "Buy from Gul Computers."
                        },
                        new Seller()
                        {
                            sellerName = "Mehmet Tablets",
                            sellerPictureURL = "https://image.shutterstock.com/image-photo/young-woman-choosing-tablet-pc-600w-194984288.jpg",
                            sellerDescription = "Best tablets in the world."
                        },
                        new Seller()
                        {
                            sellerName = "Melisa PC",
                            sellerPictureURL = "https://image.shutterstock.com/image-photo/mature-female-fashion-seller-using-600w-1836809776.jpg",
                            sellerDescription = "Best and great PCs from Melisa."
                        },
                        new Seller()
                        {
                            sellerName = "Nazım Parts",
                            sellerPictureURL = "https://image.shutterstock.com/image-photo/salesman-tablet-pc-shop-600w-1377640832.jpg",
                            sellerDescription = "Nazım trustworthy."
                        },
                    });
                    context.SaveChanges();
                }                
                //Producer
                if (!context.producers.Any())
                {
                    context.producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            producerName = "Nvidia",
                            producerPictureURL = "https://upload.wikimedia.org/wikipedia/en/thumb/a/a4/NVIDIA_logo.svg/1920px-NVIDIA_logo.svg.png",
                            producerDescription = "Nvidia is a global leader in artificial intelligence hardware & software from edge to cloud computing and expanded its presence in the gaming industry."
                        },
                        new Producer()
                        {
                            producerName = "Amd",
                            producerPictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7c/AMD_Logo.svg/2560px-AMD_Logo.svg.png",
                            producerDescription = "Advanced Micro Devices, Inc. (AMD) is an American multinational semiconductor company based in Santa Clara, California."
                        },
                        new Producer()
                        {
                            producerName = "Razer",
                            producerPictureURL = "https://upload.wikimedia.org/wikipedia/en/thumb/4/40/Razer_snake_logo.svg/150px-Razer_snake_logo.svg.png",
                            producerDescription = "Razer Inc. is an American-Singaporean multinational technology company that designs, develops, and sells consumer electronics, financial services, and gaming hardware."
                        },
                        new Producer()
                        {
                            producerName = "Logitech",
                            producerPictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/17/Logitech_logo.svg/1920px-Logitech_logo.svg.png",
                            producerDescription = "Logitech International is a Swiss multinational manufacturer of computer peripherals and software, with headquarters in Lausanne, Switzerland and Newark, California."
                        },
                        new Producer()
                        {
                            producerName = "Corsair",
                            producerPictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/80/Corsair2020logo.svg/1920px-Corsair2020logo.svg.png",
                            producerDescription = "Corsair Gaming, Inc. is an American computer peripherals and hardware company headquartered in Fremont, California."
                        },
                    });
                    context.SaveChanges();
                }
                //Warranty
                if (!context.warranties.Any())
                {
                    context.warranties.AddRange(new List<Warranty>()
                    {
                        new Warranty()
                        {
                            warrantyName = "No Warranty.",
                            warrantyPictureURL = "https://image.shutterstock.com/image-vector/warranty-ribbon-round-red-sign-260nw-1509535715.jpg",
                            warrantyDescription = "No warranty."
                        },
                        new Warranty()
                        {
                            warrantyName = "Express Warranty",
                            warrantyPictureURL = "https://image.shutterstock.com/image-vector/warranty-ribbon-round-red-sign-260nw-1509535715.jpg",
                            warrantyDescription = "An express warranty is one that is clearly stated either verbally or in writing."
                        },
                        new Warranty()
                        {
                            warrantyName = "Implied Warranty",
                            warrantyPictureURL = "https://image.shutterstock.com/image-vector/warranty-ribbon-round-red-sign-260nw-1509535715.jpg",
                            warrantyDescription = "An implied warranty automatically covers most consumer goods valued over a certain amount."
                        },
                        new Warranty()
                        {
                            warrantyName = "Warranty for 2 years.",
                            warrantyPictureURL = "https://image.shutterstock.com/image-vector/warranty-ribbon-round-red-sign-260nw-1509535715.jpg",
                            warrantyDescription = "A warranty is a term of a contract for 2 years."
                        },
                        new Warranty()
                        {
                            warrantyName = "1-year Warranty",
                            warrantyPictureURL = "https://image.shutterstock.com/image-vector/warranty-ribbon-round-red-sign-260nw-1509535715.jpg",
                            warrantyDescription = "A warranty is a term of a contract for 1 year."
                        },
                    });
                    context.SaveChanges();
                }
                //Product
                if (!context.products.Any())
                {
                    context.products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            productName = "Nvidia Geforce Rtx 3090Ti",
                            productPictureURL = "https://cdn.dsmcdn.com/ty430/product/media/images/20220512/14/109811759/477647955/1/1_org_zoom.jpg",
                            productDescription = "Nvidia's strongest GPU.",
                            productPrice = 50348,
                            producyListDate = DateTime.Now,
                            productCategory = ProductCategory.GPU,
                            sellerID = 1,
                            producerID = 1
                        },
                        new Product()
                        {
                            productName = "DeathAdder Essential",
                            productPictureURL = "https://cdn.dsmcdn.com/ty93/product/media/images/20210403/21/6116589a/15373511/1/1_org_zoom.jpg",
                            productDescription = "Razer gaming mouse.",
                            productPrice = 235,
                            producyListDate = DateTime.Now,
                            productCategory = ProductCategory.Mouse,
                            sellerID = 2,
                            producerID = 3
                        },
                        new Product()
                        {
                            productName = "K380 Kompakt Kablosuz Bluetooth Turkish Q Keyboard",
                            productPictureURL = "https://cdn.dsmcdn.com/ty371/product/media/images/20220324/14/75480391/13436704/1/1_org_zoom.jpg",
                            productDescription = "Logitech's best keyboard.",
                            productPrice = 490,
                            producyListDate = DateTime.Now,
                            productCategory = ProductCategory.Keyboard,
                            sellerID = 3,
                            producerID = 4
                        },
                        new Product()
                        {
                            productName = "Void Rgb Elite 7.1 White Wireless Gaming Headset",
                            productPictureURL = "https://cdn.dsmcdn.com/ty101/product/media/images/20210407/02/29cfa7fd/61510939/5/5_org_zoom.jpg",
                            productDescription = "Corsair's best Headset.",
                            productPrice = 2263,
                            producyListDate = DateTime.Now,
                            productCategory = ProductCategory.Headset,
                            sellerID = 4,
                            producerID = 5
                        },
                        new Product()
                        {
                            productName = "Ryzen 5 5600 4.4ghz 35mb 65w Am4 Işlemci",
                            productPictureURL = "https://cdn.dsmcdn.com/ty388/product/media/images/20220408/17/86511800/441267070/1/1_org_zoom.jpg",
                            productDescription = "AMD's CPU",
                            productPrice = 3844,
                            producyListDate = DateTime.Now,
                            productCategory = ProductCategory.CPU,
                            sellerID = 5,
                            producerID = 2
                        },
                    });
                    context.SaveChanges();
                }
                //WarrantytoProduct
                if (!context.warrantytoProducts.Any())
                {
                    context.warrantytoProducts.AddRange(new List<WarrantytoProduct>()
                    {
                        // RTX3090Ti
                        new WarrantytoProduct()
                        {
                            Id = 3,
                            productID = 1
                        },
                        new WarrantytoProduct()
                        {
                            Id = 5,
                            productID = 1
                        },

                        // Razer gaming mouse
                        new WarrantytoProduct()
                        {
                            Id = 2,
                            productID = 2
                        },
                        new WarrantytoProduct()
                        {
                            Id = 4,
                            productID = 2
                        },

                        // Logitech's best keyboard
                        new WarrantytoProduct()
                        {
                            Id = 1,
                            productID = 3
                        },

                        // Corsair's best Headset
                        new WarrantytoProduct()
                        {
                            Id = 3,
                            productID = 4
                        },
                        new WarrantytoProduct()
                        {
                            Id = 4,
                            productID = 4
                        },

                        // Ryzen 5 5600
                        new WarrantytoProduct()
                        {
                            Id = 3,
                            productID = 5
                        },
                        new WarrantytoProduct()
                        {
                            Id = 5,
                            productID = 5
                        },
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
