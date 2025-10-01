//Single responsibility states that a class can only have a single responsibility to be taken care of

namespace solid;

//this class is taking care of email Notification, sending message and calling a person. 
//This violate the single responsiblity, and often becomes harder to manage
// class Notification
// {
//     public void emailNotification();
//     public void sendMessage();
//     public void callPerson();
// }

//now my class is responsible only to send notications. It does not perform any other operation other than notificaitons
class Notification
{
    public void emailNotification()
    {
        Console.WriteLine("Sending an email");
    }
}



