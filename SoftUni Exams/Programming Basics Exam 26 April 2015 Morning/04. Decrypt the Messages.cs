using System;
using System.Text;

class DecryptTheMessage
{
    private static StringBuilder result = new StringBuilder();
    public static void Main()
    {
        string command = Console.ReadLine();
        while (command.ToLower() != "start")
        {
            command = Console.ReadLine().ToLower();
        }
        int counter = 0;
        while (true)
        {
            command = Console.ReadLine();
            if (command.ToLower() == "end")
            {
                break;
            }
            else if(!string.IsNullOrWhiteSpace(command))
            {
                counter++;
                EncryptMessage(command);
            }
        }
        if (counter == 0)
        {
            Console.WriteLine("No message received.");
        }
        else
        {
            Console.WriteLine("Total number of messages: {0}",counter);
            Console.Write((result.ToString()));
        }
    }

    private static void EncryptMessage(string recieveMessage)
    {
        string currentMessage = "";
        for (int i = 0; i < recieveMessage.Length; i++)
        {
            if (recieveMessage[i] >= 'N' && recieveMessage[i] <= 'Z' || recieveMessage[i] >= 'n' && recieveMessage[i] <= 'z')
            {
                currentMessage += (Convert.ToString((char)(recieveMessage[i] - 13)));
            }
            else if (recieveMessage[i] >= 'A' && recieveMessage[i] <= 'M' || recieveMessage[i] >= 'a' && recieveMessage[i] <= 'm')
            {
                currentMessage += (Convert.ToString((char)(recieveMessage[i] + 13)));
            }
            else if (recieveMessage[i] >= '0' && recieveMessage[i] <= '9')
            {
                currentMessage += (Convert.ToString(recieveMessage[i]));
            }
            else
            {

                switch (recieveMessage[i])
                {
                    case '+':
                        currentMessage += (" ");
                        break;
                    case '%':
                        currentMessage += (",");
                        break;
                    case '&':
                        currentMessage += (".");
                        break;
                    case '#':
                        currentMessage += ("?");
                        break;
                    case '$':
                        currentMessage += ("!");
                        break;
                }
            }
        }
        currentMessage = Reverse(currentMessage) + "\r\n";
        result.Append(currentMessage);
    }

    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}