using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using caraspproject.Models;
using caraspproject.Data.Interfaces;
using caraspproject.ViewModel;

namespace caraspproject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IClientRepository _clientRepository;
        public HomeController(ICarRepository carRepository, IBrandRepository brandRepository, IClientRepository clientRepository)
        {
            _carRepository = carRepository;
            _brandRepository = brandRepository;
            _clientRepository = clientRepository;
        }
        public IActionResult Index()
        {
            var homeVM = new HomeViewModel()
            {
                CarCount = _carRepository.Count(x => true),
                BrandCount = _brandRepository.Count(x => true),
                ClientCount = _clientRepository.Count(x => true),
                RentCarCount = _carRepository.Count(x => x.Customer != null)
            };
            return View();
        }

       
    }
}
