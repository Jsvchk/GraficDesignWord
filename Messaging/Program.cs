using System;
using System.Collections.Generic;
// Клас повідомлень
public class Message
{
    public string Content { get; }
    public string Sender { get; }
    public string Receiver { get; }

    public Message(string content, string sender, string receiver)
    {
        Content = content;
        Sender = sender;
        Receiver = receiver;
    }
}
// Посередник повідомлень

public class MessageBroker
{
    private readonly Dictionary<string, List<Action<Message>>> _subscribers = new Dictionary<string, List<Action<Message>>>();

    public void Subscribe(string receiver, Action<Message> handler)
    {
        if (!_subscribers.ContainsKey(receiver))
        {
            _subscribers[receiver] = new List<Action<Message>>();
        }
        _subscribers[receiver].Add(handler);
    }

    public void SendMessage(Message message)
    {
        if (_subscribers.ContainsKey(message.Receiver))
        {
            foreach (var handler in _subscribers[message.Receiver])
            {
                handler(message);
            }
        }
    }
}

// Компоненти
public class ComponentA
{
    private readonly string _name;
    private readonly MessageBroker _broker;

    public ComponentA(string name, MessageBroker broker)
    {
        _name = name;
        _broker = broker;
        _broker.Subscribe(_name, ReceiveMessage);
    }

    public void SendMessage(string content, string receiver)
    {
        var message = new Message(content, _name, receiver);
        _broker.SendMessage(message);
    }

    private void ReceiveMessage(Message message)
    {
        Console.WriteLine($"{_name} отримано повідомлення від {message.Sender}: {message.Content}");
    }
}

public class ComponentB
{
    private readonly string _name;
    private readonly MessageBroker _broker;

    public ComponentB(string name, MessageBroker broker)
    {
        _name = name;
        _broker = broker;
        _broker.Subscribe(_name, ReceiveMessage);
    }

    public void SendMessage(string content, string receiver)
    {
        var message = new Message(content, _name, receiver);
        _broker.SendMessage(message);
    }

    private void ReceiveMessage(Message message)
    {
        Console.WriteLine($"{_name} отримано повідомлення від {message.Sender}: {message.Content}");
    }
}
// Використання
public class Program
{
    public static void Main()
    {
        var broker = new MessageBroker();

        var componentA = new ComponentA("Manager", broker);
        var componentB = new ComponentB("Client", broker);

        componentA.SendMessage("Вітаю, Client!", "Client");
        componentB.SendMessage("Привіт, Manager!", "Manager");
    }
}
