using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using caraspproject.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace caraspproject.Controllers
{
    public class ReturnController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly IClientRepository _clientRepository;

        public ReturnController(ICarRepository carRepository, IClientRepository customerRepository)
        {
            _carRepository = carRepository;
            _clientRepository = customerRepository;
        }

        [Route("Return")]
        public IActionResult List()
        {
            var rentedCars = _carRepository.FindWithBrandAndCustomer(x => x.CustomerId != 0);
            if (rentedCars == null || rentedCars.ToList().Count() == 0)
            {
                return View("Empty");
            }
            return View(rentedCars);
        }

        public IActionResult ReturnCar(int carId)
        {
            var car = _carRepository.GetById(carId);
            car.Customer = null;

            car.CustomerId = 0;
            _carRepository.Update(car);
            return RedirectToAction("List");
        }
    }
}