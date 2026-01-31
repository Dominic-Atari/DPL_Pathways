using System;
namespace Stage_1.Week_4.z_Competency;

public class CheckingAccount : AccountBase, ICommon
{
    public double AnualFee { get; set; }


    public CheckingAccount(double _anualFee, int _accountId, double _currentBalance, string _accountType) : base(_accountId, _currentBalance, _accountType)
    {
        AnualFee = _anualFee;
    }

    public bool IsValid(int accountId)
    {
        if (!accountId.Equals(base.AccountId))
        {
            System.Console.WriteLine($"Error: ID: {accountId} not found in checking Account");
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
            System.Console.WriteLine("Error: Invalid Deposit in Checking Account");
            return (double)base.CurrentBalance;
        }

    }
    public override double Withdrawa(int accountId, double withdrawa)
    {
        if (IsValid(accountId) && withdrawa < (base.CurrentBalance / 2) && withdrawa > 0)
        {
            base.CurrentBalance -= withdrawa;
            return (double)base.CurrentBalance;
        }
        else
        {
            System.Console.WriteLine("Error: Invalid withdrawal in checking Account.....");
            return (double)base.CurrentBalance;
        }
    }

    public double CalculateAnualFee()
    {
        double anser = AnualFee * ((double)base.CurrentBalance / 100);
        AnualFee = (double)base.CurrentBalance - anser;
        return AnualFee;
    }

    public override string ToString()
    {
        return base.ToString() + $"\nAnual Fee: {AnualFee}";
    }
}