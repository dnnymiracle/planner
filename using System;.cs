using System;
using System.Collections.Generic;

namespace GoalSettingPlanner
{
    class Program
    {
        static void Main(string[] args)
        {
            GoalManager goalManager = new GoalManager();
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Goal Setting Planner");
                Console.WriteLine("1. Add Goal");
                Console.WriteLine("2. View All Goals");
                Console.WriteLine("3. View Monthly Goals");
                Console.WriteLine("4. View Weekly Goals");
                Console.WriteLine("5. Remove Goal");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        goalManager.AddGoal();
                        break;
                    case "2":
                        goalManager.ViewGoals();
                        break;
                    case "3":
                        goalManager.ViewMonthlyGoals();
                        break;
                    case "4":
                        goalManager.ViewWeeklyGoals();
                        break;
                    case "5":
                        goalManager.RemoveGoal();
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }

    public class Goal
    {
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public string Frequency { get; set; } // Monthly or Weekly

        public override string ToString()
        {
            return $"{Description} - Due: {DueDate.ToShortDateString()} - Frequency: {Frequency} - Completed: {IsCompleted}";
        }
    }

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
            foreach (var goal in goals)
            {
                Console.WriteLine(goal);
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
}
