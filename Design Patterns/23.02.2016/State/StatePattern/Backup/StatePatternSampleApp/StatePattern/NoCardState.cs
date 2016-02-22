using System;
using System.Collections.Generic;
using System.Text;

namespace StatePatternSampleApp.StatePattern
{
    class NoCardState : ATMState
    {
        // This constructor will create new state taking values from old state
        public NoCardState(ATMState state)     
            :this(state.DummyCashPresent, state.Atm)
        {
            
        }

        // this constructor will be used by the other one
        public NoCardState(int amountRemaining, ATM atmBeingUsed)
        {
            this.Atm = atmBeingUsed;
            this.DummyCashPresent = amountRemaining;
        }

        public override string GetNextScreen()
        {            
            Console.WriteLine("Please Enter your Pin");
            string userInput = Console.ReadLine();

            // lets check with the dummy pin
            if (userInput.Trim() == "1234")
            {
                UpdateState();
                return "Enter the Amount to Withdraw";
            }

            // Show only message and no change in state
            return "Invalid PIN";
        }

        private void UpdateState()
        {
            Atm.currentState = new CardValidatedState(this);
        }
    }
}
