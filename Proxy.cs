using System;
  using System.Threading;

  class MainApp
  {
    static void Main()
    {
      // Create math proxy
      IMath p = new MathProxy();

      // Do the math
      Console.WriteLine("4 + 2 = " + p.Add(4, 2));
      Console.WriteLine("4 - 2 = " + p.Sub(4, 2));
      Console.WriteLine("4 * 2 = " + p.Mul(4, 2));
      Console.WriteLine("4 / 2 = " + p.Div(4, 2));

      // Wait for user
      Console.Read();
    }
  }

  /// <summary>
  /// Subject - субъект
  /// </summary>
  /// <remarks>
  /// <li>
  /// <lu>определяет общий для <see cref="Math"/> и <see cref="Proxy"/> интерфейс, так что класс
  /// <see cref="Proxy"/> можно использовать везде, где ожидается <see cref="Math"/></lu>
  /// </li>
  /// </remarks>
  public interface IMath
  {
    double Add(double x, double y);
    double Sub(double x, double y);
    double Mul(double x, double y);
    double Div(double x, double y);
  }


  /// <summary>
  /// RealSubject - реальный объект
  /// </summary>
  /// <remarks>
  /// <li>
  /// <lu>определяет реальный объект, представленный заместителем</lu>
  /// </li>
  /// </remarks>
  class Math : IMath
  {
    public Math()
    {
        Console.WriteLine("Create object Math. Wait...");
        Thread.Sleep(1000);
    }

    public double Add(double x, double y){return x + y;}
    public double Sub(double x, double y){return x - y;}
    public double Mul(double x, double y){return x * y;}
    public double Div(double x, double y){return x / y;}
  }

  /// <summary>
  /// Proxy - заместитель
  /// </summary>
  /// <remarks>
  /// <li>
  /// <lu>хранит ссылку, которая позволяет заместителю обратиться к реальному
  /// субъекту. Объект класса <see cref="MathProxy"/> может обращаться к объекту класса
  /// <see cref="IMath"/>, если интерфейсы классов <see cref="Math"/> и <see cref="IMath"/> одинаковы;</lu>
  /// <lu>предоставляет интерфейс, идентичный интерфейсу <see cref="IMath"/>, так что заместитель
  /// всегда может быть предоставлен вместо реального субъекта;</lu>
  /// <lu>контролирует доступ к реальному субъекту и может отвечать за его создание 
  /// и удаление;</lu>
  /// <lu>прочие обязанности зависят от вида заместителя:
  /// <li>
  /// <lu><b>удаленный заместитель</b> отвечает за кодирование запроса и его аргументов
  /// и отправление закодированного запроса реальному субъекту в
  /// другом адресном пространстве;</lu>
  /// <lu><b>виртуальный заместитель</b> может кэшировать дополнительную информацию
  /// о реальном субъекте, чтобы отложить его создание.</lu>
  /// <lu><b>защищающий заместитель</b> проверяет, имеет ли вызывающий объект 
  /// необходимые для выполнения запроса права;</lu>
  /// </li>
  /// </lu>
  /// </li>
  /// </remarks>
  class MathProxy : IMath
  {
    Math math;

    public MathProxy()
    {
      math = null;
    }

    /// <summary>
    /// Быстрая операция - не требует реального субъекта
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public double Add(double x, double y)
    {
      return x + y;
    }

    public double Sub(double x, double y)
    {
      return x - y;
    }

    /// <summary>
    /// Медленная операция - требует создания реального субъекта
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public double Mul(double x, double y)
    {
      if (math == null)
          math = new Math();
      return math.Mul(x, y);
    }

    public double Div(double x, double y)
    {
      if (math == null)
          math = new Math();
      return math.Div(x, y);
    }
  }