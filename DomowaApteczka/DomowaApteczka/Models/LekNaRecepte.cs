namespace DomowaApteczka.Models;

public class LekNaRecepte :Lek
{
    public LekNaRecepte(string nazwa, DateTime dataWaznosci)
        : base(nazwa, dataWaznosci)
    {
    }

    public override string Typ()
    {
        return "Na recepte";
    }
}