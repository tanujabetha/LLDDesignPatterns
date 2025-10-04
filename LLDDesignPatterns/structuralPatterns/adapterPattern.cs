namespace structuralPatterns;
//Adapter pattern is a structural pattern
//It translates incompatible interfaces....okay what does this exactly mean
//You have a payment gateway. There are two ways to make a payment: Credit, Cash
//Both these classes have similar methods, but they way they validate payment, and name of methods are different
//Cash is a legacy code, and we expect things to be with credit in-general.
//Usually how do you handle this? We will have IF-ELSE conditions to say Cash, and call Cash class. 
//else, will call Credit class. Tomorrow, a new third party payment comes, then you will again have another condition
//The issue here is, it does not follow open/closed principle. That is bad!
//Thats why we have Adapter Pattern which will act as a translator between these two interfaces and the client
//Simple analogy to remember: You came to US with your Indian Laptop. The plug pins are different. Did you buy a new charger? 
//No, you bought a universal adapter!!!!!!

//How to implement?
//Legacy Code
//New Class
//An interface (all new class methods)
//Concrete Adapter class extending interface, and the methods will call the actual legacy code. How will it call Legacy Code?
//Pass the object of legacy code. Where? to the constructor of Adapter class
//Let's say you have 2 payment services, Stripe, and Paypal.
//Stripe is your third party code, and has trasactionProcess()
//Paypal is your new code, and it has IsPaymentSuccessful, paymentProcess(), and checkStatus()
interface IPaymentProcessor
{
    public bool IsPaymentSuccessful { get; }
    public void paymentProcess(int money);
    public bool checkStatus();

}

class PaypalService : IPaymentProcessor
{
    int currMoney = 0;
    public bool IsPaymentSuccessful { get; private set; }
    public void paymentProcess(int money)
    {
        currMoney += money;
        IsPaymentSuccessful = true;
        Console.WriteLine($"Payment successful with Paypal with money {currMoney}");
    }

    public bool checkStatus()
    {
        return IsPaymentSuccessful;
    }
}

//This is your legacy code
class Stripe
{
    public int money;
    
    public bool transactionSuccess(int money)
    {
        this.money += money;
        Console.WriteLine($"Transaction Success with money with Stripe: {this.money}");
        return true;
    }
}

//Adapter for stripe
class StripeAdapter : IPaymentProcessor
{
    Stripe ob;
    public bool IsPaymentSuccessful { get; private set; }
    public StripeAdapter(Stripe ob)
    {
        ob.money = ob;
    }

    public void paymentProcess(int money)
    {
        IsPaymentSuccessful = true;
        ob.transactionSuccess(money);
    }

    public bool checkStatus()
    {
        return IsPaymentSuccessful;
    }

}