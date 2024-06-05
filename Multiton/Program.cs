using System;
using System.Collections.Generic;

public class Multiton
{ 
    // Словник для зберігання екземплярів
    private static readonly Dictionary<string, Multiton> instances = new Dictionary<string, Multiton>();

    // Конструктор для запобігання інстанціювання
    private Multiton(string key)
    {
        Key = key;
    }

    // Доступ до ключа
    public string Key { get; }

    // Метод для отримання екземпляру за ключем
    public static Multiton GetInstance(string key)
    {
        if (!instances.ContainsKey(key))
        {
            instances[key] = new Multiton(key);
        }
        return instances[key];
    }
    public static void ListInstances()
    {
        foreach (var instance in instances)
        {
            Console.WriteLine($"Клавіша: {instance.Key}, Екземпляр: {instance.Value}");
        }
    }
}

public class Program
{
    public static void Main()
    {
        // Доступ до екземплярів за допомогою ключів.
        var instance1 = Multiton.GetInstance("Esc");
        var instance2 = Multiton.GetInstance("Space");
        var instance3 = Multiton.GetInstance("Ctr"); 

        // Перевіряє, чи існують однакові екземпляри для одного і того ж ключа.
        Console.WriteLine(ReferenceEquals(instance1, instance3)); // True
        Console.WriteLine(ReferenceEquals(instance1, instance2)); // False

        // Перебирає всі випадки
        Multiton.ListInstances();
    }
}

