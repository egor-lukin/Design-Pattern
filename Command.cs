using System;
using System.Collections.Generic;

namespace Command
{

  class MainApp
  {
    static void Main()
    {
      // Создаем пользователя.
      User user = new User();

      // Пусть он что-нибудь сделает.
      user.Compute('+', 100);
      user.Compute('-', 50);
      user.Compute('*', 10);
      user.Compute('/', 2);

      // Отменяем 4 команды
      user.Undo(4);

      // Вернём 3 отменённые команды.
      user.Redo(3);

      // Ждем ввода пользователя и завершаемся.
      Console.Read();
    }
  }

  // "Command" : абстрактная Команда

  abstract class Command
  {
    public abstract void Execute();
    public abstract void UnExecute();
  }

  // "ConcreteCommand" : конкретная команда

  class CalculatorCommand : Command
  {
    char @operator;
    int operand;
    Calculator calculator;

    // Constructor
    public CalculatorCommand(Calculator calculator,
      char @operator, int operand)
    {
      this.calculator = calculator;
      this.@operator = @operator;
      this.operand = operand;
    }

    public char Operator
    {
      set{ @operator = value; }
    }

    public int Operand
    {
      set{ operand = value; }
    }

    public override void Execute()
    {
      calculator.Operation(@operator, operand);
    }

    public override void UnExecute()
    {
      calculator.Operation(Undo(@operator), operand);
    }

    // Private helper function : приватные вспомогательные функции
    private char Undo(char @operator)
    {
      char undo;
      switch(@operator)
      {
        case '+': undo = '-'; break;
        case '-': undo = '+'; break;
        case '*': undo = '/'; break;
        case '/': undo = '*'; break;
        default : undo = ' '; break;
      }
      return undo;
    }
  }

  // "Receiver" : получатель

  class Calculator
  {
    private int curr = 0;

    public void Operation(char @operator, int operand)
    {
      switch(@operator)
      {
        case '+': curr += operand; break;
        case '-': curr -= operand; break;
        case '*': curr *= operand; break;
        case '/': curr /= operand; break;
      }
      Console.WriteLine(
        "Current value = {0,3} (following {1} {2})",
        curr, @operator, operand);
    }
  }

  // "Invoker" : вызывающий

  class User
  {
    // Initializers
    private Calculator _calculator = new Calculator();
    private List<Command> _commands = new List<Command>();

    private int _current = 0;

    public void Redo(int levels)
    {
      Console.WriteLine("\n---- Redo {0} levels ", levels);

      // Делаем возврат операций
      for (int i = 0; i < levels; i++)
        if (_current < _commands.Count)
          _commands[_current++].Execute();
    }

    public void Undo(int levels)
    {
      Console.WriteLine("\n---- Undo {0} levels ", levels);

      // Делаем отмену операций
      for (int i = 0; i < levels; i++)
        if (_current > 0)
          _commands[--_current].UnExecute();
    }

    public void Compute(char @operator, int operand)
    {

      // Создаем команду операции и выполняем её
      Command command = new CalculatorCommand(
        _calculator, @operator, operand);
      command.Execute();

	if (_current < _commands.Count)
	{
	    // если "внутри undo" мы запускаем новую операцию, 
	    // надо обрубать список команд, следующих после текущей, 
	    // иначе undo/redo будут некорректны
		_commands.RemoveRange(_current, _commands.Count - _current);
	}

      // Добавляем операцию к списку отмены
      _commands.Add(command);
      _current++;
    }
  }
}
