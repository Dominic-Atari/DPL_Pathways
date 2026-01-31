using System;
namespace Stage_1.Week_4.z_Competency;

public abstract class AccountBase
{
    public int AccountId { get; set; }
    public double CurrentBalance { get; set; }
    public string AccountType { get; set; }

    public AccountBase(int _accountId, double _currentBalance, string _accountType)
    {
        AccountId = _accountId;
        CurrentBalance = _currentBalance;
        AccountType = _accountType;
    }
    public abstract double Deposit(int accountId, double deposit);
    public abstract double Withdrawa(int accountId, double withdrawa);
    public override string ToString()
    {
        return $"\nAccount ID: {AccountId}\nCurrent Account Balance: {CurrentBalance}\nAccount Type: {AccountType}";
    }
}