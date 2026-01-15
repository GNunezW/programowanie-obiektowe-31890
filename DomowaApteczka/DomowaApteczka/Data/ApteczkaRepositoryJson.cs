using DomowaApteczka.Models;
using System.Text.Json;

namespace DomowaApteczka.Data;

public class ApteczkaRepositoryJson : IApteczkaRepository
{
    private const string FileName = "apteczka.json";
    private List<Lek> _leki = new();

    public IEnumerable<Lek> PobierzWszystkie()
        => _leki;
    
    public void Dodaj(Lek lek)
    {
        _leki.Add(lek);
        Zapisz();
    }

    private void Zapisz()
    {
        var json = JsonSerializer.Serialize(_leki, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(FileName, json);
    }
}