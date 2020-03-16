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
    public int Price { get; set; }
    public int Id { get; set; }


    public Car() { }

    public Car(string make, string model, string description, string year, int price)
    {
      Make = make;
      Model = model;
      Description = description;
      Year = year;
      Price = price;
    }
    public Car(int id, string make, string model, string description, string year, int price)
    {
      Id = id;
      Make = make;
      Model = model;
      Description = description;
      Year = year;
      Price = price;
    }

    // public static List<Car> GetAll()
    // {
    //   // return _Cars;
    // }

    // public static void ClearAll()
    // {
    //   _Cars.Clear();
    // }
    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;

      // Begin new code
      cmd.CommandText = @"INSERT INTO cars (make, model, description, year, price) VALUES (@carMake, @carModel, @carDescription, @carYear, @carPrice);";
      MySqlParameter carMake = new MySqlParameter();
      carMake.ParameterName = "@carMake";
      carMake.Value = this.Make;

      MySqlParameter carModel = new MySqlParameter();
      carModel.ParameterName = "@carModel";
      carModel.Value = this.Model;

      MySqlParameter carDescription = new MySqlParameter();
      carDescription.ParameterName = "@carDescription";
      carDescription.Value = this.Description;

      MySqlParameter carYear = new MySqlParameter();
      carYear.ParameterName = "@carYear";
      carYear.Value = this.Year;

      MySqlParameter carPrice = new MySqlParameter();
      carPrice.ParameterName = "@carPrice";
      carPrice.Value = this.Price;

      cmd.Parameters.Add(carMake);
      cmd.Parameters.Add(carModel);
      cmd.Parameters.Add(carDescription);
      cmd.Parameters.Add(carYear);
      cmd.Parameters.Add(carPrice);

      cmd.ExecuteNonQuery();
      Id = (int)cmd.LastInsertedId;

      // End new code

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }

    }


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
      cmd.CommandText = @"SELECT * FROM cars;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while (rdr.Read())
      {
        int CarId = rdr.GetInt32(0);
        string carMake = rdr.GetString(1);
        string carModel = rdr.GetString(2);
        string carDescription = rdr.GetString(3);
        string carYear = rdr.GetString(4);
        int carPrice = rdr.GetInt32(5);
        Car newCar = new Car(carMake, carModel, carDescription, carYear, carPrice);
        allCars.Add(newCar);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCars;
    }


  }
}