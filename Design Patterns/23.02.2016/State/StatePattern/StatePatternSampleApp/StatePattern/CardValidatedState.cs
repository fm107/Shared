using System;
using System.Collections.Generic;
using System.Text;

namespace StatePatternSampleApp.StatePattern
{
    class CardValidatedState : ATMState
    {
        // This constructor will create new state taking values from old state
        public CardValidatedState(ATMState state)    
            :this(state.DummyCashPresent, state.Atm)
        {
            
        }

        // this constructor will be used by the other one
        public CardValidatedState(int amountRemaining, ATM atmBeingUsed)
        {
            this.Atm = atmBeingUsed;
            this.DummyCashPresent = amountRemaining;
        }

        public override string GetNextScreen()
        {
            string userInput = Console.ReadLine();

            int requestAmount;
            bool result = Int32.TryParse(userInput, out requestAmount);

            if (result == true)
            {
                if (this.DummyCashPresent < requestAmount)
                {
                    // Show only message and no change in state
                    return "Amount not present";
                }

                this.DummyCashPresent -= requestAmount;
                UpdateState();

                return string.Format(@"Amount of {0} has been withdrawn. Press Enter to proceed", requestAmount);
            }

            // Show only message and no change in state
            return "Invalid Amount";
        }

        private void UpdateState()
        {
            if (this.DummyCashPresent == 0)
            {
                Atm.currentState = new NoCashState(this);
            }
            else
            {
                Atm.currentState = new CashWithdrawnState(this);
            }
        }
    }
}
