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
    public class ProducerController : Controller
    {
        private readonly IProducerService service;

        // Constructer
        public ProducerController(IProducerService Service)
        {
            service = Service;
        }

        public async Task<IActionResult> Index()
        {
            var allProducer = await service.GetAllAsync();
            return View(allProducer);
        }

        // get producer/details
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await service.GetIDAsync(id);
            if (producerDetails == null)
            {
                return View("DoesnotExist");
            }
            else
            {
                return View(producerDetails);
            }
        }

        // get producer/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("producerPictureURL, producerName, producerDescription")]Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            else
            {
                await service.addAsync(producer);
                return RedirectToAction(nameof(Index));
            }
        }

        // get producer/edit
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await service.GetIDAsync(id);

            if (producerDetails == null)
            {
                return View("DoesnotExist");
            }
            else
            {
                return View(producerDetails);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, producerPictureURL, producerName, producerDescription")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            else if (id == producer.Id)
            {
                await service.updateAsync(id, producer);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(producer);
            }
        }

        // Producer/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var warrantyDetails = await service.GetIDAsync(id);

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
            var producerExist = await service.GetIDAsync(id);
            if (producerExist == null)
            {
                return View("DoesnotExist");
            }
            else
            {
                await service.deleteAsync(id);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
