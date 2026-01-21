namespace KomisSamochodowy;

public class Bike : Vehicle
{
    public string BikeType { get; set; }

    public Bike(int id, string engine, string bikeType) : base(id, engine)
    {
        BikeType = bikeType;
    }

    public override void Start()
    {
        Console.WriteLine("Unlock");
    }
}