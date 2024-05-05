public class ClassWithEvent
{
    public delegate void EventDelegate(string message);

    public event EventDelegate MyEvent;
  
    public string Text { get; set; }
  
    public ClassWithEvent(string text)
    {
        Text = text;
    }

    public void GenerateEvent()
    {
        if (MyEvent != null)
        {   
            MyEvent(Text);
        }
    }
}

public class ClassWithHandler
{   
    public void HandleEvent(string message)
    {
        Console.WriteLine($"Событие сгенерировано объектом: {message}");
    }
}

class Program
{
    static void Main(string[] args)
    {     
        ClassWithEvent object1 = new ClassWithEvent("Объект 1");
        ClassWithEvent object2 = new ClassWithEvent("Объект 2");
        ClassWithHandler handler = new ClassWithHandler();

        object1.MyEvent += handler.HandleEvent;
        object2.MyEvent += handler.HandleEvent;

        object1.GenerateEvent();
        object2.GenerateEvent();

        Console.ReadLine();
    }
}
