//What it is, where is it used, how is it used?
//What is it?
//Facade pattern - think of it as actual point of contact to interact with multiple complex subsystems. You don't have to know what those subsystems are and how should they be implemented
//You can just say "Hey, I want to get this done", the facade pattern(acting as mediator) will know what & how that task should be performed
//e.g: Think of a high-end hotel. As a guest (the client), you don't want to individually contact housekeeping for a fresh towel, the restaurant for dinner reservations, and the valet for your car. Instead, you call the Concierge Desk (the Facade).

// You make a simple request to the concierge,
// like "I'd like dinner reservations at 8 PM and my car ready afterwards." 
// The concierge then interacts with all the necessary hotel departments 
// (the subsystem) to fulfill your request.

// You, as the guest, are shielded from this internal complexity.
// The Concierge Desk provides a simplified interface to the hotel's services.


//Now, that we understand what it is, and where to use it, let's understand how to implement it

//Taking example of money transfers
// Example: Banking System Facade

// Imagine you want to transfer money.
/// <summary>
///Our process would see get acc 1 and acc 2, and the money to transfer
/// What checks we do, 
/// Verify the user
/// does acc 1 has sufficient balance to transfer
/// Ledger to log
/// Notification to the client that it is transfered
/// </summary>


//going with assumption that the primary account holder is only transferring the money
class SecurityService
{
    public bool VerifyUser(AccountService ob)
    {
        Console.WriteLine($"Verifying {ob.accountId}");
        return true;
    }
}
class AccountService
{
    public string? accountId;
    int balance;
    public AccountService()
    {
        balance = 1000;
    }
    public AccountService(string accountId)
    {
        this.accountId = accountId;
    }
    //Assuming that max balance is 1000 all time
    public bool SufficientBalance(int money)
    {
        Console.WriteLine($"The balance in {accountId} is: {balance}");
        if (money <= balance)
        {
            //balance = balance - money;
            Console.WriteLine($"Transferring; Updated balance is: {balance} ");
            return true;
        }
        return false;
    }

    public bool Transfer(AccountService toaccount, int money)
    {
        if (SufficientBalance(money))
        {
            Console.WriteLine($"Transferring from {accountId} to {toaccount.accountId}");
            toaccount.balance += money;
            balance = balance - money;
            Console.WriteLine($"Recipient balance is updated to {toaccount.balance}");
            return true;
        }
        return false;
    }
}

class LedgerService
{
    public void RecordTransaction(AccountService from, AccountService to, int money)
    {
        Console.WriteLine($"Transferred {money} from {from.accountId} to {to.accountId}");

    }
}

class Notification
{
    public void notify(AccountService ac)
    {
        Console.WriteLine($"Notifing {ac.accountId} that the transfer is complete");
    }
}

//This guys take all the heat, and calls the respective functions and makes life easy for client

class facadePattern
{
    SecurityService s;
    Notification ob;
    AccountService to;
    AccountService from;
    LedgerService log;

    public facadePattern()
    {
        s = new SecurityService();
        ob = new Notification();
        to = new AccountService();
        from = new AccountService();
        log = new LedgerService();

    }

    public bool TransferMoney(string from_id,string to_id,  int money)
    {
        from.accountId = from_id;
        to.accountId = to_id;

        if (s.VerifyUser(from))
        {
            if (from.SufficientBalance(money))
            {
                from.Transfer(to, money);
            }
            else
            {
                Console.WriteLine($"Insufficient funds in {from.accountId}");
                return false;
            }
        }
        log.RecordTransaction(from, to, money);
        ob.notify(from);
        return true;
    }

}