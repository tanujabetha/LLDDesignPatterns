//Decorator Pattern
/*One of the patterns that was complex for me to understand after Factory and Abstract Factory.
//So let's break down: what it is? Why it is? How it is done?

Why it is?
If let's say, we need certain add-on to the base structure, the naive way to do it is to create multiple classes with differnt combinations
and create objects for them.
But the problem is that we end up creating multiple permutations of the code, and this will eventually make it complex, and violates Open/closed principles
Therefore, the Decorator Pattern comes into play. It avoids updating the base object.

What it is?
Decorator pattern is wrapping base object with add-ons. The pattern relies on wrapping an object inside another object 
(a decorator) that implements the same interface 
and adds new behavior before or after delegating to the wrapped object.

How it is done?
We have an interface with the method, and then there is the base class which implements the method.
We have a decoratorAdapter that will need the object of the interface (why? because, it needs to add on top of it)
Then there are concreteDecoratorAdapter that will update the methods in the interface on top of the object from its adapter classes
Let's take a simple example of coffee. The base is coffee, on top of it, we add milk, mocha, sugar. Milk, mocha, sugar are optional, and 
they need coffee as base. 
*/

interface ICoffeeShop
{
    string makeCoffee();
}

class BaseCoffee : ICoffeeShop
{
    string Name = "";
    public string makeCoffee()
    {
        Name = "Plain Coffee";
        return Name;
    }
}

abstract class DecoratorPattern : ICoffeeShop
{
    //We need the object of Icoffee here as we add on top of base
    public ICoffeeShop inner;
    public DecoratorPattern(ICoffeeShop inner)
    {
        this.inner = inner;
    }

    public virtual string makeCoffee()
    {
        return inner.makeCoffee();
    }
}

class MochaDecorator : DecoratorPattern
{
    //Also updating the base class object
    public MochaDecorator(ICoffeeShop inner) : base(inner)
    {
    }

    public override string makeCoffee()
    {
        //accessing the object from base class
        return inner.makeCoffee() + "Mocha";
    }
}

class SugarDecorator : DecoratorPattern
{
    //Also updating the base class object
    public SugarDecorator(ICoffeeShop inner) : base(inner)
    {
    }

    public override string makeCoffee()
    {
        //accessing the object from base class
        return inner.makeCoffee() + " Sugar";
    }
}


class MilkDecorator : DecoratorPattern
{
    //Also updating the base class object
    public MilkDecorator(ICoffeeShop inner) : base(inner)
    {
    }

    public override string makeCoffee()
    {
        //accessing the object from base class
        return inner.makeCoffee() + " Milk";
    }
}


