using System.Security.Cryptography.X509Certificates;

namespace HarryPotterOppgave;

public class Galtvort
{

    public List<Character> Characters { get; set; }

    public MagicShop MagicShop { get; set; }

    public Character ActiveCharacter { get; set; }
    public Galtvort()
    {

        Characters = new List<Character>
        { 
      new Character("Harry Potter", 
                    "Gryffindor",
                    new List<Spell>{new Spell(
                    "Hokus Pokus",
                    "shoots firework! Amaaaazing"),
          new Spell("Vingardium Leviosa",
                    "Makes a feather fly! what else can you make fly..?") }),
     
      new Character("Ron Weasley", 
                    "Gryffindor",
                    new List<Spell>{new Spell(
                    "Hokus Flokus",
                    "shoots wonky firework, almost works, but not quite as expected..")})
        };
        


        selectCharacter();

        MagicShop = new MagicShop(ActiveCharacter);

        HandleMenuChoice();

    }
    public void selectCharacter()
    {
        var characterHandler = new CharacterHandler(Characters);
        ActiveCharacter = characterHandler.SelectedCharacter();

        Console.WriteLine($"{ActiveCharacter.Name} is selected.");
    }

    
    public void IntroMenu()
    {
        
        Console.WriteLine("_____________________________");
        Console.WriteLine("\nMenu: " +
                          "\n1: Introduction " +
                          "\n2: Open Inventory" +
                          "\n3: Enter Shop" +
                          "\n4: Cast a Spell " +
                          "\n5: Send Mail " +
                          "\n6: Read Mail " +
                          "\n7: Change Character " +
                          "\n8: End The Game ");
        Console.WriteLine("_____________________________");
    }


   public void HandleMenuChoice()
   {
       while (true)
       {

           IntroMenu();

           var menu = Console.ReadLine();
           switch (menu)

           {
               case "1":
                   Console.Clear();
                   ActiveCharacter.Introduction();
                   break;

               case "2":
                   Console.Clear();
                   ActiveCharacter.ListInventory();
                   break;

               case "3":
                   Console.Clear();
                   MagicShop.EnterShop(ActiveCharacter); // Make character if you implement Multiple characters (characterHandler?)
                   break;

               case "4":
                   Console.Clear();
                   ActiveCharacter.DoMagic();
                   break;

               case "5":
                   ActiveCharacter.WriteMail(Characters);
                       
                   break;

                case "6":
                    ActiveCharacter.ReadMail();
                    break;

                case "7":
                    selectCharacter();
                    break;

                case "8":
                   Console.Clear();
                   Console.WriteLine("Peace out home dawg.");
                   Environment.Exit(0);
                   break;

               default:
                   Console.WriteLine("Well something happened..");

                   break;
           }
       }
    }
}