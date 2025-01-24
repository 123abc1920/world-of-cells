using System;
using Unity.VisualScripting;

public class Event
{
    public int id;
    public int periodicity;
    public Action Handler; // использование делегатов.

    public Event(int id, int periodicity)
    {
        this.id = id;
        this.periodicity = periodicity;
    }

    public Event(int id, int periodicity, Action h)
    {
        this.id = id;
        this.periodicity = periodicity;
        this.Handler = h;
    }

    public void Trigger()
    {
        Handler?.Invoke(); //? -- оператор условного доступа. Вызывает я Handler, если он не null;
    }
}
