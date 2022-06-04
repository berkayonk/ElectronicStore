using ElectronicStore.Data;
using ElectronicStore.Data.Service;
using ElectronicStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicStore.Controllers
{
    public class WarrantyController : Controller
    {
        private readonly IWarrantyService warranty;

        // Constructer
        public WarrantyController(IWarrantyService Warranty)
        {
            warranty = Warranty;
        }

        public async Task<IActionResult> Index()
        {
            var allWarranties = await warranty.GetAllAsync();
            return View(allWarranties);
        }

        // Warranty/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("warrantyName, warrantyDescription, warrantyPictureURL")]Warranty myWarranty)
        {
            if (!ModelState.IsValid)
            {
                return View(myWarranty);
            }
            else
            {
                await warranty.addAsync(myWarranty);
                return RedirectToAction(nameof(Index));
            }
        }

        // Get Warranty/Details
        public async Task<IActionResult> Details(int id)
        {
            var warrantyDetails = await warranty.GetIDAsync(id);

            if(warrantyDetails == null)
            {
                return View("DoesnotExist");
            }
            else
            {
                return View(warrantyDetails);
            }
        }

        // Warranty/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var warrantyDetails = await warranty.GetIDAsync(id);

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
        public async Task<IActionResult> Edit(int id, [Bind("warrantyName, warrantyDescription, warrantyPictureURL")] Warranty myWarranty)
        {
            if (!ModelState.IsValid)
            {
                return View(myWarranty);
            }
            else
            {
                await warranty.updateAsync(id, myWarranty);
                return RedirectToAction(nameof(Index));
            }
        }

        // Warranty/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var warrantyDetails = await warranty.GetIDAsync(id);

            if (warrantyDetails == null)
            {
                return View("DoesnotExist");
            }
            else
            {
                return View(warrantyDetails);
            }
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> ConfirmedDelete(int id)
        {
            var warrantyExist = await warranty.GetIDAsync(id);
            if (warrantyExist == null)
            {
                return View("DoesnotExist");
            }
            else
            {
                await warranty.deleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
