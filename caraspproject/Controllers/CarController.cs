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
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly IBrandRepository _brandRepository;

        public CarController(ICarRepository carRepository, IBrandRepository brandRepository)
        {
            _carRepository = carRepository;
            _brandRepository = brandRepository;
        }
        [Route("Car")]
        public IActionResult List(int? BrandId, int? CustomerId)
        {
            if (BrandId == null && CustomerId == null) // pokazuje wszystkie auta
            {
                var cars = _carRepository.GetAllWithBrand();
                return CheckCars(cars);
            }
            else if (BrandId != null) // filtruje po marce
            {
                var brand = _brandRepository.GetWithCars((int)BrandId);
                if (brand.Cars.Count() == 0)
                {
                    return View("Marka nie posiada aut", brand);
                }
                else
                {
                    return View(brand.Cars);
                }
            }
            else if (CustomerId != null) // filtruje po kliencie
            {
                var cars = _carRepository.FindWithBrandAndCustomer(car => car.CustomerId == CustomerId);
                return CheckCars(cars);
            }
            else
            {
                throw new ArgumentException();
            }
        }
        public IActionResult CheckCars(IEnumerable<Car> cars)
        {
            if (cars.Count() == 0)
            {
                return View("Brak aut");
            }
            else
            {
                return View(cars);
            }
        }

        public IActionResult Create()
        {
            var carVM = new CarViewModel()
            {
                Brands = _brandRepository.GetAll()
            };
            return View(carVM);
        }

        [HttpPost]
        public IActionResult Create(CarViewModel carViewModel)
        {
            if (!ModelState.IsValid)
            {
                carViewModel.Brands = _brandRepository.GetAll();
                return View(carViewModel);
            }

            _carRepository.Create(carViewModel.Car);

            return RedirectToAction("List");
        }
        public IActionResult Update(int id)
        {
            var carVM = new CarViewModel()
            {
                Car = _carRepository.GetById(id),
                Brands = _brandRepository.GetAll()
            };
            return View(carVM);
        }

        [HttpPost]
        public IActionResult Update(CarViewModel carViewModel)
        {
            if (!ModelState.IsValid)
            {
                carViewModel.Brands = _brandRepository.GetAll();
                return View(carViewModel);
            }

            _carRepository.Create(carViewModel.Car);

            return RedirectToAction("List");
        }
        public IActionResult Delete(int id)
        {
            var car = _carRepository.GetById(id);
            _carRepository.Delete(car);
            return RedirectToAction("List");
        }
    }
}
