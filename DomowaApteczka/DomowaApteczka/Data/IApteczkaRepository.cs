using DomowaApteczka.Models;

namespace DomowaApteczka.Data;

public interface IApteczkaRepository
{
    IEnumerable<Lek> PobierzWszystkie();
    void Dodaj(Lek lek);
    void Usun (Lek lek);
}