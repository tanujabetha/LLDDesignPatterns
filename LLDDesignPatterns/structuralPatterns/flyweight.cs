//one of the trickiest patterns that I have ever learnt
/*
What is it?
Imagine you are playing dodge the ball game. The ball has certain characteristics. 
As you progress in the game, you will need to increase the number of balls you are playing. 
Each object lets say have attributes of 1024mb. Each time you create, you end up creating 1024mb * n objects
We want to memory optimizem and that's wherethe Flyweight Patterns comes to play. 
It divides the attributes into Intrinsic & extrinsic. Intrinsic are common for all the objects, like shape of the ball, color of the ball.
While the extrinsic attributes are the co-ordinates of the ball. 
Since the intrinsic are same across, we do not have to create the heavy object multiple times.

Where is it used?
In cases where there is requirement to create many number of objects that have few attributes in common.
Used in gaming.

How is it used?
Create a class for intrinsic, and the method
Create a factory - this will create an object if it is not there. How does it know an object is to be
created if it is not there already? A dictionary is maintained to track which type is already created. If not created, then, create the object, and add to dictionary
Create Extrinsic class - This will have the object to the intrinsic and a way to call and initialize extrinsic
Then you have actual game which will create these objects
*/
using System.Diagnostics.CodeAnalysis;

namespace structuralPatterns
{
    class TreeType
    {
        //Intrinsic Attributes (common for set of objects)
        public string Type;
        public string Color;

        public TreeType(string Type, string Color)
        {
            this.Type = Type;
            this.Color = Color;
        }
        //This will be called with x, and y which are extrinsic
        public void Plant(int x, int y)
        {
            Console.WriteLine($"Planting the details at coordinate {x} and {y}");
        }
    }

    class TreeTypeFactory
    {
        //This factory helps in creating treeTypes if already not present
        public Dictionary<string, TreeType> TreeTypes = new Dictionary<string, TreeType>();


        public TreeType GetTreeType(string Type, string Color)
        {
            string Key = Type + Color;
            if (!TreeTypes.ContainsKey(Key)) //If it does not contain
            {
                TreeTypes[Key] = new TreeType(Type, Color);
                return TreeTypes[Key];
            }

            return TreeTypes[Key];
        }
    }

    class Tree
    {

        //A tree has both intrinsic and extrinsic properties
        public int x, y;
        public TreeType Type; //this object holds intrinsic properties

        public Tree(int x, int y, TreeType type)
        {
            this.x = x;
            this.y = y;
            this.Type = type;
        }

        public void Plant()
        {
            Type.Plant(x, y);
        }
    }

    class Forest //You can also say as actual game
    {
        public List<Tree> TreeObjects = new();

        public void PlantTree(string Type, string Color, int x, int y)
        {
            Tree t;
            TreeType tt = new TreeTypeFactory().GetTreeType(Type, Color);
            t = new Tree(x, y, tt);
            TreeObjects.Add(t);
        }

        public void Positions()
        {
            foreach(var ob in TreeObjects)
            {
                ob.Plant();
            }
        }
    }
}