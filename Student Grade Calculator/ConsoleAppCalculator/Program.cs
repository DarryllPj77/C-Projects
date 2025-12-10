using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Enter number of Components: ");
        int compCount = int.Parse(Console.ReadLine());

        double finalGrade = 0;

        for(int i = 0; i < compCount; i++)
        {
            Console.WriteLine("\n-------------------------------------");
            Console.Write("Enter Component name: ");
            string name = Console.ReadLine();

            Console.Write("Enter weight in percent (ex: 25): ");
            double weight = double.Parse(Console.ReadLine()) / 100.0;

            Console.Write($"How many scores for {name}? ");
            int scoreCount = int.Parse(Console.ReadLine());

            double totalScore = 0;
            double totalPossible = 0;

            for(int s = 0; s < scoreCount; s++)
            {
                Console.Write($"\nScore #{s + 1}: ");
                double score = double.Parse(Console.ReadLine());

                Console.Write("Total possible points: ");
                double possible = double.Parse(Console.ReadLine());

                totalScore += score;
                totalPossible += possible;
            }

            double rawPercent = totalScore / totalPossible;
            double weightedGrade = rawPercent * weight;

            Console.WriteLine($"\n{name} Raw: {(rawPercent * 100):F2}%");
            Console.WriteLine($"{name} Weighted: {(weightedGrade * 100):F2}%");

            finalGrade += weightedGrade;
        }

        Console.WriteLine("\n===================================");
        Console.WriteLine($"FINAL GRADE: {(finalGrade * 100):F2}%");
        Console.WriteLine("===================================");
    }
}