using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ToDo
{
    class Program
    {
        static void Main(string[] args)
        {
         App app = new App();
         app.start();
        }
    }

    public class Utils
    {
        public void printMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("To-Do List - Choose an Item");
            Console.WriteLine("enter 1 to add a new item");
            Console.WriteLine("enter 2 to delete an existing item");
            Console.WriteLine("enter 3 to change item to done status");
            Console.WriteLine("enter 4 to list all items");
            Console.WriteLine("Any other number to exit");
            Console.WriteLine("");
        }

        public void printItemEnterMessage()
        {
            Console.WriteLine("Enter Item Description");
        }

        public void printItemDeleteMessage()
        {
            Console.WriteLine("Enter Item ID number to Delete");
        }

        public void printItemChangeMessage()
        {
            Console.WriteLine("Enter Item ID number to change Status - toggle pending vs. done"); 
        }

        public void printExitMessage()
        {
            Console.WriteLine("Exiting ToDo App"); 
        }

        public void printTable(List<Item> table)
        {
            Console.WriteLine("List of all To Do Items:");
            foreach(Item it in table)
            {
                Console.WriteLine("Id: {0} Item: {1} Status: {2}", it.id, it.item, it.status); 
            }
        }

        public int readNumber()
        {
           int id = int.Parse(Console.ReadLine()); 
           return id;
        }

        public string readText()
        {
            string text = Console.ReadLine();
            return text;
        }

    }

    public class App
    {
        Dao dao;
        Utils newUtil;
        List<Item> table;
        public static bool end = false;

        public App()
        {
            dao = new Dao();
            newUtil = new Utils();      
        }


        public void addItem()
        {
            newUtil.printItemEnterMessage();
            string newDescription = newUtil.readText();
            dao.create(newDescription, Type.pending);
        }

        public void deleteItem()
        {
            listItem();
            newUtil.printItemDeleteMessage();
            int deleteId = newUtil.readNumber();
            dao.delete(deleteId);
        }

        public void changeStatus()
        {
            listItem();
            newUtil.printItemChangeMessage();
            int changeId = newUtil.readNumber();
            dao.change(changeId);
        }

        public void listItem()
        {
            table = dao.listcontext();
            newUtil.printTable(table);
        }

        public void exitApplication()
        {
            newUtil.printExitMessage();
        }

        public static bool EndExercise()
        {
        return end;
        } 


        public void start()
        {
            do
            {    
                // Error handling using try if something unexpected is entered    
                try 
                {     
                    newUtil.printMenu();
                    int choice = newUtil.readNumber();
                    {    
                        if (choice == 1) 
                        {
                            addItem();
                        }  
                        else if (choice == 2)  
                        {
                            deleteItem();
                        }
                        else if (choice == 3)  
                        {
                            changeStatus();
                        }
                        else if (choice == 4)  
                        {
                            listItem();
                        }
                        else 
                        {
                            exitApplication();
                        end = true;
                        }
                    }
                }
                // catch point in case of a bad user entry
                catch (FormatException fex) 
                    { 
                    Console.WriteLine(fex.Message); 
                    }            
            }
            while (!EndExercise() == true );
            Console.ReadLine();              
        }
    }

    public class Item
    {
        public int id {get; private set;}
        public String item {get; private set;}
        public Type status {get; private set;}

        public Item()
        {

        }

        public Item(String iDescription, Type iStatus)
        {
          this.item = iDescription;
          this.status = iStatus;  
        }
    }

    public enum Type
    {
        pending, done
    }

    public class Dao
    {
        private ItemsContext context;

        public Dao()
        {
            context = new ItemsContext();
            context.Database.EnsureCreated();
        }

        public void create(String description, Type status)
        {
            Item newItem = new Item(description, status);
            context.items.Add(newItem);
            context.SaveChanges();
        }

        public List<Item> listcontext()
        {
            List<Item> result = new List<Item>();
            foreach(Item it in context.items)
            {
                result.Add(it);
            }
            return result;
        }

        public void delete(int deleteId)
        {
            foreach (Item todo in context.items)
            {
                if (deleteId == todo.id)
                {
                    context.items.Remove(todo);        
                }
            context.SaveChanges();
            }
        }

        public void change(int changeId)
        {
            foreach (Item todo in context.items)
            {
                if (changeId == todo.id)
                {
                    if(todo.status == Type.pending)
                    {
                        Console.WriteLine(todo.status);
                        // context.items.todo.status = Type.done;

                    }     
                }
            // context.SaveChanges();
            }
        }
    
    }

    public class ItemsContext : DbContext
    {
        public DbSet<Item> items { get; private set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./items.db");
        }
    }
}


