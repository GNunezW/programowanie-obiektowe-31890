namespace DomowaApteczka.Models;

public abstract class Lek
{
    public string Nazwa { get; protected set; }
    public DateTime DataWaznosci { get; protected set; }

    protected Lek(string nazwa, DateTime dataWaznosci)
    {
        Nazwa = nazwa;
        DataWaznosci = dataWaznosci;
    }

    public bool CzyPrzeterminowany()
    {
        return DataWaznosci < DateTime.Now;
    }

    public abstract string Typ();
    public int Id { get; internal set; }

    public virtual string Info()
    {
        return $"{Nazwa} | Ważny do: {DataWaznosci:d}";
    }
}