namespace KomisSamochodowy;

public class Car : Vehicle
{
    public string Model { get; set; }

    private int _year;

    public int Year
    {
        get => _year;
        set
        {
            if (value <= 2000)
                throw new ArgumentOutOfRangeException(nameof(Year));

            _year = value;
        }
    }


    public Car(int id, string engine, string model, int year) : base(id, engine)
    {
        Model = model;
        Year = year;
    }
}