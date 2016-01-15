using System;
namespace MementoPatte
{
    class Program
    {
        static void Main(string[] args)
        {
            Foo foo = new Foo("Test", 15);
            foo.Print();
            Caretaker ct1 = new Caretaker();
            Caretaker ct2 = new Caretaker();
            ct1.SaveState(foo);
            foo.IntProperty += 152;
            foo.Print();
            ct2.SaveState(foo);
            ct1.RestoreState(foo);
            foo.Print();
            ct2.RestoreState(foo);
            foo.Print();
            Console.ReadKey();
        }
    }

    public interface IOriginator
    {
        object GetMemento();
        void SetMemento(object memento);
    }

    public class Foo 
        : IOriginator
    {
        public string StringProperty
        {
            get;
            private set;
        }

        public int IntProperty
        {
            get;
            set;
        }

        public Foo(string stringPropertyValue, int intPropertyValue = 0)
        {
            StringProperty = stringPropertyValue;
            IntProperty = intPropertyValue;
        }
       
        public void Print()
        {
           Console.WriteLine("=============");
           Console.WriteLine("StringProperty value: {0}",StringProperty);
           Console.WriteLine("IntProperty value: {0}",IntProperty);
           Console.WriteLine("=============");
        }
        object IOriginator.GetMemento()
        {
            return new Foo { StringProperty = this.StringProperty, IntProperty = this.IntProperty };

        }

        void IOriginator.SetMemento(object memento)
        {
            if (Object.ReferenceEquals(memento, null))
                throw new ArgumentNullException("memento");
            if (!(memento is Foo))
                throw new ArgumentException("memento");
            StringProperty = ((Memento)memento).StringProperty;
            IntProperty = ((Foo)memento).IntProperty;
        }

        class Memento
        {
            public string StringProperty
            {
                get;
                set;
            }

            public int IntProperty
            {
                get;
                set;
            }
        }
    }

    public class Caretaker
    {
        private object m_memento;
        public void SaveState(IOriginator originator)
        {
            if (originator == null)
                throw new ArgumentNullException("originator");
            m_memento = originator.GetMemento();
        }

        public void RestoreState(IOriginator originator)
        {
            if (originator == null)
                throw new ArgumentNullException("originator");
            if (m_memento == null)
                throw new InvalidOperationException("m_memento == null");
            originator.SetMemento(m_memento);
        }
    }
}
