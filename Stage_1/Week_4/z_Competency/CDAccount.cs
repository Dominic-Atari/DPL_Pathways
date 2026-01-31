using System;
namespace Stage_1.Week_4.z_Competency;

public class CDAccount : AccountBase, ICommon, IInterestRate
{
    public double CDAnualInterestRate { get; set; }
    public double Penalty { get; set; }


    public CDAccount(double _cDAnualInterestRate, double _penalty, int _accountId, double _currentBalance, string _accountType) : base(_accountId, _currentBalance, _accountType)
    {
        CDAnualInterestRate = _cDAnualInterestRate;
        Penalty = _penalty;
    }

    public bool IsValid(int accountId)
    {
        if (!accountId.Equals(base.AccountId))
        {
            System.Console.WriteLine($"Error: ID: {accountId} not found in CD Account");
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
            System.Console.WriteLine("Error: Invalid deposit in CD Account.....");
            return (double)base.CurrentBalance;
        }

    }
    public override double Withdrawa(int accountId, double withdrawa)
    {
        if (IsValid(accountId) && withdrawa < (base.CurrentBalance - Penalty) && withdrawa > 0)
        {
            if (DateTime.Now >= DateTime.Now.AddYears(1))
            {
                base.CurrentBalance -= withdrawa + Penalty;
                return base.CurrentBalance;
            }
            else
            {
                System.Console.WriteLine("Error: Withdrawal will cause penalty.....");
                base.CurrentBalance -= withdrawa + Penalty;
                return base.CurrentBalance;
            }
        }
        else
        {
            System.Console.WriteLine("Error: Invalid withdrawal in CD Account.....");
            return (double)base.CurrentBalance;
        }
    }

    public double InterstRate()
    {
        CDAnualInterestRate *= base.CurrentBalance;
        return CDAnualInterestRate;
    }

    public override string ToString()
    {
        return base.ToString() + $"\nAnual CD Interest rate: {CDAnualInterestRate}";
    }
}