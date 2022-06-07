using ElectronicStore.Data.Base;
using ElectronicStore.Data.ViewModels;
using ElectronicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicStore.Data.Service
{
    public interface IProductService:IEntityBaseRepository<Product>
    {
        Task<Product> GetByIDAsync(int id);
        Task<ProductDropDownViewModel> GetProductDropDownValue();
        Task addNewProductAsync(ProductViewModel productViewModel);
        Task updateProductAsync(ProductViewModel productViewModel);
    }
}
