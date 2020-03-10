using System.Collections.Generic;
namespace Cars.Models
{
  public class Car
  {
    public static List<Car> CarList { get; set; } = new List<Car>();
    public string Make { get; set; }
    public string Model { get; set; }
    public string Description { get; set; }
    public string Year { get; set; }
    public string Price { get; set; }

    public Car(string make, string model, string description, string year, string price)
    {
      Make = make;
      Model = model;
      Description = description;
      Year = year;
      Price = price;
      CarList.Add(this);
    }


  }
}