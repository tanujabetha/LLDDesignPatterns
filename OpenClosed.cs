namespace solid;

//The Open Closed is open for extension, and modified
//lets say I have email, push notification, anf other kind. 
//The below violates open closed as it has all in one, and I will have to modify the clas and not extend it
//If I need to add another type, I will need to update the if-else.
// //Instead we will have an abstract class, that is extended by cpncrete classes
// class Openclosed
// {
//     public void Notification(String type)
//     {
//         if (type == "Email")
//         {
//             Console.WriteLine("Email notification is sent");
//         }
//         else if (type == "Slack")
//         {
//             Console.WriteLine("Slack notification sent");
//         }
//         else if (type == "SMS")
//         {
//             Console.WriteLine("SMS Email Sent");
//         }
//     }
// }

//now if i want to add anther, i just need to add another class extending the Open Closed
abstract class Openclosed
{
    public abstract void Send();
}

class EmailNotification : Openclosed
{
    public override void Send()
    {
        Console.WriteLine("Email Notification is sent");
    }

    public override string ToString()
    {
        return "Overriding emai notification toString";
    }
}

class Slack : Openclosed
{
    public override void Send()
    {
        Console.WriteLine("Slack Notification is sent");
    }

}

class SMS : Openclosed
{
    public override void Send()
    {
        Console.WriteLine("SMS Notification is sent");
    }
}