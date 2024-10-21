public class GoalManager
{
    private List<Goal> goals = new List<Goal>();

    public void AddGoal()
    {
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter due date (MM/DD/YYYY): ");
        DateTime dueDate;

        while (!DateTime.TryParse(Console.ReadLine(), out dueDate))
        {
            Console.Write("Invalid date format. Please enter due date (MM/DD/YYYY): ");
        }

        Console.Write("Enter frequency (Weekly/Monthly): ");
        string frequency = Console.ReadLine().Trim().ToLower();

        while (frequency != "weekly" && frequency != "monthly")
        {
            Console.Write("Invalid frequency. Please enter 'Weekly' or 'Monthly': ");
            frequency = Console.ReadLine().Trim().ToLower();
        }

        goals.Add(new Goal { Description = description, DueDate = dueDate, IsCompleted = false, Frequency = frequency });
        Console.WriteLine("Goal added successfully!");
    }

    public void ViewGoals()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals found.");
            return;
        }

        Console.WriteLine("Your Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i]}");  // Added numbering
        }
    }

    public void ViewMonthlyGoals()
    {
        var monthlyGoals = goals.FindAll(g => g.Frequency.ToLower() == "monthly");
        if (monthlyGoals.Count == 0)
        {
            Console.WriteLine("No monthly goals found.");
            return;
        }

        Console.WriteLine("Your Monthly Goals:");
        foreach (var goal in monthlyGoals)
        {
            Console.WriteLine(goal);
        }
    }

    public void ViewWeeklyGoals()
    {
        var weeklyGoals = goals.FindAll(g => g.Frequency.ToLower() == "weekly");
        if (weeklyGoals.Count == 0)
        {
            Console.WriteLine("No weekly goals found.");
            return;
        }

        Console.WriteLine("Your Weekly Goals:");
        foreach (var goal in weeklyGoals)
        {
            Console.WriteLine(goal);
        }
    }

    public void RemoveGoal()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals to remove.");
            return;
        }

        ViewGoals();
        Console.Write("Enter the number of the goal to remove: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= goals.Count)
        {
            goals.RemoveAt(index - 1);
            Console.WriteLine("Goal removed successfully!");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }
}