using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Cars.Models;

namespace Cars.Controllers
{
  public class CarsController : Controller
  {

    [HttpGet("/show-cars")]
    public ActionResult ShowCars()
    {
      List<Car> newList = Car.CarList;
      return View(newList);
    }

    [HttpGet("/add-car/new")]
    public ActionResult AddCar()
    {
      return View();
    }

    [HttpPost("/add-car")]
    public ActionResult Create(string make, string year, string model, string description, string price)
    {
      Car newCar = new Car(make, model, description, year, price);
      return RedirectToAction("ShowCars");
    }


  }
}