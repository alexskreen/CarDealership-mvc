using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Cars.Models;

namespace Cars.Controllers
{
  public class CarsController : Controller
  {

    [HttpGet("/show-cars")]
    public ActionResult ShowCars()
    {
      List<Car> newList = Car.GetAll();
      Console.WriteLine("Car list count " + newList.Count);
      return View(newList);
    }

    [HttpGet("/add-car/new")]
    public ActionResult AddCar()
    {
      return View();
    }

    [HttpPost("/add-car")]
    public ActionResult Create(string make, string model, string description, string year, int price)
    {
      Car newCar = new Car(make, model, description, year, price);
      newCar.Save();
      return RedirectToAction("ShowCars");
    }

  }
}