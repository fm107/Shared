using System;
using System.Collections.Generic;
using System.Text;

namespace StatePatternSampleApp.StatePattern
{
    public class ATM
    {
        public ATMState currentState = null;        

        public ATM()
        {
            currentState = new NoCardState(1000, this);
        }

        public void StartTheATM()
        {
            while (true)
            {
                Console.WriteLine(currentState.GetNextScreen());
            }
        }
    }
}
