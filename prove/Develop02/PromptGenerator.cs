using System.Security.Cryptography.X509Certificates;

class PromptGenerator
{
    // All five of my prompts added right into the list at the beginning
    public List<string> _sfPrompts = ["What is something different that happened today?", "What is something that you would change that happened today?", "What did you eat today?", "Where did you go today that lead to something new?", "Who is someone that you talked to today and what did you talk about?"];

    public string sfGenerate()
    {
        string s = "s";

        Random random = new Random();
        int sfRandomNum = random.Next(0,5);
        s = _sfPrompts[sfRandomNum];

        return s;
    }
}