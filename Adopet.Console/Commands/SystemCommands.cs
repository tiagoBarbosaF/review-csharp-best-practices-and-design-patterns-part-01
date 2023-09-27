namespace Adopet.Console.Commands;

public class SystemCommands
{
    private readonly Dictionary<string, ICommand> _systemCommands = new()
    {
        { "help", new Help() },
        { "import", new Import() },
        { "show", new Show() },
        { "list", new List() }
    };

    public ICommand this [string key] => _systemCommands.TryGetValue(key, out var value) ? value : null;
}