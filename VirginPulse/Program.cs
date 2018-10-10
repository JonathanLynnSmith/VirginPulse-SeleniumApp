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
            VirginPulseAutomation virginPulseAutomation = new VirginPulseAutomation();

            if (args.Contains("run"))
            {
                virginPulseAutomation.Login(accountInformation.Username, accountInformation.Password);
                virginPulseAutomation.CompleteTwoCards();
                virginPulseAutomation.CompleteThreeHabits();
            } else if (args.Contains("account"))
            {
                accountInformation.RequestAccountInformation();
            }
        }
    }
}
