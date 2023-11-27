using System;
namespace _09_inheritance2
{
	public class csAnimal
	{
		public virtual string Noise() => "Clonk";
        public virtual string Name { get; }
        public int Age = 0;

        public csAnimal()
        {
            Name = "Max the animal";
        }
	}
	public class csDog : csAnimal
	{
        public override string Noise() => "Voff";
        public override string Name { get; }
        public new int Age = 17;

        private string _hate = "Cats";
        public string IHate() => $"I hate {_hate}";
        public csDog():base()
        {
            Name = "Cooper the Dog";
        }
        public csDog(string hatedAnimal)
        {
            _hate = hatedAnimal;
        }

    }
    public class csCat : csAnimal
    {
        public override string Noise() => "Meow";
        public override string Name { get; }
        public csCat()
        {
            Name = "Scobby the Cat";
        }
    }
    public class csLabrador : csDog
    {
        public override string Noise() => "Voff Voff Rauw!";
        public new int Age = 10;
        public override string Name { get; }
        public string IAm() => "I the best";
        public string myAgeIs()
        {
            return $"I am {this.Age}, my faher is {base.Age}";
        }
        public csLabrador() : base("Squirrels")
        {
            Name = "Aladin the Labrador";
        }
    }
}

