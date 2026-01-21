namespace KomisSamochodowy;

    public class Vehicle
    {
        public string Engine { get; set; }
        private bool isOn = false;
        public int Id { get; set; }

        public Vehicle(int id, string engine)
        {
            Id = id;
            Engine = engine;
        }

        public virtual void Start()
        {
            Console.WriteLine("Vehicle started!");
            isOn = true;
        }
        public virtual void Start(int level)
        {
            if (level == 0)
            {
                Console.WriteLine("Vehicle started!");
                isOn = true;   
            }

            throw new Exception("You cannot drive");
        }
        public virtual void Stop()
        {
            Console.WriteLine("Vehicle stopped!");
            isOn = false;
        }
    }