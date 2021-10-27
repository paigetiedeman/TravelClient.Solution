using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravelClient.Models;

namespace TravelClient.Controllers
{
    public class ReviewsController : Controller
  {
    public IActionResult Index()
    {
      var allReviews = Review.GetReviews().OrderByDescending(model => model.Rating);
      return View(allReviews);
    }

    [HttpPost]
    public async Task<IActionResult> Index(Review review)
    {
      await Review.Post(review);
      return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
      var review = Review.GetDetails(id);
      return View(review);
    }

    public IActionResult Edit(int id)
    {
      var review = Review.GetDetails(id);
      return View(review);
    }

    [HttpPost]
    public async Task<IActionResult> Details(int id, Review review)
    {
      review.ReviewId = id;
      await Review.Put(review);
      return RedirectToAction("Details", id);
    }

    public async Task<IActionResult> Delete(int id)
    {
      await Review.Delete(id);
      return RedirectToAction("Index");
    }

    public ActionResult Search()
    {
      return View();
    }

    public IActionResult SearchResults(string name, string city, string country)
    {
      
      var searchResults = Review.Search(name, city, country);
      return View(searchResults);
    }
  }
}