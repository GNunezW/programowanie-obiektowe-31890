namespace Lab2.Model;

public class Bike  : Vehicle
{
    private string bikeType;
    public  override void Start()
    {
        Console.WriteLine("Unlock");
    }

    public Bike(string engine, string bikeType) : base(engine)
    { this.bikeType = bikeType; }
    
}