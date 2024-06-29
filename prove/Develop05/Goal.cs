
public class Goal
{
    protected string _goalType;
    protected int _pointVal;
    protected string _title;
    protected string _description;
    protected bool _active;

// the start to the AddGoal function for the rest of the children classes
    public virtual void AddGoal()
    {

        Console.Write("Provide a goal Name: ");
        _title = Console.ReadLine();

        Console.Write("Provide a description: ");
        _description = Console.ReadLine();

        Console.Write("How many points is this Goal worth:");
        string i = Console.ReadLine();
        _pointVal = int.Parse(i);
        


    }
// a display function that displays the function along with the show all function
    public virtual void Display(bool showActive)
    {
        string tf = "x";
        if (_active)
        {
            tf = " ";
        }
        if (showActive)
        {
            Console.Write($"[{tf}]");
        }
        Console.Write($"{_title} ({_description})");
    }
// blank function to be used be each class based of what it is
    public virtual int AccomplishGoal()
    {
        return 0;
    }
// Save all of the goals 
    public void Save(List<Goal> goals)
    {
        string saveData = "";

        // Loop through each goal in the list
        foreach (var goal in goals)
        {
            // Construct a string representation of the goal object
                
            saveData += goal.ValueToSave();
            // Add a comma separator for each goal except the last one
            if (goal != goals.Last())
            {
                saveData += "\n";
            }
        }

        // Write the string representation to "save.txt" file
        File.WriteAllText("save.txt", saveData);
    }

// Gemini helped me write this function
// Loads the txt file save.txt
    public void Load(List<Goal> _goals)
{
    try
    {
        // Read all lines from the "save.txt" file
        string[] lines = File.ReadAllLines("save.txt");

        // Clear the existing goals list before loading new ones
        _goals.Clear();

        // Loop through each line in the file
        foreach (string line in lines)
        {
            // Split the line into individual components (type, point value, etc.)
            string[] parts = line.Split(',');

            // Check if there are enough parts for a valid goal
            if (parts.Length < 5)
            {
                Console.WriteLine($"Error: Invalid line format in save.txt: {line}");
                continue; // Skip to the next line if format is invalid
            }

            // Extract properties based on the first element (goal type)
            string goalType = parts[0];
            int pointVal = int.Parse(parts[1]);
            string title = parts[2];
            string description = parts[3];
            bool isActive = bool.Parse(parts[4]);

            // Create a new goal object based on the type
            Goal goal;
            switch (goalType)
            {
                case "Simple":
                    goal = new Simple(pointVal, title, description, isActive);
                    break;
                case "Eternal":
                    goal = new Eternal(pointVal, title, description, isActive);
                    break;
                case "Checklist":
                int secPoints = int.Parse(parts[5]);
                int totalCount = int.Parse(parts[6]);
                int counter = int.Parse(parts[7]);  // Parse the additional counter property
                goal = new Checklist(pointVal, title, description, isActive, secPoints, totalCount);
                ((Checklist)goal).Counter = counter;  // Set the counter property using casting
                break;
                default:
                    Console.WriteLine($"Error: Unknown goal type: {goalType}");
                    continue; // Skip to the next line if type is unknown
            }

            // Add the created goal object to the list
            _goals.Add(goal);
        }

        Console.WriteLine("Goals loaded successfully from save.txt.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error loading goals: {ex.Message}");
    }
}
// returns a function for the Save function
    public virtual string ValueToSave()
    {
        return $"{_goalType},{_pointVal},{_title},{_description},{_active}";
    }
//Shows all of the goals in the main list and weather or not to show it checked off or not
    public void ShowAll(List<Goal> goals, bool showActive)
    {
        int number = 1;
        Console.WriteLine("The Goals are: ");
        foreach(var goal in goals)
        {
            if (goal is Eternal)
            {
                Console.Write($"{number}.");
                goal.Display(showActive);
            }
            else if (goal is Simple)
            {
                Console.Write($"{number}.");
                goal.Display(showActive);
            }
            else if (goal is Checklist)
            {
                Console.Write($"{number}.");
                goal.Display(showActive);
            }
            Console.WriteLine("\n");
            number ++;
        }
    }

    
}