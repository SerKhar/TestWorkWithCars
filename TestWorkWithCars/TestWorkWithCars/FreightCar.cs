using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWorkWithCars
{
    internal class FreightCar:Car
    {
        /// <summary>
        /// грузоподъемность в кг
        /// </summary>
        public decimal Carrying { get; set; }
        private decimal cargoWeigth;

        public decimal CargoWeigth
        {
            get { return cargoWeigth; }
            set 
            {
                if(value < 0 || value > Carrying)
                {
                    throw new ArgumentException("Некорректно задан груз");
                }
                cargoWeigth = value;
            }
        }

        public FreightCar(EnumCarTypes carTypes, decimal averageFuelConsumption, int fuelTankVolume, decimal speed, decimal carrying, decimal cargoWeigth)
        {
            if (carTypes != EnumCarTypes.FreightCar)
            {
                throw new ArgumentException("Не верно задан тип автомобиля");
            }
            this.CarType = carTypes;
            this.AverageFuelConsumption = averageFuelConsumption;
            this.FuelTankVolume = fuelTankVolume;
            this.Speed = speed;
            this.Carrying = carrying;
            this.CargoWeigth = cargoWeigth;
        }

        public override decimal СalculationOfTheStateOfThePowerReserveDependingOnPassengersAndCargo(decimal remainingFuel)
        {
            return this.CalculationDistanceOnRemainingFuel(remainingFuel) * (1 - (0.04m * this.cargoWeigth / 200));
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
