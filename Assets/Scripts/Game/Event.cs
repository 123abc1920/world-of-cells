public class Event
{
    public string message;
    public int id;
    public int periodicity;

    public Event(string message, int id, int periodicity){
        this.message=message;
        this.id=id;
        this.periodicity=periodicity;
    }
}
