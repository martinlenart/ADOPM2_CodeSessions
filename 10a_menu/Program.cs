using Helpers;
namespace _10a_menu;

class Program
{
    public enum enSeason { Winter, Spring, Summer, Fall }
    public class csAppData
    {
        public csNecklace Necklace { get; set; }
        public csPearl Pearl { get; set; }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("10a_menu");

        //This instance will be valid for all menu iterations in the do..while loop
        //could also have been stataic globals in Program class, but his is better
        var AppData = new csAppData
        {
            Necklace = new csNecklace("Pretty necklace"),
            Pearl = new csPearl()
        };
            
        do
        {
            ShowMenu();

            int _menuSel;
            if (!GetMenuSelection(out _menuSel))
            {
                break;
            }

            //Only if menu item selected do we get here
            ProcessMenuSelection(_menuSel, AppData);

            //Clear the console output before menu presentations 
            Clear();

        } while (true);

        Console.WriteLine("Bye, thank you for playing!");
    }

    private static void Clear()
    {
        Console.WriteLine("Press a key to get back to meny");
        Console.ReadKey();
        Console.Clear();
    }

    private static void ProcessMenuSelection(int _menuSel, csAppData _appData)
    {
        var rnd = new csSeedGenerator();

        switch (_menuSel)
        {
            case 1:

                //Create a specific Pearl
                int _size = default;
                enPearlColor _color = default;
                enPearlShape _shape = default;
                enPearlType _type = default;
                if (csConsoleInput.TryReadInt32("Enter pearl size", 5, 11, out _size) &&
                    csConsoleInput.TryReadEnum<enPearlColor>("Enter pearl color", out _color) &&
                    csConsoleInput.TryReadEnum<enPearlShape>("Enter pearl shape", out _shape) &&
                    csConsoleInput.TryReadEnum<enPearlType>("Enter pearl type", out _type))
                {
                    _appData.Pearl = new csPearl(_size, _color, _shape, _type);
                    Console.WriteLine(_appData.Pearl);
                }
                break;

            case 2:

                //Create a random Pearl
                _appData.Pearl = new csPearl(rnd);
                Console.WriteLine(_appData.Pearl);

                break;

            case 3:

                //Add the created Pearl to a Necklace
                _appData.Necklace.ListOfPearls.Add(_appData.Pearl);
                Console.WriteLine(_appData.Necklace);

                break;
            case 4:

                Console.WriteLine(_appData.Necklace);
                break;

        }
    }

    private static bool GetMenuSelection(out int menuSelection)
    {
        bool _continue;
        if (!csConsoleInput.TryReadInt32("Enter your selection", 1, 4, out menuSelection))
        {
            _continue = false;
        }
        else
        {
            _continue = true;
        }

        return _continue;
    }

    private static void ShowMenu()
    {
        Console.WriteLine("\n\nMenu:");
        Console.WriteLine("1 - Create a specific Pearl");
        Console.WriteLine("2 - Create a random Pearl");
        Console.WriteLine("3 - Add a the Pearl to a Necklace");
        Console.WriteLine("4 - Present the Necklace");

        Console.WriteLine("Q - Quit program");
    }
}

