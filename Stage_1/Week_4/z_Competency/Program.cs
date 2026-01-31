using System;

namespace Stage_1.Week_4.z_Competency;

public class BankAccount
{
    static void Main(string[] dominic)
    {
        /*
        
            Create an application with an OOP design to help manage bank accounts. 

            Three types of accounts need to be handled - a savings account, a checking account, and a CD account. 
            All three types of accounts have common information including an account id, the type of account, and current balance. *
            In addition, the savings account has an annual interest rate, the checking account has an annual fee, 
                and the CD has an annual interest rate and a penalty for early withdrawal.
            Two types of transactions need to be handled:
            Deposit - A deposit will include the account id and the amount of the deposit (which must be > 0).   
                All three accounts handle a deposit the same way.  If the account exists, the balance is increased by the deposit amount.
            Withdrawal - A withdrawal will include the account id and the amount of the withdrawal (which must be > 0).  
                Withdrawals are handled differently depending on the account type.
            A savings account withdrawal is allowed as long as the account balance is greater than the withdrawal amount.
            A checking account withdrawal is allowed but only up to 50% of the account balance.
            A CD withdrawal is allowed but the early withdrawal penalty is applied so the balance needs to be greater than the withdrawal amount and the penalty combined.

            Technical specifications for your application include:
            Create an abstract class for an account.  Account id, balance and type are to be properties.  
                In addition to the constructors, include a deposit method, an abstract withdrawal method, and a useful toString.

            Create three classes that inherit from the account class - one each for savings, checkings and CDs.
                Create properties for the respective data attributes, implement the withdrawal method for each as appropriate, and override the toString as appropriate.

            In addition, the savings and CD will implement a calculate annual interest method from an interface that will simply return 
                the annual amount earned based on the current balance and interest rate.  
                Don't add this amount to the balance, but do report it on the toString for a saving or CD account.

            Create and test your classes and methods with hard-coded test data so that there is a list of accounts of different types with different balances.
            Then, provide the user the following options:

            L - List all of the accounts in the list including the account id, balance, and account type and also as appropriate the interest rate, 
                annual fee, and early penalty, and finally for interest-bearing accounts, the amount of annual interest given the current balance and interest rate
            D - Perform a deposit transaction by getting an account number from the user and a deposit amount and if the account exists add the deposit amount to the balance
            W - Perform a withdrawal transaction by getting an account number from the user and a withdrawal amount and if the account exists 
                with enough of a balance, perform the withdrawal including any penalties
            Q - Quit the transaction processing

        */
        bool isValid = false;

        CheckingAccount checkingAccount = new CheckingAccount(0.0, 101, 0.0, "Checking Account");
        List<CheckingAccount> listCheckingAccounts = new List<CheckingAccount>
        {
            new CheckingAccount(
                                checkingAccount.AnualFee = 0.3,
                                checkingAccount.AccountId = 101,
                                checkingAccount.CurrentBalance = 0.0,
                                checkingAccount.AccountType = "Checking Account")
        };

        SavingAccount savingAccount = new SavingAccount(0.0, 102, 0.0, "Saving Account");
        List<SavingAccount> listSavingAccounts = new List<SavingAccount>
        {
            new SavingAccount(
                                savingAccount.AnualInterestRate = 0.005,
                                savingAccount.AccountId = 102,
                                savingAccount.CurrentBalance = 0.0,
                                savingAccount.AccountType = "Saving Account")
        };

        CDAccount cDAccount = new CDAccount(0.0, 0.0, 103, 0.0, "CD Account");
        List<CDAccount> listCDAccounts = new List<CDAccount>
        {
            new CDAccount(cDAccount.CDAnualInterestRate = 0.05,
                                cDAccount.Penalty = 100,
                                cDAccount.AccountId = 103,
                                cDAccount.CurrentBalance = 0.0,
                                cDAccount.AccountType = "CD Account")
        };

        bool exit = false;
        do
        {
            // MENUE
            System.Console.WriteLine("L - list all accounts");
            System.Console.WriteLine("D - Deposit");
            System.Console.WriteLine("W - Withdrawa");
            System.Console.WriteLine("Q - Quit");

            string? options = Console.ReadLine()?.Trim().ToUpper();

            while (options != "L" && options != "D" && options != "W" && options != "Q")
            {
                System.Console.WriteLine("Error: Invalid input please try again.");
                options = Console.ReadLine()?.Trim().ToUpper();
            }
            // LIST ACOUNTS SECTION
            if (options == "L")
            {
                System.Console.WriteLine("LIST All ACCOUNTS SECTION");
                System.Console.WriteLine(savingAccount);
                System.Console.WriteLine(checkingAccount);
                System.Console.WriteLine(cDAccount);
            }
            // DEPOSIT SECTION
            else if (options == "D")
            {
                System.Console.WriteLine("DEPOSIT SECTION");
                System.Console.WriteLine("Verify account ID to deposit");
                string? accountIdInput = Console.ReadLine()?.Trim();
                int.TryParse(accountIdInput, out int accountIdParsed);

                while (!savingAccount.AccountId.Equals(accountIdParsed) &&
                        !checkingAccount.AccountId.Equals(accountIdParsed) &&
                        !cDAccount.AccountId.Equals(accountIdParsed))
                {
                    System.Console.WriteLine("Error: Account not varified, please try again.");
                    accountIdInput = Console.ReadLine()?.Trim();

                    if (savingAccount.AccountId.Equals(int.Parse(accountIdInput)) ||
                        checkingAccount.AccountId.Equals(int.Parse(accountIdInput)) ||
                        cDAccount.AccountId.Equals(int.Parse(accountIdInput)))
                    {
                        accountIdParsed = int.Parse(accountIdInput);
                        break;
                    }
                }
                System.Console.WriteLine("Enter amount to deposit");
                string? depositInput = Console.ReadLine();

                bool exitDeposit = false;
                while (!double.TryParse(depositInput, out double validNumber))
                {
                    System.Console.WriteLine("Error: Invalid deposit");
                    depositInput = Console.ReadLine();
                }

                // VALIDATING USING ACCOUNT NUMBER
                if (savingAccount.AccountId.Equals(accountIdParsed))
                {
                    bool atempt = savingAccount.IsValid(savingAccount.AccountId);
                    isValid = atempt;
                }
                else if (checkingAccount.AccountId.Equals(accountIdParsed))
                {
                    bool atempt = checkingAccount.IsValid(checkingAccount.AccountId);
                    isValid = atempt;
                }
                else if (cDAccount.AccountId.Equals(accountIdParsed))
                {
                    bool atempt = cDAccount.IsValid(cDAccount.AccountId);
                    isValid = atempt;
                }

                // ACTIION IF IS VALID
                if (isValid)
                {
                    if (savingAccount.AccountId.Equals(accountIdParsed))
                    {
                        savingAccount.Deposit(savingAccount.AccountId, double.Parse(depositInput));
                        savingAccount.InterstRate();
                    }
                    else if (checkingAccount.AccountId.Equals(accountIdParsed))
                    {
                        checkingAccount.Deposit(checkingAccount.AccountId, double.Parse(depositInput));
                        checkingAccount.CalculateAnualFee();
                    }
                    else if (cDAccount.AccountId.Equals(accountIdParsed))
                    {
                        cDAccount.Deposit(cDAccount.AccountId, double.Parse(depositInput));
                        cDAccount.InterstRate();
                    }
                }
            }
            // WITHDRAWINT SECTION
            else if (options == "W")
            {
                System.Console.WriteLine("WITHDRAW SECTION");
                System.Console.WriteLine("Verify you ID");
                string? idInput = Console.ReadLine()?.Trim();
                int.TryParse(idInput, out int validId);

                while (!savingAccount.AccountId.Equals(validId) &&
                        !checkingAccount.AccountId.Equals(validId) &&
                        !cDAccount.AccountId.Equals(validId))
                {
                    System.Console.WriteLine("Error: Account not Verified, try again.");
                    idInput = Console.ReadLine().Trim();

                    if (savingAccount.AccountId.Equals(int.Parse(idInput)) ||
                        checkingAccount.AccountId.Equals(int.Parse(idInput)) ||
                        cDAccount.AccountId.Equals(int.Parse(idInput)))
                    {
                        validId = int.Parse(idInput);
                        break;
                    }
                }

                System.Console.WriteLine("Enter amount to withdrawa");
                string? withdrawa = Console.ReadLine()?.Trim();

                while (!double.TryParse(withdrawa, out double validWithdrawl))
                {
                    System.Console.WriteLine("Error: error try again");
                    withdrawa = Console.ReadLine()?.Trim();
                }
                if (savingAccount.AccountId.Equals(validId))
                {
                    bool atempt = savingAccount.IsValid(savingAccount.AccountId);
                    isValid = atempt;
                }
                else if (checkingAccount.AccountId.Equals(validId))
                {
                    bool atempt = checkingAccount.IsValid(checkingAccount.AccountId);
                    isValid = atempt;
                }
                else if (cDAccount.AccountId.Equals(validId))
                {
                    bool atempt = cDAccount.IsValid(cDAccount.AccountId);
                    isValid = atempt;
                }
                if (isValid)
                {
                    if (savingAccount.AccountId.Equals(validId))
                    {
                        savingAccount.Withdrawa(savingAccount.AccountId, double.Parse(withdrawa));
                    }
                    else if (checkingAccount.AccountId.Equals(validId))
                    {
                        checkingAccount.Withdrawa(checkingAccount.AccountId, double.Parse(withdrawa));
                    }
                    else if (cDAccount.AccountId.Equals(validId))
                    {
                        cDAccount.Withdrawa(cDAccount.AccountId, double.Parse(withdrawa));
                    }
                }
            }
            // QUIT SECTION
            else if (options == "Q")
            {
                exit = true;
            }
        } while (!exit);
    }
}