// Первый класс с событием
public class ClassWithEvent
{
    // Объявление делегата для обработчика события
    public delegate void EventDelegate(string message);

    // Объявление события
    public event EventDelegate MyEvent;

    // Текстовое поле объекта
    public string Text { get; set; }

    // Конструктор
    public ClassWithEvent(string text)
    {
        Text = text;
    }

    // Метод для генерирования события
    public void GenerateEvent()
    {
        // Проверка на наличие обработчиков
        if (MyEvent != null)
        {
            // Вызов события с передачей текста
            MyEvent(Text);
        }
    }
}

// Второй класс с методом-обработчиком
public class ClassWithHandler
{
    // Метод-обработчик
    public void HandleEvent(string message)
    {
        Console.WriteLine($"Событие сгенерировано объектом: {message}");
    }
}

// Основная программа
class Program
{
    static void Main(string[] args)
    {
        // Создание объектов
        ClassWithEvent object1 = new ClassWithEvent("Объект 1");
        ClassWithEvent object2 = new ClassWithEvent("Объект 2");
        ClassWithHandler handler = new ClassWithHandler();

        // Регистрация обработчика для событий обоих объектов
        object1.MyEvent += handler.HandleEvent;
        object2.MyEvent += handler.HandleEvent;

        // Генерация событий
        object1.GenerateEvent();
        object2.GenerateEvent();

        Console.ReadLine();
    }
}
