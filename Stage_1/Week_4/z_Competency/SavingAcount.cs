using System;
namespace Stage_1.Week_4.z_Competency;

public class SavingAccount : AccountBase, IInterestRate, ICommon
{
    public double AnualInterestRate { get; set; }


    public SavingAccount(double _anualInterestRate, int _accountId, double _currentBalance, string _accountType) : base(_accountId, _currentBalance, _accountType)
    {
        AnualInterestRate = _anualInterestRate;
    }

    public bool IsValid(int accountId)
    {
        if (!accountId.Equals(base.AccountId))
        {
            return false;
        }
        return true;
    }
    public override double Deposit(int accountId, double deposit)
    {
        if (IsValid(accountId) && deposit > 0)
        {
            base.CurrentBalance += deposit;
            return (double)base.CurrentBalance;
        }
        else
        {
            System.Console.WriteLine("Error: Invalid deposit in Saving Account....");
            return (double)base.CurrentBalance;
        }

    }
    public override double Withdrawa(int accountId, double withdrawa)
    {
        if (IsValid(accountId) && withdrawa <= base.CurrentBalance && withdrawa > 0)
        {
            base.CurrentBalance -= withdrawa;
            return (double)base.CurrentBalance;
        }
        else
        {
            System.Console.WriteLine("Error: Invalid Withdrawal in Saving Account....");
            return (double)base.CurrentBalance;
        }
    }

    public double InterstRate()
    {
        // string timed = DateTime.Now.AddYears(1).ToString();
        // if (timed.ToString())
        // {
        //     AnualInterestRate *= base.CurrentBalance;
        // }
        //double anser = (double)base.CurrentBalance * AnualInterestRate;
        //AnualInterestRate = anser;
        AnualInterestRate *= base.CurrentBalance;
        return AnualInterestRate;
    }

    public override string ToString()
    {
        return base.ToString() + $"\nAnual Interest Rate: {AnualInterestRate}";
    }
}