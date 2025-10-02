//Problem statement: Let's say you are building a class, and it has multiple attributes, not all objects will need all the parameters
//In general case, we can use multiple constructors or setter methods to set the attributes. But this is a mess, how many differnt combinations of consstructors will we create?
//Therefore, we facilitate this with Builder Pattern. The Builder class is responsible for object creation & to set the parameters.

//The Builder Pattern is ideal when your object has lots of optional/complex attributes. It provides readability, flexibility, and immutability.



//Let's do a pizza example 
//Pizza can have optional toppings, sizes, crust types
using System.Collections.Generic;
class Pizza
{
    public string Size { get; private set; }
    public string CrustType { get; private set; }
    public List<string> Toppings { get; private set; }
    public string sauce { get; private set; }
    //Client cannot call this constructor as it is made private. Not only builder can help in creating the object to this Pizza
    //Setting the values of Builder Pizza here is needed
    public Pizza(BuilderPizza ob)
    {
        Size = ob.Size;
        CrustType = ob.CrustType;
        Toppings = ob.Toppings;
        sauce = ob.sauce;

    }

    public override string ToString()
    {
        if (Toppings!=null && Toppings.Count > 0)
        {
            Console.WriteLine("Do you have toppings? ");
            string input = Console.ReadLine();
            if (input.ToLower() == "yes")
            {
                Console.WriteLine("The toppings are:");
                foreach (var a in Toppings)
                {
                    Console.WriteLine(a);
                }
            }
        }
        return $"{Size} inch {sauce} pizza is ready with {CrustType} crust type";
    }
}


class BuilderPizza
{
    //let's say only required is sauce. I will create a BuilderPizza constructor that requires it as Parameter
    public string? Size { get; set; }
    public string? CrustType { get; set; }
    public List<string>? Toppings { get; set; }
    public string? sauce { get; set; }

    public BuilderPizza(string sauce)
    {
        this.sauce = sauce;
    }

    public BuilderPizza SetSize(string size)
    {
        this.Size = size;
        return this;
    }
    public BuilderPizza SetToppings(List<string> toppings)
    {
        this.Toppings = toppings;

        return this;
    }
    public BuilderPizza SetCrustType(string crustType)
    {
        this.CrustType = crustType;
        

        return this;
    }

    public Pizza Build()
    {
        return new Pizza(this);
    }
    
}