//LISKOV Substitution :
//  If a class S extends or implements class T, then you should be able to use S anywhere T is expected—without breaking the program’s behavior or logic.

//In other words, subtypes must honor the expectations set by their base types.
// The client code shouldn’t need to know or care which specific subtype it’s dealing with. Everything should “just work.”
//so for eg, there is fly(), birds fly, but not ostrich
//Fix: Don’t force subclasses into behaviors that don’t make sense.


abstract class Movement
{
    public abstract void Move();
}


class Bird : Movement
{
    public override void Move()
    {
        Console.WriteLine("Birds Fly");
    }
}
class Ostrich : Movement
{
    public override void Move()
    {
        Console.WriteLine("Ostrich Walks");
    }
}