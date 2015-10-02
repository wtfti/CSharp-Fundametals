using System;
using System.Collections.Generic;

class Phonebook
{
    static void Main()
    {
        string[] command;
        Dictionary<string, List<string>> phonebook = new Dictionary<string, List<string>>();
        do
        {
            command = Console.ReadLine().Split('-');
            
            if (command.Length == 2)
            {
                if (phonebook.ContainsKey(command[0]))
                {
                    phonebook[command[0]].Add(command[1]);
                }
                else
                {
                    phonebook.Add(command[0], new List<string> {command[1]});
                }
            }
            else if (command.Length == 1)
            {
                if (command[0] == "search")
                {
                    continue;
                }
                CointainsName(phonebook, command[0]);
            }

        } while (command[0] != "end");
    }

    private static void CointainsName(Dictionary<string, List<string>> phonebook, string name)
    {
        if (!phonebook.ContainsKey(name))
        {
            Console.WriteLine(">>>>>>Contact {0} does not exist.", name);
        }
        else
        {
            Console.WriteLine(">>>>>>{0} -> {1}", name, string.Join(", ",phonebook[name]));
        }
    }
}
