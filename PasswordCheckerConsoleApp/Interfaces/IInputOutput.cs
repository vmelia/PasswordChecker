namespace PasswordCheckerConsoleApp.Interfaces;

public interface IInputOutput
{
    public string? ReadLine();
    public void WriteLine(string? value);
}