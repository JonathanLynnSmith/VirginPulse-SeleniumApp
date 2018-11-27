using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirginPulse
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AccountInformation accountInformation = new AccountInformation();
            if (args.Contains("run"))
            {
                AutomateVirginPulse();
            }
            else
            {
                string option = RequestUserInput();
                AvliableOptions(option);
            }

            void AutomateVirginPulse()
            {
                VirginPulseAutomation virginPulseAutomation = new VirginPulseAutomation();
                virginPulseAutomation.Login(accountInformation.Username, accountInformation.Password);
                virginPulseAutomation.CompleteTwoCards();
                virginPulseAutomation.CompleteThreeHabits();
                virginPulseAutomation.ExitBrowser();
            }

            string RequestUserInput()
            {
                Console.WriteLine("");
                Console.WriteLine("Please select an option (type exit to quit):");
                Console.WriteLine("");
                Console.WriteLine("1) Run Virgin Pulse Automation Process");
                Console.WriteLine("2) Schedule To Run Daily (Silent)");
                Console.WriteLine("3) Change Credentials");
                Console.WriteLine("");
                Console.Write("Select a number: ");
                return Console.ReadLine();
            }

            void AvliableOptions(string optionSelected)
            {
                if (optionSelected == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Running Virgin Pulse Automation...");
                    AutomateVirginPulse();
                    Console.WriteLine();
                    Console.WriteLine("Finished Virgin Pulse Automation");
                    Console.WriteLine();
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    Main(args);
                }
                else if (optionSelected == "2")
                {
                    Windows Windows = new Windows();
                    Windows.CreateScheduledTask();
                    Console.Clear();
                    Main(args);
                }
                else if (optionSelected == "3")
                {
                    accountInformation.RequestAccountInformation();
                    System.Environment.Exit(0);
                }
                else if (optionSelected == "exit")
                {
                    System.Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid Selection, please select a number only");
                    Console.WriteLine("");
                    Console.Write("Please select an option: ");
                    AvliableOptions(Console.ReadLine());
                }
            }
        }
    }
}
