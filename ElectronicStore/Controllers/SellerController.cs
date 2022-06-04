using ElectronicStore.Data;
using ElectronicStore.Data.Service;
using ElectronicStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicStore.Controllers
{
    public class SellerController : Controller
    {
        private readonly ISellerService sellerService;

        // Constructer
        public SellerController(ISellerService service)
        {
            sellerService = service;
        }

        public async Task<IActionResult> Index()
        {
            var allSeller = await sellerService.GetAllAsync();
            return View(allSeller);
        }

        // Seller/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("sellerName, sellerDescription, sellerPictureURL")] Seller seller)
        {
            if (!ModelState.IsValid)
            {
                return View(seller);
            }
            else
            {
                await sellerService.addAsync(seller);
                return RedirectToAction(nameof(Index));
            }
        }

        // Get Seller/Details
        public async Task<IActionResult> Details(int id)
        {
            var warrantyDetails = await sellerService.GetIDAsync(id);

            if (warrantyDetails == null)
            {
                return View("DoesnotExist");
            }
            else
            {
                return View(warrantyDetails);
            }
        }

        // Seller/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var warrantyDetails = await sellerService.GetIDAsync(id);

            if (warrantyDetails == null)
            {
                return View("DoesnotExist");
            }
            else
            {
                return View(warrantyDetails);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("warrantyName, warrantyDescription, warrantyPictureURL")] Seller mySeller)
        {
            if (!ModelState.IsValid)
            {
                return View(mySeller);
            }
            else
            {
                await sellerService.updateAsync(id, mySeller);
                return RedirectToAction(nameof(Index));
            }
        }

        // Seller/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var sellerDetails = await sellerService.GetIDAsync(id);

            if (sellerDetails == null)
            {
                return View("DoesnotExist");
            }
            else
            {
                return View(sellerDetails);
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> ConfirmedDelete(int id)
        {
            var sellerExist = await sellerService.GetIDAsync(id);
            if (sellerExist == null)
            {
                return View("DoesnotExist");
            }
            else
            {
                await sellerService.deleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
