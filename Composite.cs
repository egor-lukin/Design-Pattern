class MainApp
  {
    static void Main()
    {
      // Create a tree structure
      Composite root = new Composite("root");
 
      root.Add(new Leaf("Leaf A"));
      root.Add(new Leaf("Leaf B"));
 
      Composite comp = new Composite("Composite X");
 
      comp.Add(new Leaf("Leaf XA"));
      comp.Add(new Leaf("Leaf XB"));
      root.Add(comp);
      root.Add(new Leaf("Leaf C"));
 
      // Add and remove a leaf
      Leaf leaf = new Leaf("Leaf D");
      root.Add(leaf);
      root.Remove(leaf);
 
      // Recursively display tree
      root.Display(1);
 
      // Wait for user
      Console.Read();
    }
  }
 
  /// <summary>
  /// Component - компонент
  /// </summary>
  /// <li>
  /// <lu>объявляет интерфейс для компонуемых объектов;</lu>
  /// <lu>предоставляет подходящую реализацию операций по умолчанию,
  /// общую для всех классов;</lu>
  /// <lu>объявляет интерфейс для доступа к потомкам и управлению ими;</lu>
  /// <lu>определяет интерфейс доступа к родителю компонента в рекурсивной структуре
  /// и при необходимости реализует его. Описанная возможность необязательна;</lu>
  /// </li>
  abstract class Component
  {
    protected string name;
 
    // Constructor
    public Component(string name)
    {
      this.name = name;
    }

    public abstract void Display(int depth);
  }
 
  /// <summary>
  /// Composite - составной объект
  /// </summary>
  /// <li>
  /// <lu>определяет поведеление компонентов, у которых есть потомки;</lu>
  /// <lu>хранит компоненты-потомоки;</lu>
  /// <lu>реализует относящиеся к управлению потомками операции и интерфейсе
  /// класса <see cref="Component"/></lu>
  /// </li>
  class Composite : Component
  {
    private ArrayList children = new ArrayList();
 
    // Constructor
    public Composite(string name) : base(name)
    {  
    }
 
    public void Add(Component component)
    {
      children.Add(component);
    }
 
    public void Remove(Component component)
    {
      children.Remove(component);
    }
 
    public override void Display(int depth)
    {
      Console.WriteLine(new String('-', depth) + name);
 
      // Recursively display child nodes
      foreach (Component component in children)
      {
        component.Display(depth + 2);
      }
    }
  }
 
  /// <summary>
  /// Leaf - лист
  /// </summary>
  /// <remarks>
  /// <li>
  /// <lu>представляет листовой узел композиции и не имеет потомков;</lu>
  /// <lu>определяет поведение примитивных объектов в композиции;</lu>
  /// </li>
  /// </remarks>
  class Leaf : Component
  {
    // Constructor
    public Leaf(string name) : base(name)
    {  
    }
 
    public override void Display(int depth)
    {
      Console.WriteLine(new String('-', depth) + name);
    }
  }