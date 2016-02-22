using System;
using System.Collections.Generic;
using System.Text;

namespace StatePatternSampleApp.StatePattern
{
    class CashWithdrawnState : ATMState
    {
        // This constructor will create new state taking values from old state
        public CashWithdrawnState(ATMState state)      
            :this(state.DummyCashPresent, state.Atm)
        {
            
        }

        // this constructor will be used by the other one
        public CashWithdrawnState(int amountRemaining, ATM atmBeingUsed)
        {
            this.Atm = atmBeingUsed;
            this.DummyCashPresent = amountRemaining;
        }

        public override string GetNextScreen()
        {
            UpdateState();
            return string.Format("Thanks you for using us, Amount left in ATM: {0}", this.DummyCashPresent.ToString());
        }

        private void UpdateState()
        {
            Atm.currentState = new NoCardState(this);
        }
    }
}
