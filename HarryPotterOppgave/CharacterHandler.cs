namespace HarryPotterOppgave;

public class CharacterHandler
{

    
    public List<Character> Characters { get; set; }


    public CharacterHandler(List<Character> characters)
    {
        Characters = characters;
    }

    public void PrintCharacters()
    {
        foreach (var character in Characters)
        {
            Console.WriteLine($"Name: {character.Name}");
        }
    }
    public Character? SelectedCharacter()
    {
        PrintCharacters();
        Console.WriteLine("Select your Character: ");
        var nameInput = Console.ReadLine();
       var selectedCharacter = Characters.FirstOrDefault(x => x.Name == nameInput);

       return selectedCharacter;

    }



 
}