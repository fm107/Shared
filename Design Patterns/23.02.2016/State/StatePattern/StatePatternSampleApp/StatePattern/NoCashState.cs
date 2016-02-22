using System;
using System.Collections.Generic;
using System.Text;

namespace StatePatternSampleApp.StatePattern
{
    class NoCashState : ATMState
    {
        // This constructor will create new state taking values from old state
        public NoCashState(ATMState state)      
            :this(state.DummyCashPresent, state.Atm)
        {
            
        }

        // this constructor will be used by the other one
        public NoCashState(int amountRemaining, ATM atmBeingUsed)
        {
            this.Atm = atmBeingUsed;
            this.DummyCashPresent = amountRemaining;
        }

        public override string GetNextScreen()
        {            
            Console.WriteLine("ATM is EMPTY");
            Console.ReadLine();
            return string.Empty;
        }

        private void UpdateState()
        {
            // nothing here as someone will have to fill in cash and then
            // restart the atm, once restarted it will be in no card state
        }
    }
}
