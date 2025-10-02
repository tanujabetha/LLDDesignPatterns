using System.Configuration.Assemblies;

namespace creationalPatterns;

//Abstract factory is extension to Factory, where it will have more than one object creation at a time

//This is to have multiple components of same type. What does this avoid:
//It avoid the need to have 2 components of two different types.
// Imagine you’re opening a furniture shop:

// One supplier makes Victorian-style chairs and sofas.

// Another supplier makes Modern-style chairs and sofas.

// As the shop owner, you don’t want to know exact class names. You just say:

// “Give me a Victorian set” → I get Victorian Chair + Victorian Sofa.

// “Give me a Modern set” → I get Modern Chair + Modern Sofa.

// The Abstract Factory ensures you always get matching sets.


// Basically how I understand this is:
// I have a button and a checkbox components, each have their functions as paint(), select() - INTERFACE
// Now windows and MAC are two different types, that will have their own implementation of button & checkbox - TYPES (Concrete classes)
// Now, when we create windows type, we should essentially take only WINDOWS objects. To enforce it we will have an ABSTRACT CLASS
//The concrete classes of each type, will have functions specific to each component (CONCRETE CLASSES)
interface ICheckbox
{
    void Checkbox();
    void OnSelect();
}

interface IButton
{
    void Button();
    void OnClick();
}

//Concrete classes inherit from interfaces
class WindowsCheckbox : ICheckbox
{
    public void Checkbox()
    {
        Console.WriteLine("Windows Checkbox painted");
    }

    public void OnSelect()
    {
        Console.WriteLine("Windows checkbox selected");
    }
}

class WindowsButton : IButton
{
    public void Button()
    {
        Console.WriteLine("Windows button selected");
    }

    public void OnClick()
    {
        Console.WriteLine("Windows button clicked");
    }
}

class MACCheckbox : ICheckbox
{
    public void Checkbox()
    {
        Console.WriteLine("MAC Checkbox painted");
    }

    public void OnSelect()
    {
        Console.WriteLine("MAC checkbox selected");
    }
}

class MACButton : IButton
{
    public void Button()
    {
        Console.WriteLine("MAC button selected");
    }

    public void OnClick()
    {
        Console.WriteLine("MAC button clicked");
    }
}


//Now we have individual components. How do we ensure we create object on a type, and get its specific details
//We will have abstract/interface for it that will look into the functionality

//this is a factory - what can it produce? Product a button or a checkbox of a specific type
interface IFactory
{
    IButton createButton();
    ICheckbox createCheckbox();
}

//Now, we need a concrete class that is specific to its type
//this ensures that when I call windows, I only access properties related to Windows
class Windows : IFactory
{
    public IButton createButton()
    {
        return new WindowsButton();
    }

    public ICheckbox createCheckbox()
    {
        return new WindowsCheckbox();
    }
}

class MAC : IFactory
{
    public IButton createButton()
    {
        return new MACButton();
    }

    public ICheckbox createCheckbox()
    {
        return new MACCheckbox();
    }
}



