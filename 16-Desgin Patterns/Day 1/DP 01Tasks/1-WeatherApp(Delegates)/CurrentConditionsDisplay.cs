
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_WeatherApp_Delegates_
{

    public class CurrentConditionsDisplay
    {
        private WeatherData _weatherData;
        private float _temperature;
        private float _humidity;

        public CurrentConditionsDisplay(WeatherData weatherData)
        {
            this._weatherData = weatherData;
            _weatherData.MeasurementsChanged += Update;
        }

        private void Update(object sender, MeasurementsChangedEventArgs e)
        {
            this._temperature = e.Temperature;
            this._humidity = e.Humidity;
            Display();
        }

        public void Display()
        {
            Console.WriteLine("Current conditions: " + _temperature
                + "F degrees and " + _humidity + "% humidity");
        }
    }
}
