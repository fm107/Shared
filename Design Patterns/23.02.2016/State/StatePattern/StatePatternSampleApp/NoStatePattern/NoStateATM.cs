using System;
using System.Collections.Generic;
using System.Text;

namespace StatePatternSampleApp
{
    class NoStateATM
    {
        public enum MACHINE_STATE
        {
            NO_CARD,
            CARD_VALIDATED,
            CASH_WITHDRAWN,
        }

        private MACHINE_STATE currentState = MACHINE_STATE.NO_CARD;
        private int dummyCashPresent = 1000;

        public string GetNextScreen()
        {
            switch (currentState)
            {
                case MACHINE_STATE.NO_CARD:
                    // Here we will get the pin validated
                    return GetPinValidated();
                    break;
                case MACHINE_STATE.CARD_VALIDATED:
                    // Lets try to withdraw the money
                    return WithdrawMoney();
                    break;
                case MACHINE_STATE.CASH_WITHDRAWN:
                    // Lets let the user go now
                    return SayGoodBye();
                    break;
            }
            return string.Empty;
        }

        private string GetPinValidated()
        {
            Console.WriteLine("Please Enter your Pin");
            string userInput = Console.ReadLine();

            // lets check with the dummy pin
            if (userInput.Trim() == "1234")
            {
                currentState = MACHINE_STATE.CARD_VALIDATED;
                return "Enter the Amount to Withdraw";
            }
                
            // Show only message and no change in state
            return "Invalid PIN";
        }

        private string WithdrawMoney()
        {            
            string userInput = Console.ReadLine();

            int requestAmount;
            bool result = Int32.TryParse(userInput, out requestAmount);

            if (result == true)
            {
                if (dummyCashPresent < requestAmount)
                {
                    // Show only message and no change in state
                    return "Amount not present";
                }

                dummyCashPresent -= requestAmount;
                currentState = MACHINE_STATE.CASH_WITHDRAWN;

                return string.Format(@"Amount of {0} has been withdrawn. Press Enter to proceed", requestAmount);
            }

            // Show only message and no change in state
            return "Invalid Amount";
        }

        private string SayGoodBye()
        {
            currentState = MACHINE_STATE.NO_CARD;
            return string.Format("Thanks you for using us, Amount left in ATM: {0}", dummyCashPresent.ToString());
        }
    }
}
