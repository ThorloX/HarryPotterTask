using System.Diagnostics;

namespace HarryPotterOppgave;

public class Owl : Pet
{
    
    public Owl(string name, string description, string type) : base(name, description, type)
    {
        
    }
   public void GetLetterAndRecipient(Mail message, Character recipient)
    {
        OwlDelivery(message, recipient);
    }

   public static void OwlDelivery(Mail message, Character recipient)
    {
        recipient.DeliverMail(message);

    }

  
}