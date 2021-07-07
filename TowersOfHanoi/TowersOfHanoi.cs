using System;
using System.Collections;
using System.Collections.Generic;

namespace TowersOfHanoi
{
    class Program
    {
        static void Main(string[] args)
        {     
        Game game = new Game();
        game.Run();
            
        }
    }
// Game class
    public class Game
    {
        // Field defines a Dictionary called towers (variable) with a string (key) and a (tower) value
        public Dictionary<string, Tower> tDictionary;

        //Constructor - when called it creates an instance of a Dictionary called "towers"
        public Game()
        {
        // Method call - creates an empty dictionary called "this.towers" with a string (key) and a Tower object (value)
            this.tDictionary = new Dictionary<string, Tower>();  

        // creates 4 Block objects using the "Block" class and populates them with unique weights
            Block red = new Block(4);
            Block white = new Block(3);
            Block blue = new Block(2);
            Block green = new Block(1);   

        // creates 3 unique Tower objects (A, B, C) defined by the "Tower" class each with an empty Stack of empty Block objects
            Tower A = new Tower();
            Tower B = new Tower();
            Tower C = new Tower();

        // populates TowerA.blocks (blocks = Stack containing a Block object) using Push, one at a time with named "Block"s
            A.blocks.Push(red);
            A.blocks.Push(white);                              
            A.blocks.Push(blue);
            A.blocks.Push(green);

        // Method call - uses the "this.towers" instance variable (Dictionary) and adds (Add) a Key (string) and value (TowerA and B and C) one at a time
            this.tDictionary.Add("A",A);
            this.tDictionary.Add("B",B);
            this.tDictionary.Add("C",C);
        } 

        public void Run()
        {
        Console.WriteLine("Play Towers of Hanoi");
        // User Input Method
        // Ask user to input "From" Tower and "To" Tower
        // Write to screen the player's choice  
        string playGame = "Y";
            while (playGame == "Y")
            {
                printBoard();
     
                // Error handling using try if something other than string values "A", "B" or "C" are entered    
                try 
                {
                    Console.WriteLine("Choose the SOURCE Tower (A, B or C): "); 
                    string from = (Console.ReadLine().ToUpper());
                    Console.WriteLine("SOURCE Tower is Tower: " + from);
                    Tower From = this.tDictionary[from];

                    Console.WriteLine("Choose the To Tower: "); 
                    string to = (Console.ReadLine().ToUpper());
                    Console.WriteLine("DESTINATION Tower is Tower: " + to);
                    Tower To = this.tDictionary[to];

                    if (IsLegal(From, To))
                    {
                        Move(From, To);
                    }
                }
                   
                // catch point in case of a bad user entry
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                printBoard();
                int ctB = this.tDictionary["B"].blocks.Count;
                int ctC = this.tDictionary["C"].blocks.Count;
                if (ctB == 4 || ctC ==4)
                {
                    Console.WriteLine("You Win!");
                    playGame = "end";
                }
                else 
                {Console.WriteLine("Try Another? \"Y\" = yes, any other choice to exit: "); 
                playGame = Console.ReadLine().ToUpper();
                }
            }
            Console.ReadLine(); 
        }
        public void printBoard()
        {
            // iterates through each key in the this.towers Dictionary
            foreach (string key in this.tDictionary.Keys)
            {
                // writes each key
                Console.Write(key+":");
                // creates the variable "blockStack" according to Tower Class - a Stack of a Block
                // this.towers[key] is the Tower (Stack of Block) paired to the instance key
                Tower blockStack = this.tDictionary[key];
                string blockstring = "";    

                // iterates through each Block in blockStack
                // PREpends each weight integer to the string variable x with a space between
                foreach (Block i in blockStack.blocks)
                {       
                    blockstring = i.weight + " " + blockstring;
                }
             // writes out the string variable x   
             Console.WriteLine(blockstring);
            }   
        }  
        public bool IsLegal(Tower From, Tower To)
        {
            if (From.blocks.Count == 0)
                {
                    Console.WriteLine("No move. Nothing in Start Tower ");
                    return false;
                }

            else if (To.blocks.Count == 0)
                {
                    return true;
                }

            else if (To.blocks.Count > 0)
                {
                int E = To.blocks.Peek().weight;
                int S = From.blocks.Peek().weight;
                    if (S > E)
                    {
                        Console.WriteLine("Move Not Accepted. Big block over small block is not allowed"); 
                        return false;
                    }
                }
                return true;
        }
        public void Move(Tower start, Tower end)
        {          
            // this method should move the top block from the source tower to the destination tower
            Block j = start.blocks.Pop();
            end.blocks.Push(j);
        }
    } 
    
    // Tower class creates a Stack containing an empty "Block" object 
    public class Tower
    {
        // Field defines a Stack called blocks (variable) with an empty Block
        public Stack<Block> blocks;

        //Constructor - when called it creates an instance of a Stack with a Block
        public Tower()
        {
            this.blocks = new Stack<Block>();
        }
    }

    // Block class creates a "Block" object made up of a string (color) and an integer (weight)
    public class Block
    {
        //Instance Variable: creates an integer of weight that is unique to each instance

        public int weight {get; private set;}

        // Constructor - when called it creates an instance of a Block 
        public Block(int initialWeight) 
        {
            this.weight = initialWeight;
        }
    }
}