namespace BankEncapsulation;

public class BankAccount
{
    // Private information storage
    private double _balance = 0;

    // Public member to modify Private '_balance' member
    public void Deposit(double amount)
    {
        _balance += amount;
    }
    
    // Public member to provide the value within Private '_balance' member
    public double GetBalance()
    {
        return _balance;
    }
}