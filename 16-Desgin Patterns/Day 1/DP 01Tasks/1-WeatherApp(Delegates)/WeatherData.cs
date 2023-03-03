using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace _1_WeatherApp_Delegates_
{
    public class WeatherData
    {
        private float _temperature;
        private float _humidity;
        private float _pressure;

        public event EventHandler<MeasurementsChangedEventArgs> MeasurementsChanged;

        public void SetMeasurements(float temperature, float humidity, float pressure)
        {
            _temperature = temperature;
            _humidity = humidity;
            _pressure = pressure;

            /* We fire the event and send the new measurements to all the subscribers.*/
            OnMeasurementsChanged(new MeasurementsChangedEventArgs(_temperature, _humidity, _pressure));
        }

        protected virtual void OnMeasurementsChanged(MeasurementsChangedEventArgs e)
        {
            MeasurementsChanged?.Invoke(this, e);
        }

        public float Temperature => _temperature;

        public float Humidity => _humidity;

        public float Pressure => _pressure;
    }


    public class MeasurementsChangedEventArgs : EventArgs
    {
        public float Temperature { get; }
        public float Humidity { get; }
        public float Pressure { get; }

        public MeasurementsChangedEventArgs(float temperature, float humidity, float pressure)
        {
            Temperature = temperature;
            Humidity = humidity;
            Pressure = pressure;
        }
    }
}
