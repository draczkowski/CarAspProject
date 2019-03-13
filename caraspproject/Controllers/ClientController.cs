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
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;
        private readonly ICarRepository _carRepository;

        public ClientController(IClientRepository clientRepository , ICarRepository carRepository)
        {
            _clientRepository = clientRepository;
            _carRepository = carRepository;
        }

        [Route("Client")]
        public IActionResult List()
        {
            var clientVM = new List<ClientViewModel>();

            var clients = _clientRepository.GetAll();

            if (clients.Count() == 0)
            {
                return View("Empty");
            }

            foreach ( var client in clients)
            {
                clientVM.Add(new ClientViewModel
                {
                    Client = client,
                    CarCount = _carRepository.Count(x => x.CustomerId == client.ClientId)
                });
            }
            return View(clientVM);


        }
        public IActionResult Delete(int id)
        {
            var client = _clientRepository.GetById(id);

            _clientRepository.Delete(client);

            return RedirectToAction("List");
        }
        public IActionResult Update(int id)
        {
            var client = _clientRepository.GetById(id);

            return View(client);
        }
        [HttpPost]
        public IActionResult Create()
        {
            if (!ModelState.IsValid)
            {
                return View(brand);
            }

            return View();
        }
        [HttpPost]
        public IActionResult Create(Client client)
        {
            if (!ModelState.IsValid)
            {
                return View(brand);
            }

            _clientRepository.Create(client);
            return RedirectToAction("List");
        }
    }
}
