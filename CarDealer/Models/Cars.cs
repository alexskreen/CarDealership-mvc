using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Cars.Models
{
  public class Car
  {
    // public static List<Car> CarList { get; set; } = new List<Car>();
    public string Make { get; set; }
    public string Model { get; set; }
    public string Description { get; set; }
    public string Year { get; set; }
    public string Price { get; set; }
    public int Id { get; set; }


    public Car() { }

    public Car(int id, string make, string model, string description, string year, string price)
    {
      Id = id;
      Make = make;
      Model = model;
      Description = description;
      Year = year;
      Price = price;
      // CarList.Add(this);
    }

    // public static List<Car> GetAll()
    // {
    //   // return _Cars;
    // }

    // public static void ClearAll()
    // {
    //   _Cars.Clear();
    // }


    public static Car Find(int Id)
    {
      Car placeholderCar = new Car();
      return placeholderCar;
    }

    public static List<Car> GetAll()
    {
      List<Car> allCars = new List<Car> { };
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM items;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int CarId = rdr.GetInt32(0);
        // string itemDescription = rdr.GetString(1);
        Car newCar = new Car(make, model, description, year, price);
        allCars.Add(newCar);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allItems;
    }


  }
}