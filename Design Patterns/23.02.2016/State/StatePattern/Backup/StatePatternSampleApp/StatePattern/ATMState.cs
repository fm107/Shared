using System;
using System.Collections.Generic;
using System.Text;

namespace StatePatternSampleApp.StatePattern
{
    public abstract class ATMState
    {
        private ATM atm;

        public ATM Atm
        {
            get { return atm; }
            set { atm = value; }
        }
        private int dummyCashPresent = 1000;

        public int DummyCashPresent
        {
            get { return dummyCashPresent; }
            set { dummyCashPresent = value; }
        }

        public abstract string GetNextScreen();
    }
}
