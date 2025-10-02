//Lets you create new objects by cloning existing ones
//One way to have it is to have encapsulation, and expose a method that will return a copy of the object

class Prototype
{
    string id;
    string name;
    public Prototype(string id, string name)
    {
        this.id = id;
        this.name = name;
    }

    public Prototype GetClone()
    {
        //return this;  I cannot return this as it will return the same reference. So, If I need to make some changes in clone, it will affect my original
        return new Prototype(this.id, this.name);
    }

    public override string ToString()
    {
        return $"Id is {id} and name is {name}";
    }
}