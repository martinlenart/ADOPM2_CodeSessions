using Helpers;

namespace _06_embedded_list;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("06_embedded_list");

        var rnd = new csSeedGenerator();

        var p1 = new csPearl();
        Console.WriteLine(p1);

        var p2 = new csPearl(rnd);
        Console.WriteLine(p2);

        var pr = new rePearl(rnd);
        Console.WriteLine(pr);

        var pr_copy = pr with { Color = enPearlColor.Pink };
        Console.WriteLine(pr_copy);
 
        var n = new csNecklace(3, "African with Pearls as a class");
        Console.WriteLine(n);

        var n2 = new csNecklace("Another halsband", p1, p2);
        Console.WriteLine(n2);
       
        var n1 = new csNecklace1(15, "European with Pearls as a record");
        Console.WriteLine(n1);
    }
}

