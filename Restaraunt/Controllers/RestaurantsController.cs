using Microsoft.AspNetCore.Mvc;
using Food.Models;
using System.Collections.Generic;
using System.Linq;

namespace Food.Controllers
{
  public class RestaurantsController : Controller
  {
    private readonly FoodContext _db;

    public RestaurantsController(FoodContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Restaurant> model = _db.Restaurants.ToList();
      return View(model);
    }
    public ActionResult Create()
{
    ViewBag.CuisineId = new SelectList(db.Cuisines, "CuisineId", "Name");
    return View();
}

    [HttpPost]
    public ActionResult Create(Restaurant restaurant)
    {
      _db.Restaurants.Add(restaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
    Restaurant thisRestaurant = _db.Restaurant.FirstOrDefault(restaurant => restaurants.RestaurantId == id);
    return View(thisRestaurant);
    }
    public ActionResult Edit(int id)
    {
    var thisRestaurant = db.Restaurants.FirstOrDefault(restaurant => restaurants.RestaurantId == id);
    ViewBag.CuisineId = new SelectList(db.Cuisines, "CuisineId", "Name");
    return View(thisRestaurant);
    }
    [HttpPost]
    public ActionResult Edit(Restaurant restaurant)
    {
        _db.Entry(item).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        var thisRestaurant = _db.Restaurant.FirstOrDefault(restaurant => restaurants.RestaurantId == id);
        return View(thisRestaurant);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        var thisRestaurant = _db.Restaurant.FirstOrDefault(restaurants => restaurants.RestaurantId == id);
        _db.Restaurant.Remove(thisRestaurant);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

  }
}