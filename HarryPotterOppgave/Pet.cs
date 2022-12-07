namespace HarryPotterOppgave;

public class Pet : Item
{
    
    public string Type { get; set; }

    public Pet(string name, string description, string type): base(name, description)
    {
        
        Type = type;
    }


}