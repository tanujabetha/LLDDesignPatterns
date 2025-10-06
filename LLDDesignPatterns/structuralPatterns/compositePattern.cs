/*
What is this pattern?
This is a simple pattern. Here we want to ensure uniformity. For e.g, you have a file and a folder. The operations you have are open, delete, size(). 
They seem like common operations, however, the file is a single entity, and folder is combination of multiple. 
In naive way, you create two classes, each for folder and file, and have instanceof() created to identify the type of object that is being invoked by client
Then, you would call that method. Problem here:
1. Repetition. You have semantically same methods. You are just repeating them
2. For instance of, you would use if-else. If a new type comes, you will need to modify, and that violates open/closed.

Where/When is it used?
When you need uniformity

How is it used?
We use composite pattern to ensure that we consider with uniformity. So, we will have an interface created
that holds all the common objects. 
Then, the concrete classes implement the interface
Client creates necessary objects
*/


interface IComposite
{
    //Holds the common components
    int getSize();
    void getDetails();
    bool delete();
}

class File : IComposite
{
    public string name;

    public File(string name)
    {
        this.name = name;
    }

    public int getSize()
    {
        return 10;
    }

    public void getDetails()
    {
        Console.WriteLine($"File Name: {name}");
    }

    public bool delete()
    {

        Console.WriteLine($"File {name} is deleted");
        return true;
    }

}



class Folder : IComposite
{
    string name;
    int numberofFiles;

    List<IComposite> files = new List<IComposite>();

    public Folder(string name)
    {
        this.name = name;
    }

    public bool addFile(IComposite fileName)
    {
        files.Add(fileName);
        return true;
    }

    public int getSize()
    {
        return 10 * files.Count();
    }

    public void getDetails()
    {
        Console.WriteLine($"File Name: ");
        foreach (var file in files)
        {
            file.getDetails();
        }

    }

    public bool delete()
    {

        foreach (IComposite file in files)
        {
            file.delete();

        }
        files.Clear();
        Console.WriteLine($"Deleting the folder: {name}");
        return true;
    }

}