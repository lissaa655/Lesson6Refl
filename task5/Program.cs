using System;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("ПРОГРАМА-РЕФЛЕКТОР");
        Console.WriteLine();

        Console.Write("Введіть шлях до збірки (.dll або .exe): ");
        string path = Console.ReadLine();

        try
        {
            Assembly assembly = Assembly.LoadFrom(path);

            Console.WriteLine();
            Console.WriteLine("ІНФОРМАЦІЯ ПРО ЗБІРКУ");
            Console.WriteLine("Повне ім'я: " + assembly.FullName);
            Console.WriteLine("Розташування: " + assembly.Location);

            AssemblyName assemblyName = assembly.GetName();

            Console.WriteLine("Назва: " + assemblyName.Name);
            Console.WriteLine("Версія: " + assemblyName.Version);
            Console.WriteLine("Культура: " + assemblyName.CultureName);

            Console.WriteLine();
            Console.WriteLine("ТИПИ У ЗБІРЦІ");

            Type[] types = assembly.GetTypes();

            foreach (Type type in types)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Тип: " + type.FullName);
                Console.WriteLine("Базовий клас: " + type.BaseType);

                Console.WriteLine();

                Console.WriteLine("Методи:");
                MethodInfo[] methods = type.GetMethods();

                foreach (MethodInfo method in methods)
                {
                    Console.WriteLine(" - " + method.ReturnType.Name + " " + method.Name);
                }

                Console.WriteLine();

                Console.WriteLine("Властивості:");
                PropertyInfo[] properties = type.GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    Console.WriteLine(" - " + property.PropertyType.Name + " " + property.Name);
                }

                Console.WriteLine();

                Console.WriteLine("Поля:");
                FieldInfo[] fields = type.GetFields();

                foreach (FieldInfo field in fields)
                {
                    Console.WriteLine(" - " + field.FieldType.Name + " " + field.Name);
                }

                Console.WriteLine();

                Console.WriteLine("Конструктори:");
                ConstructorInfo[] constructors = type.GetConstructors();

                foreach (ConstructorInfo constructor in constructors)
                {
                    Console.WriteLine(" - " + constructor.Name);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }

        Console.WriteLine();
        Console.WriteLine("Натисніть Enter для завершення...");
        Console.ReadLine();
    }
}