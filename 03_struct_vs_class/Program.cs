using Helpers;
namespace _03_struct_vs_class;


public enum enGrapeType { Reissling, Tempranillo, Chardonay, Shiraz, CabernetSavignoin, Syrah }
public enum enWineType { Red, White, Rose }
public enum enCountry { Germany, France, Spain }

public struct stWine
{
    public string Name { get; }

    public enCountry Country { get; }
    public enWineType WineType { get; }
    public enGrapeType GrapeType { get; }

    public decimal Price { get; set; }

    public override string ToString()
    {
        var s = $"Wine {Name} from {Country} is {WineType} and made from grapes {GrapeType}. The price is {Price:N2} Sek";
        return s;
    }

    public stWine() { }
    public stWine(csSeedGenerator _seeder)
    {
        string[] _names = "Chattaux de bueff, Chattaux de paraply, PutiPuti".Split(", ");
        Name = _names[_seeder.Next(0, _names.Length)];

        GrapeType = _seeder.FromEnum<enGrapeType>();
        WineType = _seeder.FromEnum<enWineType>();
        Country = _seeder.FromEnum<enCountry>();
        Price = _seeder.Next(50, 150);
    }
    public stWine(string _name, enCountry _country, enGrapeType _grapetype,
        enWineType _wineType, decimal _price)
    {
        Name = _name;
        GrapeType = _grapetype;
        WineType = _wineType;
        Country = _country;
        Price = _price;
    }
    public stWine(stWine org)
    {
        Name = org.Name;
        GrapeType = org.GrapeType;
        WineType = org.WineType;
        Country = org.Country;
        Price = org.Price;
    }
}

public class csWine
{
    public string Name { get; }

    public enCountry Country { get; }
    public enWineType WineType { get; }
    public enGrapeType GrapeType { get; }

    public decimal Price { get; set; }

    #region operator overloading
    public static bool operator ==(csWine w1, csWine w2)
    {
        bool res = 
            (w1.Name, w1.Country, w1.GrapeType, w1.WineType) ==
            (w2.Name, w2.Country, w2.GrapeType, w2.WineType);
        return res;
    }

    public static bool operator !=(csWine w1, csWine w2) =>
    (w1.Name, w1.Country, w1.GrapeType, w1.WineType) !=
    (w2.Name, w2.Country, w2.GrapeType, w2.WineType);

    #endregion

    public override string ToString()
    {
        var s = $"Wine {Name} from {Country} is {WineType} and made from grapes {GrapeType}. The price is {Price:N2} Sek";
        return s;
    }

    public csWine() { }
    public csWine(csSeedGenerator _seeder)
    {
        string[] _names = "Chattaux de bueff, Chattaux de paraply, PutiPuti".Split(", ");
        Name = _names[_seeder.Next(0, _names.Length)];

        GrapeType = _seeder.FromEnum<enGrapeType>();
        WineType = _seeder.FromEnum<enWineType>();
        Country = _seeder.FromEnum<enCountry>();
        Price = _seeder.Next(50, 150);
    }
    public csWine(string _name, enCountry _country, enGrapeType _grapetype,
        enWineType _wineType, decimal _price)
    {
        Name = _name;
        GrapeType = _grapetype;
        WineType = _wineType;
        Country = _country;
        Price = _price;
    }
    public csWine(csWine org)
    {
        Name = org.Name;
        GrapeType = org.GrapeType;
        WineType = org.WineType;
        Country = org.Country;
        Price = org.Price;
    }
}


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("03_struct_vs_class");

        var st_w1 = new stWine("Nice evening", enCountry.Spain,
            enGrapeType.Tempranillo, enWineType.Red, 80M);

        var st_w2 = new stWine("Nice evening", enCountry.Spain,
            enGrapeType.Tempranillo, enWineType.Red, 80M);

        Console.WriteLine($"struct Equals: {st_w1.Equals(st_w2)}");

        var cs_w1 = new csWine("Nice evening", enCountry.Spain,
            enGrapeType.Tempranillo, enWineType.Red, 80M);

        var cs_w2 = new csWine("Nice evening", enCountry.Spain,
            enGrapeType.Tempranillo, enWineType.Red, 80M);

        Console.WriteLine($"class Equals: {cs_w1.Equals(cs_w2)}");

        Console.WriteLine("\n");
        var cs_w3 = cs_w1;
        Console.WriteLine($"class Equals: {cs_w1.Equals(cs_w3)}");
        Console.WriteLine($"class Equals: {cs_w1 == cs_w3}");

        Console.WriteLine($"wine csw1: {cs_w1}");
        Console.WriteLine($"wine csw3: {cs_w3}");
        if (cs_w1 == cs_w3)
        {
            Console.WriteLine("Both wines are equal");
        }

        Console.WriteLine("\n");
        var cs_w4 = new csWine(cs_w1);

        cs_w4.Price = 30M;
        Console.WriteLine($"class Equals: {cs_w1.Equals(cs_w4)}");
        Console.WriteLine($"class Equals: {cs_w1 == cs_w4}");

        Console.WriteLine($"wine csw1: {cs_w1}");
        Console.WriteLine($"wine csw4: {cs_w4}");
        if (cs_w1 == cs_w4)
        {
            Console.WriteLine("Both wines are equal");
        }
        else
        {
            Console.WriteLine("Both wines are NOT equal");
        }

    }
}

