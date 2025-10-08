//Bridge pattern is used for having two independent dimensions interact.
/*
Let's elaborate!
What is bridge pattern?
Bridge pattern is a structural design pattern that helps in separating abstraction from implementation.
I remember it as, if there are multiple classes of a similar type, and each can have some internal 
format/type, we do not want to end up creating multiple combinations of classes. It will cause class explosion.
Then we use bridge, to mix-match these combinations. 
Where/When is bridge Pattern used?
For e.g, you have a videoPlayer - There are two types, BasicPlayer and Advanced Player
you have type of videoPlayer - MP3, WAV, FLAC. 
Instead of creating 2*3 classes here, you have BRIDGE pattern that allows you do the mix-match. 
Later if you have any other new type that will be added, then you will have to just create it class, and the flo go on by itself
How do we do it?
1. Create a common interface/abstract for type
2. Concrete classes for type
3. Create a common interface/abstract for player, and have the type object to it
3. Concrete classes for players
*/

using System.Runtime.InteropServices;

interface IType
{
    void playFile();
}

class MP3 : IType
{
    public void playFile()
    {
        Console.WriteLine($"Playing the MP3 File");
    }
}

class WAV : IType
{
    public void playFile()
    {
        Console.WriteLine($"Playing the WAV File");
    }
}


class FLAC : IType
{
    public void playFile()
    {
        Console.WriteLine($"Playing the FLAC File");
    }
}

//Player abstract/interface

abstract class Player
{
    IType type;
    public Player(IType ob)
    {
        type = ob;
    }

    public abstract void Play();
}

class BasicPlayer : Player
{
    IType? type;
    public BasicPlayer(IType ob) : base(ob)
    {
        type = ob;
    }
    public override void Play()
    {
        Console.Write("Playing the basic player's");
        type.playFile();
    }
}

class AdvancedPlayer : Player
{
    IType? type;
    public AdvancedPlayer(IType ob) : base(ob)
    {
        type = ob;
    }
    public override void Play()
    {
        Console.Write("Playing the Advanced player's");
        type.playFile();
    }
}