using System.Text.Json;
using KomisSamochodowy;

class Program
{
    static List<Vehicle> vehicles = new();

    static int nextId = 1;

    static int GetNextId() => nextId++;
    
    static readonly string DataDir =
        Path.Combine(AppContext.BaseDirectory, "Model");

    static readonly string CarsPath =
        Path.Combine(DataDir, "cars.json");

    static readonly string BikesPath =
        Path.Combine(DataDir, "bikes.json");

    static void Main()
    {
        LoadData();

        bool continueApp = true;

        do
        {
            Console.WriteLine("---Menu---");
            Console.WriteLine("1. Pokaz samochody");
            Console.WriteLine("2. Pokaż motocykle");
            Console.WriteLine("3. Dodaj pojazd");
            Console.WriteLine("4. Usuń pojazd");
            Console.WriteLine("5. Modyfikuj pojazd");
            Console.WriteLine("0. Wyjscie");

            var option = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (option)
            {
                case '0': continueApp = false; break;
                case '1': ShowCars(); break;
                case '2': ShowBikes(); break;
                case '3': AddVehicle(); break;
                case '4': RemoveVehicle(); break;
                case '5': ModifyVehicle(); break;
                default: Console.WriteLine("Nieprawidlowa opcja!"); break;
            }
        } while (continueApp);
    }

    static void LoadData()
    {
        if (File.Exists(CarsPath))
        {
            var cars = JsonSerializer.Deserialize<List<Car>>(File.ReadAllText(CarsPath));
            if (cars != null)
                vehicles.AddRange(cars);
        }

        if (File.Exists(BikesPath))
        {
            var bikes = JsonSerializer.Deserialize<List<Bike>>(File.ReadAllText(BikesPath));
            if (bikes != null)
                vehicles.AddRange(bikes);
        }

        nextId = vehicles.Any()
            ? vehicles.Max(v => v.Id) + 1
            : 1;
    }

    static void SaveData()
    {
        File.WriteAllText(
            CarsPath,
            JsonSerializer.Serialize(
                vehicles.OfType<Car>().ToList(),
                new JsonSerializerOptions { WriteIndented = true })
        );

        File.WriteAllText(
            BikesPath,
            JsonSerializer.Serialize(
                vehicles.OfType<Bike>().ToList(),
                new JsonSerializerOptions { WriteIndented = true })
        );
    }

    static void AddVehicle()
    {
        Console.Write("Typ pojazdu (1->car, 0->bike): ");
        var option = Console.ReadKey().KeyChar;
        Console.WriteLine();

        if (option == '1') AddNewCar();
        else if (option == '0') AddNewBike();
        else Console.WriteLine("Nieznany typ pojazdu!");
    }

    static void AddNewCar()
    {
        Console.Write("Model: ");
        var model = Console.ReadLine();

        Console.Write("Silnik: ");
        var engine = Console.ReadLine();

        Console.Write("Rok: ");
        if (!int.TryParse(Console.ReadLine(), out int year))
            return;

        var car = new Car(GetNextId(), engine!, model!, year);
        vehicles.Add(car);
        SaveData();
    }

    static void AddNewBike()
    {
        Console.Write("Typ motoru: ");
        var bikeType = Console.ReadLine();

        Console.Write("Silnik: ");
        var engine = Console.ReadLine();

        var bike = new Bike(GetNextId(), engine!, bikeType!);
        vehicles.Add(bike);
        SaveData();
    }

    static void RemoveVehicle()
    {
        Console.Write("Typ pojazdu (1->car, 0->bike): ");
        var option = Console.ReadKey().KeyChar;
        Console.WriteLine();

        if (option == '1') ShowCars();
        else if (option == '0') ShowBikes();
        else return;

        Console.Write("Podaj ID pojazdu do usunięcia: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
            return;

        var vehicle = vehicles.FirstOrDefault(v => v.Id == id);
        if (vehicle == null)
            return;

        vehicles.Remove(vehicle);
        SaveData();
    }

    static void ModifyVehicle()
    {
        Console.Write("Typ pojazdu (1->car, 0->bike): ");
        var option = Console.ReadKey().KeyChar;
        Console.WriteLine();

        List<Vehicle> selectedVehicles;

        if (option == '1')
        {
            selectedVehicles = vehicles.OfType<Car>().Cast<Vehicle>().ToList();
            if (!selectedVehicles.Any())
            {
                Console.WriteLine("Brak samochodów");
                return;
            }

            ShowCars();
        }
        else if (option == '0')
        {
            selectedVehicles = vehicles.OfType<Bike>().Cast<Vehicle>().ToList();
            if (!selectedVehicles.Any())
            {
                Console.WriteLine("Brak motocykli");
                return;
            }

            ShowBikes();
        }
        else
        {
            Console.WriteLine("Nieprawidłowy typ pojazdu");
            return;
        }

        Console.Write("Podaj ID pojazdu do modyfikacji");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Nieprawidłowe ID");
            return;
        }

        var vehicle = selectedVehicles.FirstOrDefault(v => v.Id == id);
        if (vehicle == null)
        {
            Console.WriteLine("Nie znaleziono pojazdu o podanym ID");
            return;
        }

        Console.Write("Nowy silnik: ");
        vehicle.Engine = Console.ReadLine()!;

        if (vehicle is Car car)
        {
            Console.Write("Nowy model: ");
            car.Model = Console.ReadLine()!;
            Console.Write("Nowy rok: ");
            car.Year = int.Parse(Console.ReadLine()!);
        }
        else if (vehicle is Bike bike)
        {
            Console.Write("Nowy typ motoru: ");
            bike.BikeType = Console.ReadLine()!;
        }

        SaveData();
        Console.WriteLine("Pojazd zmodyfikowany");
    }

    static void ShowCars()
    {
        foreach (var car in vehicles.OfType<Car>())
            Console.WriteLine($"{car.Id}. {car.Model} ({car.Year}) {car.Engine}");
    }

    static void ShowBikes()
    {
        foreach (var bike in vehicles.OfType<Bike>())
            Console.WriteLine($"{bike.Id}. {bike.BikeType} - {bike.Engine}");
    }
}