using System.ComponentModel;

namespace HarryPotterOppgave;

public class Spell
{
    public string Name { get; private set; }
    public string Description { get; private set; }


public Spell(string name, string description)
    {
        Name = name;
        Description = description;
    }

    

}

