using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_WeatherApp_Delegates_
{
    public class ForecastDisplay
    {
        private float _currentPressure = 29.92f;
        private float _lastPressure;

        public ForecastDisplay(WeatherData weatherData)
        {
            weatherData.MeasurementsChanged += Update;
        }

        private void Update(object sender, MeasurementsChangedEventArgs e)
        {
            _lastPressure = _currentPressure;
            _currentPressure = e.Pressure;
            Display();
        }

        public void Display()
        {
            Console.Write("Forecast: ");
            if (_currentPressure > _lastPressure)
            {
                Console.WriteLine("Improving weather on the way!");
            }
            else if (_currentPressure == _lastPressure)
            {
                Console.WriteLine("More of the same");
            }
            else if (_currentPressure < _lastPressure)
            {
                Console.WriteLine("Watch out for cooler, rainy weather");
            }
        }
    }
}
