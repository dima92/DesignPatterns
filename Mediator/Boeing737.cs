namespace Patterns.Mediator
{
    /// <summary>
    /// Самолет модели Boeing 737.
    /// </summary>
    public class Boeing737 : AircraftBase
    {
        /// <summary>
        /// Создать экземпляр самолета Boeing 737.
        /// </summary>
        /// <param name="name">Имя самолета.</param>
        public Boeing737(string name) : base(name)
        {
            _maxFuel = 13399;
            Fuel = _maxFuel;
            Consumption = 2;
            Speed = 817;
        }
    }
}