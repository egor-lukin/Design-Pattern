using System;

namespace DesignPatterns.Behavioral.Strategy
{
    // Класс реализующий конкретную стратегию, должен наследовать этот интерфейс
    // Класс контекста использует этот интерфейс для вызова конкретной стратегии
    public interface IStrategy
    {
        void Algorithm();
    }

    // Первая конкретная реализация-стратегия.
    public class ConcreteStrategy1 : IStrategy
    {
        public void Algorithm()
        {
            Console.WriteLine("Выполняется алгоритм стратегии 1.");
        }
    }

    // Вторая конкретная реализация-стратегия.
    // Реализаций может быть сколько угодно много.
    public class ConcreteStrategy2 : IStrategy
    {
        public void Algorithm()
        {
            Console.WriteLine("Выполняется алгоритм стратегии 2.");
        }
    }

    // Контекст, использующий стратегию для решения своей задачи.
    public class Context
    {
        // Ссылка на интерфейс IStrategy
        // позволяет автоматически переключаться между конкретными реализациями
        // (другими словами, это выбор конкретной стратегии).
        private IStrategy _strategy;

        // Конструктор контекста.
        // Инициализирует объект стратегией.
        public Context(IStrategy strategy)
        {
            _strategy = strategy;
        }

        // Метод для установки стратегии.
        // Служит для смены стратегии во время выполнения.
        // В C# может быть реализован также как свойство записи.
        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        // Некоторая функциональность контекста, которая выбирает
        //стратегию и использует её для решения своей задачи.
        public void ExecuteOperation()
        {
            _strategy.Algorithm();
        }
    }

    // Класс приложения.
    // В данном примере выступает как клиент контекста.
    public static class Program
    {
        // <summary>
        // Точка входа в программу.
        // </summary>
        public static void Main()
        {
            // Создаём контекст и инициализируем его первой стратегией.
            Context context = new Context(new ConcreteStrategy1());
            // Выполняем операцию контекста, которая использует первую стратегию.
            context.ExecuteOperation();
            // Заменяем в контексте первую стратегию второй.
            context.SetStrategy(new ConcreteStrategy2());
            // Выполняем операцию контекста, которая теперь использует вторую стратегию.
            context.ExecuteOperation();
        }
    }
}
