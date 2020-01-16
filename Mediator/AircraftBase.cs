using System;
using System.Threading;

namespace Patterns.Mediator
{
    /// <summary>
    /// Базовый класс самолета.
    /// </summary>
    public abstract class AircraftBase
    {
        /// <summary>
        /// Поток, в котором происходит процесс полета.
        /// </summary>
        protected Thread _flyThread;

        /// <summary>
        /// Состояние самолета.
        /// </summary>
        protected AircraftState _state;

        /// <summary>
        /// Максимальное количество топлива.
        /// </summary>
        protected int _maxFuel = 1000;

        /// <summary>
        /// Имя самолета.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Топливо самолета.
        /// </summary>
        public int Fuel { get; protected set; }

        /// <summary>
        /// Расход топлива.
        /// </summary>
        public int Consumption { get; protected set; }

        /// <summary>
        /// Скорость полета.
        /// </summary>
        public int Speed { get; protected set; }

        /// <summary>
        /// Состояние самолета.
        /// </summary>
        public AircraftState State
        {
            get
            {
                return _state;
            }
            protected set
            {
                _state = value;
                StateChanged?.Invoke(this, value);
            }
        }

        /// <summary>
        /// Состояние самолета изменено.
        /// </summary>
        public event EventHandler<AircraftState> StateChanged;

        /// <summary>
        /// Самолет хочет выполнить посадку.
        /// </summary>
        public event EventHandler<int> GoingToLand;

        /// <summary>
        /// Создать новый экземпляр самолета.
        /// </summary>
        /// <param name="name">Имя самолета.</param>
        public AircraftBase(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
            State = AircraftState.Sleep;
        }

        //// <summary>
        /// Начать полет самолета.
        /// </summary>
        /// <param name="distance">Дистанция, которую должен преодолеть самолет.</param>
        /// <param name="land">Взлетная полоса аэропорта.</param>
        public void Start(int distance, Land land)
        {
            // 
            if (!GoTakeOff(land))
            {
                return;
            }
            _flyThread = new Thread(Fly);
            _flyThread.Start(distance);
        }

        /// <summary>
        /// Разрешить посадку самолету.
        /// </summary>
        /// <param name="land">Посадочная полоса аэропорта.</param>
        public void Land(Land land)
        {
            // Всегда есть шанс, что самолет разобьется...
            if (Dead())
            {
                return;
            }

            // Самолет приземлился и занял полосу.
            land.Free = false;
            Thread.Sleep(5000);
            State = AircraftState.Land;

            // Самолет уехал в ангар. Полет полностью завершен.
            Thread.Sleep(5000);
            State = AircraftState.Sleep;
            land.Free = true;
            _flyThread.Abort();
        }

        /// <summary>
        /// Выполняется полет самолета.
        /// </summary>
        /// <param name="distance">Дистанция полета.</param>
        protected void Fly(object distance)
        {
            // Самолет летит по маршруту.
            var dist = (int)distance;
            while (dist > 0)
            {
                // Уменьшается дистанция и запас топлива
                Fuel -= Consumption;
                dist -= Speed;
                Thread.Sleep(1000);

                if (Fuel <= 0)
                {
                    State = AircraftState.Dead;
                    return;
                }
            }

            // Самолет достиг конечной точки и ожидает посадки.
            WaitLanding();
        }

        /// <summary>
        /// Самолет ожидает посадки.
        /// </summary>
        protected void WaitLanding()
        {
            // Самолет готов садиться.
            State = AircraftState.GoToLand;

            // До тех пор пока разрешение на посадку не получено
            // ожидаем посадки в воздухе
            while (State == AircraftState.GoToLand)
            {
                GoingToLand?.Invoke(this, Fuel);
                Fuel -= Consumption;
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Определение случилась ли катастрофа с самолетом.
        /// </summary>
        /// <returns>Самолет разбился.</returns>
        protected bool Dead()
        {
            // Используем два генератора случайных чисел с разными шумом, 
            // чтобы была вероятность выпадения одинаковых чисел.
            var random1 = new Random(Convert.ToInt32(DateTime.Now.Ticks % int.MaxValue));
            var random2 = new Random(DateTime.Now.Millisecond);

            // 1000 просто магическое число, определяющее вероятность крушения самолета.
            var dice1 = random1.Next(0, 1000);
            var dice2 = random2.Next(0, 1000);
            if (dice1 == dice2)
            {
                State = AircraftState.Dead;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Отправляем самолет на взлет.
        /// </summary>
        /// <param name="land">Взлетная полоса для самолета.</param>
        /// <returns>Разбился ли самолет при взлете.</returns>
        protected bool GoTakeOff(Land land)
        {

            // Самолет готовится ко взлету и взлетает.
            land.Free = false;
            Fuel = _maxFuel;
            State = AircraftState.GoToFly;
            Thread.Sleep(10000);
            if (Dead())
            {
                return false;
            }

            // Самолет взлетел.
            State = AircraftState.Fly;
            land.Free = true;

            return true;
        }

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns>Название самолета.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}