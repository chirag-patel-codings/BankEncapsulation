namespace BankEncapsulation
{
    public class Program
    {
        static void Main(string[] args)
        {

            var consoleOriginalForegroundColor = Console.ForegroundColor;
            var consoleDarkGray = ConsoleColor.DarkGray;
            var consoleDarkCyan = ConsoleColor.DarkCyan;
            var consoleDarkRed = ConsoleColor.DarkRed;
            
            string promptMessage = "", errorMessage = "";
            
            var account = new BankAccount();

            promptMessage =
                "----------------------------------\nWelcome to the Banking Application\n----------------------------------";
            DisplayPrompt(promptMessage, consoleOriginalForegroundColor);
            
            // Continuous loop until user exits using provided app option
            while (true)
            {
                
                promptMessage = "\nPlease select from the following options:";
                DisplayPrompt(promptMessage, consoleOriginalForegroundColor);

                promptMessage = "1. To Check the Balance";
                DisplayPrompt(promptMessage, consoleDarkGray);

                promptMessage = "2. To Deposit";
                DisplayPrompt(promptMessage, consoleDarkCyan);

                promptMessage = "3. To Exit\n";
                DisplayPrompt(promptMessage, consoleDarkRed);
                
                // For the new input
                Console.ForegroundColor = consoleOriginalForegroundColor;
                
                int option;
                if (!int.TryParse(Console.ReadLine().Trim(), out option))
                {
                    errorMessage = "-----------------\nInvalid input!!!\n-----------------";
                    DisplayPrompt(errorMessage, consoleDarkRed );
                    
                    // Reset for next input after error
                    Console.ForegroundColor = consoleOriginalForegroundColor;       
                    continue;
                }
                
                double depositAmount = 0;
                int amountLoopCounter = 0;
                
                switch (option)
                {
                    case 1:
                        
                        promptMessage = $"\nYour current balance is: ${account.GetBalance()}.\n";
                        DisplayPrompt(promptMessage, consoleDarkGray);
                        break;
                    
                    case 2:
                        
                        do
                        {
                            promptMessage = "\nPlease enter the amount you want to deposit:";
                            
                            // In the case of validation error
                            if (amountLoopCounter > 0)
                            {
                                errorMessage =
                                    "-------------------------\nInvalid deposit amount!!!\n-------------------------";
                                DisplayPrompt(errorMessage, consoleDarkRed);
                            }
                            
                            DisplayPrompt(promptMessage, consoleDarkCyan);
                            
                            amountLoopCounter++;
                            
                            // Reset for next input after prompt
                            Console.ForegroundColor = consoleOriginalForegroundColor;
                            
                        } while ( !(double.TryParse(Console.ReadLine().Trim(), out depositAmount) && depositAmount > 0) );
                        
                        // Deposit new amount
                        account.Deposit(depositAmount);
                        
                        promptMessage = $"\nDeposit Successful. Your new balance is ${account.GetBalance()}.";
                        DisplayPrompt(promptMessage, consoleDarkGray);
                        break;
                    
                    case 3:

                        promptMessage = "\n\nThank you for using banking app.\n";
                        DisplayPrompt(promptMessage, consoleOriginalForegroundColor);
                        
                        return;     // Exits this method (& Application)
                    
                    default:
                        // For invalid numeric entries
                        errorMessage = "-----------------\nInvalid input!!!\n-----------------";
                        DisplayPrompt(errorMessage, consoleDarkRed);
                        break;
                }
            }
        }

        // Displays the Console prompt with the supplied foreground color:
        static void DisplayPrompt(string promptMessage, ConsoleColor displayColor)
        {
            Console.ForegroundColor = displayColor;
            Console.WriteLine(promptMessage);
        }
    }
}
