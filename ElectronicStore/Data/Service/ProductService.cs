using ElectronicStore.Data.Base;
using ElectronicStore.Data.ViewModels;
using ElectronicStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicStore.Data.Service
{
    public class ProductService : EntityBaseRepository<Product>, IProductService
    {
        private readonly DatabaseContext Context;
        public ProductService(DatabaseContext context) : base(context)
        {
            Context = context;
        }

        public async Task addNewProductAsync(ProductViewModel productViewModel)
        {
            var newProduct = new Product()
            {
                productName = productViewModel.productName,
                productDescription = productViewModel.productDescription,
                productPrice = productViewModel.productPrice,
                productPictureURL = productViewModel.productPictureURL,
                productCategory = productViewModel.productCategory,
                producyListDate = productViewModel.producyListDate,
                producerID = productViewModel.producerID,
                sellerID = productViewModel.sellerID,
            };
            await Context.products.AddAsync(newProduct);
            await Context.SaveChangesAsync();

            // Add Warranty
            foreach (var warrantyID in productViewModel.warrantyIDs)
            {
                var newWarrantyProduct = new WarrantytoProduct()
                {
                    productID = newProduct.Id,
                    Id = warrantyID
                };
                await Context.warrantytoProducts.AddAsync(newWarrantyProduct);
            }
            await Context.SaveChangesAsync();
        }

        public async Task<Product> GetByIDAsync(int id)
        {
            var products = await Context.products.Include(s => s.sellers).Include(p => p.producers).Include(wp => wp.warrantytoProducts).ThenInclude(w => w.warranty).FirstOrDefaultAsync(i => i.Id == id);
            return products;
        }

        public async Task<ProductDropDownViewModel> GetProductDropDownValue()
        {
            var result = new ProductDropDownViewModel();
            result.warranties = await Context.warranties.OrderBy(f => f.warrantyName).ToListAsync();
            result.sellers = await Context.sellers.OrderBy(f => f.sellerName).ToListAsync();
            result.producers = await Context.producers.OrderBy(f => f.producerName).ToListAsync();
            return result;
        }

        public async Task updateProductAsync(ProductViewModel productViewModel)
        {
            var getProduct = await Context.products.FirstOrDefaultAsync(i => i.Id == productViewModel.Id);

            if (getProduct != null)
            {
                getProduct.productName = productViewModel.productName;
                getProduct.productDescription = productViewModel.productDescription;
                getProduct.productPrice = productViewModel.productPrice;
                getProduct.productPictureURL = productViewModel.productPictureURL;
                getProduct.productCategory = productViewModel.productCategory;
                getProduct.producyListDate = productViewModel.producyListDate;
                getProduct.producerID = productViewModel.producerID;
                getProduct.sellerID = productViewModel.sellerID;
                
                await Context.SaveChangesAsync();
            }

            // Remove existing warranty
            var removeWarrantyDB = Context.warrantytoProducts.Where(w => w.productID == productViewModel.Id).ToList();
            Context.warrantytoProducts.RemoveRange(removeWarrantyDB);
            await Context.SaveChangesAsync();

            // Add Warranty
            foreach (var warrantyID in productViewModel.warrantyIDs)
            {
                var newWarrantyProduct = new WarrantytoProduct()
                {
                    productID = productViewModel.Id,
                    Id = warrantyID
                };
                await Context.warrantytoProducts.AddAsync(newWarrantyProduct);
            }
            await Context.SaveChangesAsync();
        }
    }
}
