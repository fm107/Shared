using System;
using System.Collections.Generic;
using System.Text;
using StatePatternSampleApp.StatePattern;

namespace StatePatternSampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TestWithoutStatePattern();

            //TestWithStatePattern();
        }

        private static void TestWithStatePattern()
        {
            ATM atm = new ATM();

            atm.StartTheATM();
        }

        private static void TestWithoutStatePattern()
        {
            NoStateATM atm = new NoStateATM();

            while (true)
            {
                Console.WriteLine(atm.GetNextScreen());
            }
        }
    }
}
