using Microsoft.AspNetCore.Mvc;
using AspCoreFirstApp.Models;
using System.Collections.Generic;

namespace AspCoreFirstApp.Controllers
{
    public class MovieController : Controller
    {
        List<Movie> movies = new List<Movie>
            {
                new Movie { Id = 1, Name = "Movie 1" },
                new Movie { Id = 2, Name = "Movie 2" },
                new Movie { Id = 3, Name = "Movie 3" }
            };
        // Action par défaut pour lister les films
        public IActionResult Index()
        {
           

            return View(movies);
        }

        // Action pour éditer un film par son Id
        public IActionResult Edit(int id)
        {
            return Content("Test Id: " + id);
        }
        //[Route("Movie/released/{year}/{month}")]
        // Action pour récupérer les films par mois et année de sortie
        public IActionResult ByRelease(int year, int month)
        {
            return Content($"Release Date: {month}/{year}");
        }

        // Action pour afficher les détails d'un film avec une liste de clients
        public IActionResult Details()
        {
            var movie = new Movie { Id = 1, Name = "Inception" };
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Alice" },
                new Customer { Id = 2, Name = "Bob" }
            };

            var viewModel = new MovieCustomerViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        // Action pour afficher les détails d'un client par son Id
        public IActionResult CustomerDetails(int id)
        {
            var customer = new Customer { Id = id, Name = $"Customer {id}" };
            return Content($"Customer Details: {customer.Name}");
        }
        // Action pour éditer un film
        public IActionResult Edit2(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit2(Movie movie)
        {
            var existingMovie = movies.FirstOrDefault(m => m.Id == movie.Id);
            if (existingMovie == null)
                return NotFound();

            existingMovie.Name = movie.Name;
            return RedirectToAction("Index");
        }

        // Action pour supprimer un film
        public IActionResult Delete(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
                movies.Remove(movie);

            return RedirectToAction("Index");
        }
    }
}


