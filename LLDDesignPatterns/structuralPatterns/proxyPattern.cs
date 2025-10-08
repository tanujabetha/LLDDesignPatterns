/*
Proxy Pattern: What is it? Where/When do we use it? How do we implement it?
What is it?
Proxy pattern is to create a placeholder for a complex object. So client instead of interacting with
complex code, then will interact with proxy. 

Proxy will know when you call the read object. It is more like middle-men.
Proxy is not delegation with sequnce like facade. It is just a way to ensure client does not directly interact
with the computationally intensive code.
The proxy can be access proxy, or lazy load, or log proxy.

Where/When do we use it?
1. For Caching
2. For lazy loading in case of computationally heavy tasks


How do we implement it?
1. A common interface
2. Real class implementing the common interface
3. Proxy class will have reference to real class, and also implements the common interface. The real class
is needed for it to call real class objects when needed(lazy loading)


Here we take example of a image load. Each time the object is created, a high resolution image loads.
It takes time, which we will simulate using sleep()
In Naive way, we create objects, and each takes time to load

With proxy, the client interacts with the proxy class. The proxy is responsible to call read object.
This way our object creating does not take time.
*/

using System.Threading;

interface IProxyPattern
{
    void Display();
    string GetFileName();
}


class HighResolutionImageLoader : IProxyPattern
{
    string _filename;
    public HighResolutionImageLoader(string fileName)
    {
        _filename = fileName;
        LoadImagefromDisk();
    }

    public void LoadImagefromDisk()
    {
        Console.WriteLine("Loading from the disk, it takes time!!!!");
        Thread.Sleep(400);
    }

    public string GetFileName()
    {
        return _filename;
    }

    public void Display()
    {
        Console.WriteLine($"Displaying from the real class {GetFileName()}");
    }

}

class ProxyClass : IProxyPattern
{
    HighResolutionImageLoader? realObj;

    string _filename;

    public ProxyClass(string filename)
    {
        _filename = filename;
    }
    public string GetFileName()
    {
        return $"Proxy class:{_filename}";
    }

    public void Display()
    {
        //We are only calling the real class if in case it is required.
        if (realObj == null)
        {
            realObj = new HighResolutionImageLoader(_filename);
            realObj.Display();
        }
        else
        {
            //Calling from the current, which is more like cache
            Console.WriteLine(GetFileName());
        }
    }
}