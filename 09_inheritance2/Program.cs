namespace _09_inheritance2;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("09_inheritance2");
        Console.WriteLine(new csAnimal().Noise());
        Console.WriteLine(new csDog().Noise());
        Console.WriteLine(new csCat().Noise());
        Console.WriteLine(new csLabrador().Noise());

        
        Console.WriteLine("\nAnimals array");
        csAnimal[] animals = new csAnimal[4];
        animals[0] = new csAnimal();
        animals[1] = new csDog();
        animals[2] = new csCat();
        animals[3] = new csLabrador();
        
        OtherTeamWritingNoise(animals);
        

        Console.ReadKey();
    }

    private static void OtherTeamWritingNoise(csAnimal[] animals)
    {
        foreach (var animal in animals)
        {
            Console.WriteLine(animal.Noise());
            Console.WriteLine(animal.Name);

            //cast, as, is
            //csDog d = (csDog)animal;  //cast - crash if not working

            csDog d = animal as csDog;
            if (d != null)
            {
                Console.WriteLine(d.IHate());
            }

            if (animal is csLabrador d1)
            {
                Console.WriteLine(d1.IAm());
                Console.WriteLine(d1.myAgeIs());
            }
        }
    }
}

