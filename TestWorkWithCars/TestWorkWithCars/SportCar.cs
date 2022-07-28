using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWorkWithCars
{
    internal class SportCar:PassengerCar
    {
        public SportCar(EnumCarTypes carTypes, decimal averageFuelConsumption, int fuelTankVolume, decimal speed, int countPassengers):base(EnumCarTypes.PassengerCar,  averageFuelConsumption,  fuelTankVolume, speed, countPassengers)
        {
            if (carTypes != EnumCarTypes.SportCar)
            {
                throw new ArgumentException("Не верно задан тип автомобиля");
            }

            this.CarType = carTypes;
            this.AverageFuelConsumption = averageFuelConsumption;
            this.FuelTankVolume = fuelTankVolume;
            this.Speed = speed;
            this.CountPassengers = countPassengers;
        }
    }
}
