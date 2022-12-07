using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using Console = System.Console;

namespace HarryPotterOppgave;

public class MagicShop
{

    public List<Item> Wands { get; set; }
    public List<Item> Pets { get; set; }
    public Character Character { get; set; }
    public List<Item> Owls { get; set; }


    public MagicShop(Character customer)
    {
        Character = customer;
        Wands = new List<Item>
        {
            new Wand("Phoenix Wand", "made from real Phoenix, don't call peta"),
            new Wand("Unicorn Wand", "you know it. made from real Unicorns."),
            new Wand("Wooden Wand", "For all your common peasants, swish and flick.")

        };
        Pets = new List<Item>
        {
            new Pet("Remy", "This is remi the mouse, he can cook on the side", "Rat"),
            new Pet("Professor McGonagall", "Your own Personal teacher.. I mean cat.. ", "Cat"),

        };
        Owls = new List<Item>
        {
            new Owl("Hoo-Dini", "Its a magical owl! it can send letters to your friends and family", "Owl")
        };

    }

    public void ListPets()
    {

        foreach (var pet in Pets)
        {
            Console.WriteLine($"{pet.Name}");
        }
    }
    public void ListOwls()
    {

        foreach (var owl in Owls)
        {
            Console.WriteLine($"{owl.Name}");
        }
    }


    public void ListWands()
    {
        foreach (var wand in Wands)
        {
            Console.WriteLine($"{wand.Name}");
        }

    }


    public void SellItems(List<Item> itemsToSell, string itemName, bool isOwl)
    {
        Console.WriteLine("_____________________________________");
        Console.WriteLine($"Which {itemName} would you like to purchase?");


        var answer = Console.ReadLine();
        var chosenItem = itemsToSell.FirstOrDefault(x => x.Name == answer);

        if (chosenItem == null)
            return;
        if (isOwl)
        {
            Character.PurchaseOwl(chosenItem as Owl);
            Console.WriteLine($"You've successfully purchased {answer} for 'Favors' ");
            return;
        }
        Character.Purchase(chosenItem);
        Console.WriteLine($"You've successfully purchased {answer} for 'Favors' ");

    }



    public void EnterShop(Character customer)
    {


        bool shopping = true;
        while (shopping)
        {
            Console.WriteLine(
                "Welcome to Ollivander's \nWe have Wands and Personal Pets if interested. \nWould you like to buy anything?");

            Console.WriteLine("Menu: \n1: Pets \n2: Wands \n3: Owl \n4:Exit Shop");
            var inStore = Console.ReadLine();

            switch (inStore)
            {
                case "1":
                    Console.Clear();
                    ListPets();
                    SellItems(Pets, "Pets", false);

                    break;

                case "2":
                    Console.Clear();
                    ListWands();
                    SellItems(Wands, "Wands", false);
                    break;

                case "3":
                    Console.Clear();
                    ListOwls();
                    SellItems(Owls, "Owls", true);
                    break;

                case "4":
                    Console.Clear();
                    shopping = false;
                    break;


                default:
                    Console.WriteLine("forbanna smørbokk.... håper det funker neste gang");
                    break;
                
            }
        }
    }
    




}