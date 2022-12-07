namespace HarryPotterOppgave;

public class Mail
{

    public string Message { get; set; }
    public string From { get; set; }

    public Mail(string message, string from)
    {
        Message = message;
        From = from;
    }


}