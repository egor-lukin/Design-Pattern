 using System;
 
 namespace Prototype
 {  
  class MainApp
  {    
    static void Main()
    {
      // Create two instances and clone each 
      Prototype prototype1 = new ConcretePrototype1("I");
      Prototype clonedPrototype1 = prototype1.Clone();
      Console.WriteLine ("Cloned: {0}", clonedPrototype1 .Id);
 
      Prototype prototype2 = new ConcretePrototype2("II");
      Prototype clonedPrototype2 = prototype2.Clone();
      Console.WriteLine ("Cloned: {0}", clonedPrototype2 .Id);
    }
  }
 
  // "Prototype" 
  public abstract class Prototype
  {
    // Constructor
    public Prototype(string id)
    {
        this.Id = id;

        Console.Write("Base constructor is called.");
    }
 
    // Property
    public string Id { get; private set; }
 
    public virtual Prototype Clone()
    {
         // Shallow copy
        return (Prototype)this.MemberwiseClone();
    }
  }
 
  // "ConcretePrototype1" 
  public class ConcretePrototype1 : Prototype
  {
    // Constructor
    public ConcretePrototype1(string id) : base(id)
    {
    }
  }
 
  // "ConcretePrototype2" 
  public class ConcretePrototype2 : Prototype
  {
    // Constructor
    public ConcretePrototype2(string id) : base(id)
    {
    }
  }
 }
