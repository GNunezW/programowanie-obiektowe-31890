namespace Lab2.Model;

public class Vehicle
{
    public string engine;
    private bool isOn = false;

    public string Engine => engine;

    public Vehicle(string engine)
    {
        this.engine = engine;
    }

    public virtual void Start()
    {
        Console.WriteLine("Vehicle started!");
        isOn = true;
    }
    public virtual void Stop()
    {
        Console.WriteLine("Vehicle stopped!");
        isOn = false;
    }
    
}