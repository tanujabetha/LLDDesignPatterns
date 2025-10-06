using System.Runtime.InteropServices;
using creationalPatterns;
using structuralPatterns;


namespace solid;
class Program
{
    public static void Main(string[] args)
    {
        //Single Responsibility
        Notification ob = new Notification();
        ob.emailNotification();

        //Openclosed
        Openclosed ob1;
        ob1 = new EmailNotification();

        ob1.Send();
        Console.WriteLine(ob1);

        //Liskov Substitution
        Movement ob2 = new Bird();
        ob2.Move();

        //Singleton
        Singleton ob3 = Singleton.ObjectCreation();
        Singleton ob4 = Singleton.ObjectCreation();
        Console.WriteLine(object.ReferenceEquals(ob3, ob4));

        //Factory
        NotificationCreator ob5 = new EmailCreator();
        ob5.send();

        NotificationCreator ob6 = new SMSCreator();
        ob6.send();

        //Abstract factory
        IFactory ob7 = new Windows();
        ob7.createButton().Button();
        ob7.createCheckbox().Checkbox();
        ob7.createButton().OnClick();
        ob7.createCheckbox().OnSelect();

        IFactory ob8 = new MAC();
        ob8.createButton().Button();
        ob8.createCheckbox().Checkbox();
        ob8.createButton().OnClick();
        ob8.createCheckbox().OnSelect();

        //Prototype Pattern
        Prototype ob9 = new Prototype("1", "Prototype1");
        Prototype ob10 = ob9.GetClone();
        Console.WriteLine(ob9);
        Console.WriteLine(ob10);


        //Structural Design Pattern
        //Adapter - Translator
        IPaymentProcessor adapter;
        int money;
        Console.WriteLine("Enter the money now:");
        money = int.Parse(Console.ReadLine());
        adapter = new PaypalService();
        adapter.paymentProcess(money);
        adapter.checkStatus();

        IPaymentProcessor stripe;
        Console.WriteLine("Enter the money now:");
        money = int.Parse(Console.ReadLine());
        stripe = new StripeAdapter(new Stripe());
        stripe.paymentProcess(money);
        stripe.checkStatus();

        //Facade pattern
        //Client ideally will interact with facade only
        facadePattern fa = new facadePattern();
        fa.TransferMoney("tanuja", "tarun", 1000);

        //Decorator Pattern
        DecoratorPattern dp = new MochaDecorator(new SugarDecorator(new BaseCoffee()));
        Console.WriteLine(dp.makeCoffee() + "is now prepared for the client");

        //composite pattern
        IComposite f1 = new File("resume.pdf");
        IComposite f2 = new File("I94.png");
        IComposite f3 = new File("VISA.pdf");

        Folder cf = new Folder("Documents");
        cf.addFile(f1);
        cf.addFile(f2);
        cf.addFile(f3);

        cf.getDetails();
        f1.getDetails();

        cf.delete();

    }
}