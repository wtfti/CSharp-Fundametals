using System;
using System.Collections.Generic;
using System.Linq;

internal class NightLife
{
    static void Main()
    {
        SortedDictionary<string, SortedDictionary<string, List<string>>> citiesClubs = new SortedDictionary<string, SortedDictionary<string, List<string>>>();
        string[] command;
        const int PARAMETERS_COUNT = 3;
        do
        {
            command = Console.ReadLine().Split(';').ToArray();
            if (command.Length == PARAMETERS_COUNT)
            {
                string city = command[0];
                string club = command[1];
                string singer = command[2];
                if (!citiesClubs.ContainsKey(city))
                {
                    citiesClubs.Add(city, new SortedDictionary<string, List<string>>());
                    citiesClubs[city].Add(club, new List<string>());
                    citiesClubs[city][club].Add(singer);
                }
                else
                {
                    if (citiesClubs[city].ContainsKey(club))
                    {
                        if (citiesClubs[city][club].FirstOrDefault(a => a == singer) == null)
                        {
                            citiesClubs[city][club].Add(singer);
                        }
                    }
                    else
                    {
                        citiesClubs[city].Add(club, new List<string>());
                        citiesClubs[city][club].Add(singer);
                    }
                }
            }
        } while (command[0] != "END");

        foreach (var citiesClub in citiesClubs)
        {
            Console.WriteLine(citiesClub.Key);
            foreach (var value in citiesClubs[citiesClub.Key])
            {
                Console.WriteLine("-> {0}: {1}", value.Key, string.Join(", ", value.Value));
            }
        }
    }
}