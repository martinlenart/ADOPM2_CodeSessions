using Helpers;

namespace _04_record_vs_class;

public enum enPearlColor { Black, White, Pink }
public enum enPearlShape { Round, DropShaped }
public enum enPearlType { FreshWater, SaltWater }

public class csPearl
{
    public int Size { get; init; }
    public enPearlColor Color { get; init; }
    public enPearlShape Shape { get; init; }
    public enPearlType Type { get; init; }

    public override string ToString() => $"{Size}mm {Color} {Shape} {Type} pearl.";

    public csPearl() { }
    public csPearl(csSeedGenerator _seeder)
    {
        Size = _seeder.Next(5,25);
        Color = _seeder.FromEnum<enPearlColor>();
        Shape = _seeder.FromEnum<enPearlShape>();
        Type = _seeder.FromEnum<enPearlType>();
    }
    public csPearl(int _size, enPearlColor _color, enPearlShape _shape, enPearlType _type)
    {
        Size = _size;
        Color = _color;
        Shape = _shape;
        Type = _type;
    }
    public csPearl(csPearl org)
    {
        Size = org.Size;
        Color = org.Color;
        Shape = org.Shape;
        Type = org.Type;
    }
}

public record rePearl (int Size, enPearlColor Color, enPearlShape Shape, enPearlType Type)
{
    //Your own constructor, must call this(record properties...)
    public rePearl(csSeedGenerator _seeder) : this (
   
        _seeder.Next(5, 25),
        _seeder.FromEnum<enPearlColor>(),
        _seeder.FromEnum<enPearlShape>(),
        _seeder.FromEnum<enPearlType>())
    { }
}


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("04_record_vs_clas");

        var rnd = new csSeedGenerator();
        var p = new csPearl(rnd);

        Console.WriteLine(p);

        var pc = new csPearl(p) { Size = 5 };

        Console.WriteLine(pc);

        Console.WriteLine("\n\n");
        var pr = new rePearl(25,enPearlColor.White, enPearlShape.DropShaped, enPearlType.FreshWater);
        Console.WriteLine(pr);

        var pr_c = pr with { Size = 5 };
        Console.WriteLine(pr_c);

        var rnd_p = new rePearl(rnd);
        Console.WriteLine(rnd_p);
    }
}

