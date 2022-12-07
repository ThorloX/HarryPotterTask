using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace HarryPotterOppgave;


public class Character
{
    public string Name { get; private set; }

    public string House { get; private set; }

    public List<Spell> Spells { get; set; }

    public List<Item> Inventory { get; set; }

    public Owl? PetOwl { get; set; } 
    // function purchaseOwl(Owl OwlToBuy), set petOwl Value from Paramater.

    public List<Mail> MailBox { get; set; }




    public Character(string name, string house, List<Spell> spells)
    {
        Name = name;
        House = house;
        Spells = spells;
        Inventory = new List<Item>();
        MailBox = new List<Mail>();
        

    }


    public void Introduction()
    {
        Console.WriteLine($"Hello I am {Name}, and I'm a {House}! \nI know a few spells!\n");
        
        ListSpells();
       
        
        ListInventory();
        
    }

    // Lagg 2 metoder som printer ut Lister.

    public void ListSpells()
    {
        Console.WriteLine("Spells:");
        
        foreach (var spell in Spells)
        {
            Console.WriteLine(spell.Name);
            
        }
     
        Console.WriteLine("\n");
    }

    public void ListInventory()
    {
        Console.WriteLine("Inventory:");
        

        var inventoryHasItems = Inventory.Count > 0;
        
        
            if (inventoryHasItems)
            {
                foreach (var item in Inventory)
                {
                Console.WriteLine($"\n {item.Name}  ");
                }
              
            Console.WriteLine("\n");
            }
            else 
            {
                Console.WriteLine("It's empty bruv, go buy yourself some shit with whatever you got;)");
            Console.WriteLine("\n");
        }
        

        
    }

    public void PurchaseOwl(Owl owlToBuy)
    {
        PetOwl = owlToBuy;
        
    }

    public void Purchase(Item itemToBuy)
    {
        Inventory.Add(itemToBuy);
    }

    public void DoMagic()
    {
        Console.WriteLine("These are the spells you know:");
        foreach (var spell in Spells)
        {
            Console.WriteLine($"{spell.Name}");
           
        }

        Console.WriteLine("\nWhich spell would you like to cast?\n");
        var useSpell = Console.ReadLine();
        Console.Clear();
        var saidSpell = Spells.FirstOrDefault(x => x.Name == useSpell);
        if (saidSpell != null)
        {
            Console.WriteLine(
                $"You flick and swish with your wand,\n and cast {saidSpell.Name}! and it {saidSpell.Description}!");
         

        }

    }

    public void WriteMail(List<Character> characters)
    {
        var message = Console.ReadLine();
        if (message == null) return;
        var letter = new Mail(message, Name);
        
        GiveMailToOwl(characters, letter);
        Console.WriteLine($"You wrote:\n {message}\n ");

    }

    private void GiveMailToOwl(List<Character> characters ,Mail message)
    {
        var recipient = SelectRecipient(characters);
        PetOwl?.GetLetterAndRecipient(message, recipient);
    }

    
    public Character SelectRecipient(List<Character> characters)
    {
        foreach (var character in characters)
        {
            Console.WriteLine($"{character.Name}");
        }
    
        var answer = Console.ReadLine();
        var recipient = characters.FirstOrDefault(x => x.Name == answer);
        return recipient;

        //  Change the function so it can retrieve recipient name from user. Search user list for potential recipients.
    }
    public void DeliverMail(Mail message)
    {
        MailBox.Add(message);
    }

    public void ReadMail()
    {
        foreach (var mail in MailBox)
        {
            Console.WriteLine($"Message: {mail.Message} From: {mail.From}");
        }
    }

    // Character writes a letter, => hands it to the Owl. =>  Tell the owl Which character gets the Letter => owl sends letter to Character's Inventory.
    // Objekter : Letter
    // Functions: (Character) writeLetter, (Character) SelectRecipient, (Owl) DeliverLetter, (Character) retrieveLetter
    // 
}
