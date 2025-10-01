//Singleton is a creational pattern that states that there is only one way to invoke a class
//To do this, we will have a private constructor and the a static methos for external objects to access it

namespace creationalPatterns;

class Singleton
{

    public static Singleton? Instance; //nullable instance
    private Singleton() { }
    public static Singleton ObjectCreation()
    {
        if (Instance == null)
        {
            Instance = new Singleton();
        }
        return Instance;
    }

}