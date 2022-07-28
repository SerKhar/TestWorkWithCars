using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWorkWithCars
{
    internal class PassengerCar:Car
    {
        /// <summary>
        /// кол-во пассажиров
        /// </summary>
        private int countPassengers;

        public int CountPassengers
        {
            get { return countPassengers; }
            set
            {
                if (value < 0 || value > 4)
                {
                    throw new ArgumentException("Неверное кол-во пассажиров");
                }
                countPassengers = value;
            }
        }

        public PassengerCar(EnumCarTypes carTypes, decimal averageFuelConsumption, int fuelTankVolume, decimal speed, int countPassengers)
        {
            if(carTypes != EnumCarTypes.PassengerCar)
            {
                throw new ArgumentException("Не верно задан тип автомобиля");
            }

            this.CarType = carTypes;
            this.AverageFuelConsumption = averageFuelConsumption;
            this.FuelTankVolume = fuelTankVolume;
            this.Speed = speed;
            this.CountPassengers = countPassengers;
        }

        public override decimal СalculationOfTheStateOfThePowerReserveDependingOnPassengersAndCargo(decimal remainingFuel)
        {
            return this.CalculationDistanceOnRemainingFuel(remainingFuel) * (1-(0.06m * this.CountPassengers));
        }

        public override decimal СalculatingTheTimeItTakesToTravelGivenPath(decimal setDistance, decimal fuelQuantity)
        {
            if (СalculationOfTheStateOfThePowerReserveDependingOnPassengersAndCargo(fuelQuantity) < setDistance)
            {
                throw new ArgumentException("На оставшимся кол-ве топлива не проедешь данную дистанцию");
            }
            return setDistance / Speed;
        }
    }
}
