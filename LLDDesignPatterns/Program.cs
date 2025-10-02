using creationalPatterns;


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


        //Builder 
        Pizza p = new BuilderPizza("Marinara").
                      SetCrustType("Thin").
                      SetSize("14").
                      Build();

        Console.WriteLine(p);


        List<string> toppings = new List<string> { "mushroom", "pineapple", "Spinach" };
        //Builder 2
        Pizza p1 = new BuilderPizza("Alfredo").
                    SetCrustType("deepdish").
                    SetSize("11").
                    SetToppings(toppings).
                    Build();

        Console.WriteLine(p1);
    }
}