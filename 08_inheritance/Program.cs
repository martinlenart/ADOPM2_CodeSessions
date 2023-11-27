using Helpers;
namespace _08_inheritance;

public class csChef
{
    public virtual string Name { get; set; } = "Boring";
    public int Age { get; protected set; } = 0;

    public string Hello => $"Hello";
    public string FavoriteDish { get; set; } =  "nothing";

    public override string ToString() => $"{Hello}, I am {Name}. I like {FavoriteDish}";

}

public class csFrenchChef : csChef
{
    public override string Name { get; set; } = "Boring French chef";

    public List<csWine> WineList { get; set; } = new List<csWine>();

    public List<csWine> MyFavoriteWinesEver()
    {
        var rnd = new csSeedGenerator();
        var _winefav = new List<csWine>();
        for (int i = 0; i < 3; i++)
        {
            _winefav.Add(new csWine(rnd));
        }
        return _winefav;
    }

    public override string ToString()
    {
        string sRet = $"\nHi Im {this.Name}:";
        foreach (var item in WineList)
        {
            sRet += $"\n{item}";
        }
        return sRet;
    }

    public csFrenchChef()
    {
        var rnd = new csSeedGenerator();
        for (int i = 0; i < 10; i++)
        {
            WineList.Add(new csWine(rnd));
        }
    }
}

public class csGermanChef : csChef
{
    public override string Name { get; set; } = "Boring German chef";

    public string PetName { get; set; } = "Max";
    public override string ToString() => $"\nHi Im {this.Name}. \nI am {Age}yrs old\nI have a pet called {PetName}";
    public csGermanChef()
    {
        Age = 40;
    }
}

public class csItalianChef : csChef
{
    public List<string> PastaSauses = new List<string>();

    public override string ToString()
    {
        string sRet = $"\n{base.ToString()}:";
        foreach (var item in PastaSauses)
        {
            sRet += $"\n{item}";
        }
        return sRet;
    }

    public csItalianChef()
    {
        var rnd = new csSeedGenerator();
        var _sauses = "Peppes tomato, Mauro olivetties, Heinz, Onion&Olives, Love in a jar".Split(", ");
        for (int i = 0; i < 2; i++)
        {
            PastaSauses.Add(_sauses[rnd.Next(0, _sauses.Length)]);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("08_inheritance!");

        Console.WriteLine("csChef");
        var chef1 = new csChef();
        Console.WriteLine(chef1);

        Console.WriteLine();
        Console.WriteLine("csFrenchChef");
        var fc = new csFrenchChef() { FavoriteDish = "Escargot" };
        fc.Name = "Jean-Pierre";
        Console.WriteLine(fc);

        Console.WriteLine("Favorite wine");
        var w1 = fc.MyFavoriteWinesEver();
        Console.WriteLine(w1[0]);

        Console.WriteLine();
        Console.WriteLine("csGermanChef");
        var gc = new csGermanChef() { FavoriteDish = "Wurst" };
        gc.Name = "Heinz";
        Console.WriteLine(gc.Age);
  
        Console.WriteLine(gc);

        Console.WriteLine();
        Console.WriteLine("csItalianChef");
        var ic = new csItalianChef() { Name = "Mauro", FavoriteDish = "Spaggeti"};
        Console.WriteLine(ic);

        Console.WriteLine();
        Console.WriteLine();
        List<csChef> chefs_conference  = new List<csChef>();
        chefs_conference.Add(fc);
        chefs_conference.Add(gc);
        chefs_conference.Add(ic);
        foreach (var item in chefs_conference)
        {
            Console.WriteLine(item.Name);
            if (item is csFrenchChef c)
            {
                var b = c.MyFavoriteWinesEver();
                Console.WriteLine(b[0]);
            }
        }


        Console.WriteLine();
        Console.WriteLine();
        csChef chef2 = fc;
        Console.WriteLine(chef2.Name);


        csFrenchChef fc2 = (csFrenchChef) chef2;
        Console.WriteLine(fc2.Name);

        csChef chef3 = new csChef();
        //csFrenchChef fc3 = chef3 as csFrenchChef;
        if (chef3 is csFrenchChef fc3)
        {
            Console.WriteLine("All good man");
        }
    }
}

