using System;

namespace Decorator
{
    class MainApp
    {
        static void Main()
        {
            // Create ConcreteComponent and two Decorators
            ConcreteComponent c = new ConcreteComponent();
            ConcreteDecoratorA dA = new ConcreteDecoratorA();
            ConcreteDecoratorB dB = new ConcreteDecoratorB();

            // Link decorators
            dA.SetComponent(c);
            dB.SetComponent(dA);

            dA.Operation();

            Console.WriteLine();

            dB.Operation();

            // Wait for user
            Console.Read();
        }
    }

    /// <summary>
    /// Component - компонент
    /// </summary>
    /// <remarks>
    /// <li>
    /// <lu>определяем интерфейс для объектов, на которые могут быть динамически 
    /// возложены дополнительные обязанности;</lu>
    /// </li>
    /// </remarks>
    abstract class Component
    {
        public abstract void Operation();
    }

    /// <summary>
    /// ConcreteComponent - конкретный компонент
    /// </summary>
    /// <remarks>
    /// <li>
    /// <lu>определяет объект, на который возлагается дополнительные обязанности</lu>
    /// </li>
    /// </remarks>
    class ConcreteComponent : Component
    {
        public override void Operation()
        {
            Console.Write("Привет");
        }
    }

    /// <summary>
    /// Decorator - декоратор
    /// </summary>
    /// <remarks>
    /// <li>
    /// <lu>хранит ссылку на объект <see cref="Component"/> и определяет интерфейс,
    /// соответствующий интерфейсу <see cref="Component"/></lu>
    /// </li>
    /// </remarks>
    abstract class Decorator : Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }

        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    /// <summary>
    /// ConcreteDecoratorA - конкретный декоратор
    /// </summary>
    /// <remarks>
    /// <li>
    /// <lu>Выполняет основную задачу</lu>
    /// </li>
    /// </remarks>
    class ConcreteDecoratorA : Decorator
    {
        public override void Operation()
        {
            base.Operation();
        }
    }

    /// <summary>
    /// ConcreteDecorator - конкретный декоратор
    /// </summary>
    /// <remarks>
    /// <li>
    /// <lu>Выполняет основную задачу + дополнительную</lu>
    /// </li>
    /// </remarks>
    class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            base.Operation();

            Console.Write(" Мир!");
        }
    }
}