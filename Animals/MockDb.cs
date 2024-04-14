namespace Animals;

public class Zwierze
{
    public int Id{ get; set; }
    public string imie{ get; set; }
    public string kategoria{ get; set; }
    public int masa{ get; set; }
    public string kolorSiersci{ get; set; }
}

public class Wizyty
{
    public DateTime dataWizyty{ get; set; }
    public Zwierze zwierze{ get; set; }
    public string opisWizyty{ get; set; }
    public double cenaWizyty{ get; set; }

}
public interface IMockDb
{
    public ICollection<Zwierze> GetAll();
    public Zwierze? GetById(int id);
    public void Add(Zwierze zwierz);
    public void Remove(Zwierze existingZwierze);
    List<Wizyty>? GetWizyty(Zwierze zwierze);
    public void AddWizyta(Wizyty wizyty);

}
public class MockDb : IMockDb
{
    public MockDb()
    {
         
        _zwierze = new List<Zwierze>
        {
            new Zwierze()
            {
                Id = 1,
                imie = "Waclaw",
                kategoria = "borsuk",
                masa = 200,
                kolorSiersci = "złoty"
            }, new Zwierze()
            {
                Id = 2,
                imie = "Tofik",
                kategoria = "pies",
                masa = 5,
                kolorSiersci = "brazowy"
            }
        };
       _wizyty = new List<Wizyty>();
    }

    private ICollection<Zwierze> _zwierze;
    private ICollection<Wizyty> _wizyty;
    

    public ICollection<Zwierze> GetAll()
    
    {
        throw new NotImplementedException();
    }

    public Zwierze? GetById(int id)
    {
        return _zwierze.FirstOrDefault(zwierze => zwierze.Id == id);
    }

    public void Add(Zwierze zwierz)
    {
       _zwierze.Add(zwierz);
    }

    public void Remove(Zwierze zwierz)
    {
        _zwierze.Remove(zwierz);
    }

    public List<Wizyty>? GetWizyty(Zwierze zwierze)
    {
        return _wizyty.Where(w => w.zwierze == zwierze).ToList();
    }

    public void AddWizyta(Wizyty wizyty)
    {
       _wizyty.Add(wizyty);
    }
}