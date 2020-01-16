using System;
using System.Collections.Generic;
using System.Linq;

namespace Patterns.Mediator
{
    /// <summary>
    /// Диспетчер аэродрома.
    /// </summary>
    public class Dispatcher
    {
        /// <summary>
        /// Список функционирующих самолетов.
        /// </summary>
        private List<AircraftBase> _aircrafts = null;

        /// <summary>
        /// Список взлетно-посадочных полос аэродрома.
        /// </summary>
        private List<Land> _land = null;

        /// <summary>
        /// Самолеты.
        /// </summary>
        public IReadOnlyList<AircraftBase> Aircrafts => _aircrafts;

        /// <summary>
        /// Взлетно-посадочные полосы.
        /// </summary>
        public IReadOnlyList<Land> Lands => _land;

        /// <summary>
        /// Создать экземпляр диспетчера.
        /// </summary>
        /// <param name="aircrafts">Список самолетов.</param>
        /// <param name="lands">Список взлетно-посадочных полос.</param>
        public Dispatcher(List<AircraftBase> aircrafts, List<Land> lands)
        {
            _aircrafts = aircrafts ??
                throw new ArgumentNullException(nameof(aircrafts));

            _land = lands ??
                throw new ArgumentNullException(nameof(lands));

            // Диспетчер подписывается на событие запроса на посадку самолета.
            _aircrafts.ForEach(a => a.GoingToLand += RequestLanding);
        }

        /// <summary>
        /// Отправить самолет в полет на необходимую дистанцию
        /// </summary>
        /// <param name="distance">Дистанция полета</param>
        /// <returns>Сообщение диспетчера.</returns>
        public string Send(int distance)
        {
            if (distance < 0)
            {
                throw new ArgumentException("Дистанция полета не может быть меньше нуля.", nameof(distance));
            }

            // Ищем любой свободный самолет.
            var freeAircraft = _aircrafts.FirstOrDefault(a => a.State == AircraftState.Sleep);

            // Ищем любую свободную дорожку.
            var freeLand = _land.FirstOrDefault(l => l.Free);

            // Если дорожка и самолет найдены отправляем самолет в полет.
            if (freeAircraft != null && freeLand != null)
            {
                freeAircraft.Start(distance, freeLand);
                return $"Самолет {freeAircraft} вылетел с {freeLand} дорожки на расстояние {distance}";
            }
            // Иначе сообщаем о невозможности полета.
            else
            {
                return $"Недостаточно ресурсов. Самолет {freeAircraft}, дорожка {freeLand}";
            }
        }

        /// <summary>
        /// Обработчик события запроса на приземление.
        /// </summary>
        /// <param name="sender">Самолет, запрашивающий приземления.</param>
        /// <param name="e">Количество оставшегося топлива.</param>
        private void RequestLanding(object sender, int e)
        {
            // Идем любую свободную дорожку.
            var freeLand = _land.FirstOrDefault(l => l.Free == true);

            // Если дорожка найдена, отправляем самолет на посадку на эту дорожку.
            if (freeLand != null)
            {
                ((AircraftBase)sender).Land(freeLand);
            }
        }
    }
}