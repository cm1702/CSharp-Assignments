using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3
{
    class CricketTeam
    {
        public (int count, double sum, double avg) Pointscalculation(int no_of_matches)
        {
            if (no_of_matches <= 0)
            {
                Console.WriteLine("No. of matches should be greater than 0.");
                return (0, 0, 0);
            }

            double[] scores = new double[no_of_matches];

            for (int i = 0; i < no_of_matches; i++)
            {
                while (true)
                {
                    Console.Write($"Enter score for match {i + 1}: ");
                    try
                    {
                        scores[i] = Convert.ToDouble(Console.ReadLine());
                        break; 
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input.");
                    }
                }
            }

            double totalscore = 0;
            foreach (double score in scores)
            {
                totalscore += score;
            }
            double averagescore = totalscore / no_of_matches;

            return (no_of_matches, totalscore, averagescore);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CricketTeam team = new CricketTeam();
            Console.Write("Enter no. of matches played: ");
            int matches;

            while (!int.TryParse(Console.ReadLine(), out matches) || matches <= 0)
            {
                Console.WriteLine(" Enter a valid no.");
            }

            var (count, total, av) = team.Pointscalculation(matches);

            Console.WriteLine($"\nNo. of Matches: {count}");
            Console.WriteLine($"Total Score: {total}");
            Console.WriteLine($"Average Score: {av:F2}");

            Console.Read();
        }
    }
}
