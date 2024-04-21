using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Controllers
{
    public class MovieController : Controller
    {       
      
        private readonly IMovieRepository movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
        var movies = await movieRepository.GetAll();
        return View(movies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Movie m)
        {
            if (ModelState.IsValid)
            {
                await movieRepository.Add(m);
              
                TempData["ResultOk"] = "Record Added Successfully !";
                return RedirectToAction("Index");
            }

            return View(m);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var fromdb = await movieRepository.Get((int)id);

            if (fromdb == null)
            {
                return NotFound();
            }
            return View(fromdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Movie m)
        {
            if (ModelState.IsValid)
            {
                await movieRepository.Update(m);
              
                TempData["ResultOk"] = "Data Updated Successfully !";
                return RedirectToAction("Index");
            }

            return View(m);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var fromdb = await movieRepository.Get((int)id);

            if (fromdb == null)
            {
                return NotFound();
            }
            return View(fromdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteM(int? id)
        {
            var deleterecord =await movieRepository.Delete((int)id);
            if (deleterecord == null)
            {
                return NotFound();
            }
            
            TempData["ResultOk"] = "Data Deleted Successfully !";
            return RedirectToAction("Index");
        }


    }

}
