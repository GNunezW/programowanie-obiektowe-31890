using DomowaApteczka.Models;
using Npgsql;

namespace DomowaApteczka.Data;

public class ApteczkaRepositoryDb : IApteczkaRepository
{
    private readonly string _connString;

    public ApteczkaRepositoryDb(string connString)
    {
        _connString = connString;
    }

    public IEnumerable<Lek> PobierzWszystkie()
    {
        var leki = new List<Lek>();

        using var conn = new NpgsqlConnection(_connString);
        conn.Open();

        using var cmd = new NpgsqlCommand("SELECT id, nazwa, data_waznosci, typ FROM leki", conn);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string nazwa = reader.GetString(1);
            DateTime data = reader.GetDateTime(2);
            string typ = reader.GetString(3);

            Lek lek = typ == "Na recepte"
                ? new LekNaRecepte(nazwa, data)
                : new LekBezRecepty(nazwa, data);

            lek.Id = id;
            leki.Add(lek);
        }

        return leki;
    }

    public void Dodaj(Lek lek)
    {
        using var conn = new NpgsqlConnection(_connString);
        conn.Open();

        using var cmd = new NpgsqlCommand(
            "INSERT INTO leki(nazwa, data_waznosci, typ) VALUES (@nazwa, @data, @typ) RETURNING id",
            conn);

        cmd.Parameters.AddWithValue("nazwa", lek.Nazwa);
        cmd.Parameters.AddWithValue("data", lek.DataWaznosci);
        cmd.Parameters.AddWithValue("typ", lek.Typ());

        lek.Id = (int)cmd.ExecuteScalar(); 
    }

    public void Usun(Lek lek)
    {
        using var conn = new NpgsqlConnection(_connString);
        conn.Open();

        using var cmd = new NpgsqlCommand("DELETE FROM leki WHERE id = @id", conn);
        cmd.Parameters.AddWithValue("id", lek.Id);

        cmd.ExecuteNonQuery();
    }
}