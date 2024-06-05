public interface IShape
{
    void SetPosition(int x, int y);
    (int x, int y) GetPosition();
}
// Клас створення форм
public class Circle : IShape
{
    private int x, y;

    public void SetPosition(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public (int x, int y) GetPosition()
    {
        return (x, y);
    }

    public override string ToString()
    {
        return $"Коло в координтах ({x}, {y})";
    }
}

public class Rectangle : IShape
{
    private int x, y;

    public void SetPosition(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public (int x, int y) GetPosition()
    {
        return (x, y);
    }

    public override string ToString()
    {
        return $"Прямокутник в координтах ({x}, {y})";
    }
}
// Клас Servant
public class MoveServant
{
    public void MoveTo(IShape shape, int newX, int newY)
    {
        shape.SetPosition(newX, newY);
    }
}
// Використання
public class Program
{
    public static void Main()
    {
        IShape circle = new Circle();
        IShape rectangle = new Rectangle();

        MoveServant moveServant = new MoveServant();

        // Встановлення початкових позицій
        circle.SetPosition(0, 0);
        rectangle.SetPosition(10, 10);

        // Переміщення фігур за допомогою servant
        moveServant.MoveTo(circle, 5, 5);
        moveServant.MoveTo(rectangle, 15, 15);

        // Відображення нових позицій
        Console.WriteLine(circle); // Output: Коло (5, 5)
        Console.WriteLine(rectangle); // Output: Прямокутник(15, 15)
    }
}

