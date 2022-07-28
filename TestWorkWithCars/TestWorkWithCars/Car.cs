using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWorkWithCars
{
    internal abstract class Car
    {
        /// <summary>
        ///Тип транспортного средства
        /// </summary>
        public EnumCarTypes CarType { get; set; }
        /// <summary>
        /// среднего расхода топлива
        /// </summary>
        public decimal AverageFuelConsumption { get; set; }
        /// <summary>
        /// объем топливного бака
        /// </summary>
        public int FuelTankVolume { get; set; }
        /// <summary>
        /// скорость тс
        /// </summary>
        public decimal Speed { get; set; }
        /// <summary>
        ///Метод расчета пути на оставшем топливе
        /// </summary>
        public  decimal CalculationDistanceOnRemainingFuel(decimal remainingFuel)
        {
            return Speed  * remainingFuel * 100 / AverageFuelConsumption;
        }
        /// <summary>
        ///Метод подсчета состояния запаса хода в зависимости от пассажиров и груза
        /// </summary>
        public abstract decimal СalculationOfTheStateOfThePowerReserveDependingOnPassengersAndCargo(decimal remainingFuel);
        /// <summary>
        ///Метод, который на основе параметров количества топлива и заданного расстояния вычисляет за сколько автомобиль его преодолеет
        /// </summary>
        public virtual  decimal  СalculatingTheTimeItTakesToTravelGivenPath(decimal setDistance, decimal fuelQuantity)
        {
            if(CalculationDistanceOnRemainingFuel(fuelQuantity) < setDistance)
            {
                throw new ArgumentException("На оставшимся кол-ве топлива не проедешь данную дистанцию");
            }
            return setDistance / Speed; 
        }

    }
}
