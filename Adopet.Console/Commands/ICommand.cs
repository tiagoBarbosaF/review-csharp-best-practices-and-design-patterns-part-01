namespace Adopet.Console.Commands;

public interface ICommand
{
    Task ExecuteAsync(string[] args);
}