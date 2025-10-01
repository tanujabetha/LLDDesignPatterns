//This is to ensure we are aligned to open closed principle.
//So, we have an interface that will have the methods.
//There is abstract class that will create the objects
//The concrete methods will invoke an object of respective type
//This pattern is used when we do not know which type object will be called.

using solid;

namespace creationalPatterns;


interface Notification
{
    public void Send();
}

class Email : Notification
{
    public void Send()
    {
        Console.WriteLine("Sending an email notification");
    }
}

class SMS : Notification
{
    public void Send()
    {
        Console.WriteLine("Sending SMS notification");
    }
}

//Creating an abstract class
abstract class NotificationCreator
{
    public Notification? ob; //Having an interface obj, which will be updated based on the object we invoke
    public abstract Notification CreateNotification();
    public void send()
    {
        Notification ob = CreateNotification();
        ob.Send();
    }
}

class EmailCreator : NotificationCreator
{
    public override Notification CreateNotification()
    {
        return new Email();
    }
}

class SMSCreator : NotificationCreator
{
    public override Notification CreateNotification()
    {
        return new SMS();
    }
}