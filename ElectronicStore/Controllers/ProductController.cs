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

        public async Task<IActionResult> Filter(string searchString)
        {
            var allProduct = await service.GetAllAsync(i => i.sellers);

            if (!string.IsNullOrEmpty(searchString))
            {
                var result = allProduct.Where(p => p.productName.Contains(searchString) || p.productDescription.Contains(searchString)).ToList();
                return View("Index", result);
            }
            else
            {
                return View("Index", allProduct);
            }        
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

        // Product/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var productDetails = await service.GetByIDAsync(id);
            if(productDetails == null)
            {
                return View("DoesnotExist");
            }
            else
            {
                var response = new ProductViewModel
                {
                    Id = productDetails.Id,
                    productName = productDetails.productName,
                    productDescription = productDetails.productDescription,
                    productPrice = productDetails.productPrice,
                    productPictureURL = productDetails.productPictureURL,
                    productCategory = productDetails.productCategory,
                    sellerID = productDetails.sellerID,
                    producerID = productDetails.producerID,
                    warrantyIDs = productDetails.warrantytoProducts.Select(w => w.Id).ToList()
                };

                var productDropDown = await service.GetProductDropDownValue();
                ViewBag.SellerID = new SelectList(productDropDown.sellers, "Id", "sellerName");
                ViewBag.ProducerID = new SelectList(productDropDown.producers, "Id", "producerName");
                ViewBag.WarrantyID = new SelectList(productDropDown.warranties, "Id", "warrantyName");

                return View(response);
            }         
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductViewModel productViewModel)
        {
            if(id != productViewModel.Id)
            {
                return View("DoesnotExist");
            }
            else
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
                    await service.updateProductAsync(productViewModel);
                    return RedirectToAction(nameof(Index));
                }
            }           
        }
    }
}
