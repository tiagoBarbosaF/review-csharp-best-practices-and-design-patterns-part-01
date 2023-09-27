using Adopet.Console.Commands;

Console.ForegroundColor = ConsoleColor.Green;

var systemCommands = new SystemCommands();

try
{
    var command = args[0].Trim();
    var systemCommandsToExecute = systemCommands[command];

    if (systemCommandsToExecute is not null)
        await systemCommandsToExecute.ExecuteAsync(args);
    else
        Console.WriteLine("Invalid command.");
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}