using caraspproject.Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caraspproject.Data
{
    public class DbInitialize
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<LibraryDbContext>();
                // Dodawanie klientow
                var Dominik = new Client { Name = "Dominik Raczkowski" };
                var Bartosz = new Client { Name = "Bartosz Ruszel" };
                var Krystian = new Client { Name = "Krystian Kobus" };

                context.Clients.Add(Dominik);
                context.Clients.Add(Bartosz);
                context.Clients.Add(Krystian);

                // Dodawanie Marek
                var Ferrari = new Brand
                {
                    Name = "Ferrari Italiano",
                    Cars = new List<Car>()
                    {
                        new Car { CarName = "Ferrari California"},
                        new Car { CarName = "Ferrari 458 Italia"},
                        new Car { CarName = "Ferrari Mondial"}
                    }
                };
                var Ford = new Brand
                {
                    Name = "Ford Motor Company",
                    Cars = new List<Car>()
                    {
                        new Car { CarName = "Ford Focus"},
                        new Car { CarName = "Ford Mondeo"},
                        new Car { CarName = "Ford Fiesta"}
                    }
                };

                context.Brands.Add(Ferrari);
                context.Brands.Add(Ford);

                context.SaveChanges();
            }
        }
    }
}
