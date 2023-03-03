namespace _1_WeatherApp_Delegates_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            /* Note: 
             We can use sender instead of the EventArgs in the update() Method, 
             but this assumes that we will always know the type of the class that fired the event,
             this is bad. 
             That's why we take the values from the EventArgs passed to us,
             This makes it more of a general case. 
            */

            /*  DoFactory.HeadFirst.Observer.WeatherStationObservable  */

            var weatherData = new WeatherData();

            var currentConditions = new CurrentConditionsDisplay(weatherData);
            var statisticsDisplay = new StatisticsDisplay(weatherData);
            var forecastDisplay = new ForecastDisplay(weatherData);
            var heatIndexDisplay = new HeatIndexDisplay(weatherData);

            weatherData.SetMeasurements(80, 65, 30.4f);
            weatherData.SetMeasurements(82, 70, 29.2f);
            weatherData.SetMeasurements(78, 90, 29.2f);



            /* Expected output 
            
                 Current conditions: 80F degrees and 65% humidity
                Avg/Max/Min temperature = 80/80/80
                Forecast: Improving weather on the way!
                Heat index is 82.95535

                Current conditions: 82F degrees and 70% humidity
                Avg/Max/Min temperature = 81/82/80
                Forecast: Watch out for cooler, rainy weather
                Heat index is 86.90124

                Current conditions: 78F degrees and 90% humidity
                Avg/Max/Min temperature = 80/82/78
                Forecast: More of the same
                Heat index is 83.64967
            */



            // Wait for user
            Console.ReadKey();


        }
    }
}