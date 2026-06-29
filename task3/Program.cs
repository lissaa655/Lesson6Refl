using System;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        // Шлях до DLL-бібліотеки
        string path = "TemperatureLibrary.dll";

        // Завантажуємо збірку
        Assembly assembly = Assembly.LoadFrom(path);

        // Отримуємо тип класу TemperatureConverter
        Type converterType = assembly.GetType("TemperatureLibrary.TemperatureConverter");

        // Створюємо об'єкт класу через рефлексію
        object converterObject = Activator.CreateInstance(converterType);

        // Отримуємо метод CelsiusToFahrenheit
        MethodInfo method = converterType.GetMethod("CelsiusToFahrenheit");

        Console.Write("Введіть температуру в градусах Цельсія: ");
        double celsius = Convert.ToDouble(Console.ReadLine());

        // Викликаємо метод через рефлексію
        object result = method.Invoke(converterObject, new object[] { celsius });

        Console.WriteLine();
        Console.WriteLine($"{celsius} °C = {result} °F");

        Console.WriteLine();
        Console.WriteLine("Натисніть Enter для завершення...");
        Console.ReadLine();
    }
}