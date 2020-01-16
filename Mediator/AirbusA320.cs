namespace Patterns.Mediator
{
    /// <summary>
    /// Самолет модели Airbus A320.
    /// </summary>
    public class AirbusA320 : AircraftBase
    {
        /// <summary>
        /// Создать экземпляр самолета Airbus A320.
        /// </summary>
        /// <param name="name">Имя самолета.</param>
        public AirbusA320(string name) : base(name)
        {
            _maxFuel = 14400;
            Fuel = _maxFuel;
            Consumption = 3;
            Speed = 811;
        }
    }
}