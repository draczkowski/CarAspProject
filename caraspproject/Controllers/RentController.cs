using caraspproject.Data.Interfaces;
using caraspproject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caraspproject.Controllers
{
    public class RentController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly IClientRepository _clientRepository;

        public RentController(ICarRepository carRepository, IClientRepository clientRepository)
        {
            _carRepository = carRepository;
            _clientRepository = clientRepository;
        }

        [Route("Rent")]
        public IActionResult List()
        {
            // wszystkie dostępne auta
            var availableCars = _carRepository.FindWithBrand(x => x.CustomerId == 0);
            if (availableCars.Count() == 0)
            {
                return View("Empty");
            }
            else
            {
                return View(availableCars);
            }
        }
        public IActionResult RentCar(int carId)
        {
            var rentMV = new RentViewModel()
            {
                Car = _carRepository.GetById(carId),
                Clients = _clientRepository.GetAll()
            };
            return View(rentMV);
        }

        [HttpPost]
        public IActionResult RentCar(RentViewModel rentViewModel)
        {
            var car = _carRepository.GetById(rentViewModel.Car.CarId);
            var client = _clientRepository.GetById(rentViewModel.Car.CustomerId);

            car.Customer = client;
            _carRepository.Update(car);
            return RedirectToAction("List");
        }
    }
}
