using caraspproject.Data.Interfaces;
using caraspproject.Data.Model;
using caraspproject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caraspproject.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandRepository _brandRepository;

        public BrandController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;

        }
        [Route("Brand")]
        public IActionResult List()
        {
            var brands = _brandRepository.GetAllWithCars();

            if (brands.Count() == 0) return View("Empty");

            return View(brands);
        }

        public IActionResult Update (int id)
        {
            var brand = _brandRepository.GetById(id);

            if (brand == null) return NotFound();

            return View(brand);
        }
        [HttpPost]
        public IActionResult Update(Brand brand)
        {
            if(!ModelState.IsValid)
            {
                return View(brand);
            }

            _brandRepository.Update(brand);

            return RedirectToAction("List");
        }
        public IActionResult Create()
        {
            var viewModel = new CreateBrandViewModel
            { Referer = Request.Headers["Referer"].ToString() };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create(CreateBrandViewModel brandVM)
        {
            if (!ModelState.IsValid)
            {
                return View(brandVM);
            }

            _brandRepository.Create(brandVM.Brand);

            if (!String.IsNullOrEmpty(brand.VM.Referer))
            {
                return Redirect(brandVM.Referer);
            }

            return RedirectToAction("List");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var brand = _brandRepository.GetById(id);

            _brandRepository.Delete(brand);

            return View(brand);
        }


    }
}
