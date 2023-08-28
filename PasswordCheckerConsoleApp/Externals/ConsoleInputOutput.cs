using PasswordCheckerConsoleApp.Interfaces;

namespace PasswordCheckerConsoleApp.Externals;

public class ConsoleInputOutput : IInputOutput
{
    public string? ReadLine() => Console.ReadLine();
    public void WriteLine(string? value) => Console.WriteLine(value);
}