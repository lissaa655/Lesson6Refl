using System;

namespace TemperatureLibrary
{
    public class TemperatureConverter
    {
        public double CelsiusToFahrenheit(double celsius)
        {
            return celsius * 9 / 5 + 32;
        }

        public double FahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }

        public double CelsiusToKelvin(double celsius)
        {
            return celsius + 273.15;
        }

        public double KelvinToCelsius(double kelvin)
        {
            return kelvin - 273.15;
        }

        public void ShowInfo()
        {
            Console.WriteLine("TemperatureLibrary: збірка для конвертації температури.");
        }
    }
}