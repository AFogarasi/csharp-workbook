using System;
using System.Collections;
using System.Collections.Generic;

namespace TowersOfHanoi
{
    class Program
    {
        static void Main(string[] args)
        {

        // creates the block objects using the Block Class
        Block red = new Block("Red",4);
        Block white = new Block("White",3);
        Block blue = new Block("Blue",2);
        Block green = new Block("Green",1);

                        // test - did block objects get created
                        Console.WriteLine(red); 
                        Console.WriteLine(white); 
                        Console.WriteLine(blue); 
                        Console.WriteLine(green); 

        //creates the stack objects using Tower Class (Tower tower = new Tower(newStack))
        Tower Stack1 = new Tower(new Stack<Block>());   
        Stack1.blocks.Push(red);
        Stack1.blocks.Push(white);
        Stack1.blocks.Push(blue);
        Stack1.blocks.Push(green); 
        
                        // test - did initial block objects get "pushed" into stack
                        foreach( object obj in Stack1.blocks )
                        {
                            Console.WriteLine("Stack1 " +obj.ToString());
                        }
                            Console.WriteLine("Count " +(Stack1.blocks.Count));

            // Pop off and Push on - needs to get moved to Method in "Game" Class
            // May need to seperate into 2 Methods; a Pop Method and a Push Method
            int count = (Stack1.blocks.Count);           
            Tower Stack2 = new Tower(new Stack<Block>());
            for (int i=0; i < count; i++)
            {
                Block j = Stack1.blocks.Pop();
                Stack2.blocks.Push(j);
            }

                        // test - did Pop off and Push on to Stack2 work
                        foreach( object obj in Stack2.blocks )
                        {
                            Console.WriteLine("Stack2 " +obj.ToString());
                        }

        //creates the dictionary objects (Towers) using Game Class (Game towers = new Game())
        Game towers = new Game();
    
        towers.Add("TowerA", new string[] {"red", "blue", "orange"});
        towers.Add("TowerB", new string[] {"blue", "red", "green"});
        towers.Add("TowerC", new string[] {"green", "white", "blue"});
		
            foreach (var key in towers.Keys)
            {
                Console.WriteLine("Key: " + key);
                foreach (var blockStack in towers[key])
                {
                    Console.WriteLine(blockStack);
                }
                Console.WriteLine("");
            }
            
        }
    }

    public class Game
    {
        public Dictionary <string, string[]> towers;

        public Game (Dictionary <string, string[]> initialTowers)
        {
            this.towers = initialTowers;
        }      
    } 
    
    public class Tower
    {
        public Stack<Block> blocks;

        //Instance Variable: creates a name for each instance of tower
        public Tower (Stack<Block> initialBlocks)
        {
            this.blocks = initialBlocks;
        }
     
        // Method - Using Override allows returns the object instance rather than the "qualified name", ToString converts the object to a string
        override public String ToString()
        {
            String blockGroup = String.Format("{0}", this.blocks);
            return blockGroup;
        }
    }

    public class Block
    {
        //Instance Variable: creates an integer of weight that is unique to each instance
        public string color {get; private set;}
        public int weight {get; private set;}

        // Constructor creates an instance of a Block with and sets the assigns the instance variable to this instance
        public Block (string initialColor, int initialWeight) 
        {
            this.color = initialColor;
            this.weight = initialWeight;
        }

        // Method - Using Override allows returns the object instance rather than the "qualified name", ToString converts the object to a string
        override public String ToString()
        {
            String block = String.Format("{0} {1}", this.color, this.weight);
            return block;
        }

    }

}