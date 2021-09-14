using System.Collections.Generic;
using TrafiCarSharingAPI.Core.Entities;

namespace TrafiCarSharingAPI.Core.Helpers
{
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            Database.Cars.AddRange(new List<Car>
            {
                new Car
                {
                    Id = "31696ef7-fef7-4e6e-8c0c-d575ddc4b0e1",
                    Color = "grey",
                    Model = "Peugeot 207",
                    Plate = "HJJ780",
                    Seats = 5,
                    Year = 2007,
                    ChildSeat = false,
                    RangeFullKm = 900,
                    Engine = new Engine
                    {
                        Fuel = FuelType.Diesel,
                        Transmission = TransmissionType.Manual
                    },
                    Tracker = new Tracker
                    {
                        Imei = "867481037186321",
                        Phone = "+467191201092539"
                    }
                },
                new Car
                {
                    Id = "a792d056-383f-4cc8-885b-a6c8d61711df",
                    Color = "blue",
                    Model = "VW Golf",
                    Plate = "DEJ201",
                    Seats = 5,
                    Year = 2017,
                    ChildSeat = false,
                    RangeFullKm = 1000,
                    Engine = new Engine
                    {
                        Fuel = FuelType.Diesel,
                        Transmission = TransmissionType.Manual
                    },
                    Tracker = new Tracker
                    {
                        Imei = "917481037186321",
                        Phone = "+467191201092540"
                    }
                },
                new Car
                {
                    Id = "401d1e2d-1cab-4cac-b1db-37305e6413f9",
                    Color = "blue",
                    Model = "VW Golf",
                    Plate = "RHJ 170",
                    Seats = 5,
                    Year = 2017,
                    ChildSeat = false,
                    RangeFullKm = 1000,
                    Engine = new Engine
                    {
                        Fuel = FuelType.Diesel,
                        Transmission = TransmissionType.Manual
                    },
                    Tracker = new Tracker
                    {
                        Imei = "867481407186321",
                        Phone = "+467191201102539"
                    }
                },
                new Car
                {
                    Id = "502f9fee-d93e-44cc-a9f9-338eb1fae6fe",
                    Color = "white",
                    Model = "VW Passat",
                    Plate = "HRJ 701",
                    Seats = 5,
                    Year = 2016,
                    ChildSeat = false,
                    RangeFullKm = 1200,
                    Engine = new Engine
                    {
                        Fuel = FuelType.Petrol,
                        Transmission = TransmissionType.Automatic
                    },
                    Tracker = new Tracker
                    {
                        Imei = "867481037187121",
                        Phone = "+467201201092539"
                    }
                },
                new Car
                {
                    Id = "5b2523bc-81af-4323-9b53-718da1d52776",
                    Color = "pink",
                    Model = "VW UP!",
                    Plate = "EV0731",
                    Seats = 5,
                    Year = 2018,
                    ChildSeat = false,
                    RangeFullKm = 150,
                    Engine = new Engine
                    {
                        Fuel = FuelType.Electric,
                        Transmission = TransmissionType.Automatic
                    },
                    Tracker = new Tracker
                    {
                        Imei = "867481037186366",
                        Phone = "+467191201092563"
                    }
                },
                new Car
                {
                    Id = "50e67013-402e-4572-8466-3a2365eb4b63",
                    Color = "pink",
                    Model = "VW UP!",
                    Plate = "HJJ780",
                    Seats = 5,
                    Year = 2018,
                    ChildSeat = false,
                    RangeFullKm = 150,
                    Engine = new Engine
                    {
                        Fuel = FuelType.Electric,
                        Transmission = TransmissionType.Automatic
                    },
                    Tracker = new Tracker
                    {
                        Imei = "867481037786321",
                        Phone = "+467111101092539"
                    }
                }
            });
        }
    }
}
