using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirginPulse.Helpers;


namespace VirginPulse
{
    public class Program
    {      
        public static void Main(string[] args)
        {
            VirginPulseAccount virginPulseAccount = new VirginPulseAccount();
            if (args.Contains("run"))
            {
                virginPulseAccount.Login(virginPulseAccount.Username, virginPulseAccount.Password);
                virginPulseAccount.CompleteTwoCards();
                virginPulseAccount.CompleteThreeHabits();
            }
            if (args.Contains("account"))
            {
                virginPulseAccount.RequestAccountInformation();
            }
        }
    }
}
