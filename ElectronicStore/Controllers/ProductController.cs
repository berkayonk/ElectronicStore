using ElectronicStore.Data;
using ElectronicStore.Data.Service;
using ElectronicStore.Data.ViewModels;
using ElectronicStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService service;

        // Constructer
        public ProductController(IProductService Service)
        {
            service = Service;
        }

        public async Task<IActionResult> Index()
        {
            var allProduct = await service.GetAllAsync(i => i.sellers);
            return View(allProduct);
        }

        // Get Product/Details
        public async Task<IActionResult> Details(int id)
        {
            var productDetails = await service.GetByIDAsync(id);
            return View(productDetails);
        }

        // Product/Create
        public async Task<IActionResult> Create()
        {
            var productDropDown = await service.GetProductDropDownValue();

            ViewBag.SellerID = new SelectList(productDropDown.sellers, "Id", "sellerName");
            ViewBag.ProducerID = new SelectList(productDropDown.producers, "Id", "producerName");
            ViewBag.WarrantyID = new SelectList(productDropDown.warranties, "Id", "warrantyName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                var productDropDown = await service.GetProductDropDownValue();
                ViewBag.SellerID = new SelectList(productDropDown.sellers, "Id", "sellerName");
                ViewBag.ProducerID = new SelectList(productDropDown.producers, "Id", "producerName");
                ViewBag.WarrantyID = new SelectList(productDropDown.warranties, "Id", "warrantyName");

                return View(productViewModel);
            }
            else
            {
                await service.addNewProductAsync(productViewModel);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
