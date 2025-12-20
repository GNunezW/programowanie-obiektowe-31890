namespace Lab2.Model;

public class Car : Vehicle
{
    private string model;
    private int year;
   
    public string Model => model;

    public int Year {get => year;set => year = value;}

    public Car(string engine, string model, int year) : base(engine)
    {
        this.model = model;
        Year = year;
    }
    

}