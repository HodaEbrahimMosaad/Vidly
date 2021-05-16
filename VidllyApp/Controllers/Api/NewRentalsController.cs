using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidllyApp.Dtos;
using VidllyApp.Models;

namespace VidllyApp.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalModel newRental)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);
            if (customer == null)
                return BadRequest("Customer Id is not valid");

            var movies = _context.Movies.
                Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            if (newRental.MovieIds.Count != movies.Count)
                return BadRequest("Movie Id is not valid");

            try
            {
                string mess = "";
                foreach (var movie in movies)
                {
                    
                    if (movie.NumberAvailable == 0)
                        mess += $"Movie {movie.Name} not available - ";
                    else
                    {
                        mess += movie.Name + " - ";
                        movie.NumberAvailable--;
                        var rental = new Rental()
                        {
                            Customer = customer,
                            Movie = movie,
                            DateRented = DateTime.Now
                        };
                        _context.Rentals.Add(rental);


                        _context.SaveChanges();
                    }
                }
                return Ok(mess);
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            
        }
    }
}
