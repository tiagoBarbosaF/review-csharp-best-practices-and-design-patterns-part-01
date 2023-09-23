using Adopet.Console.Classes;

Console.ForegroundColor = ConsoleColor.Green;
try
{
    var command = args[0].Trim();
    switch (command)
    {
        case "import":
            await new Import().FilePathToImportAsync(filePathToImport: args[1]);
            break;
        case "help":
            new Help().CallHelpCommandList(command:args);
            break;
        case "show":
            new Show().FilePathToShow(filePathToShow:args[1]);
            break;
        case "list":
            await new List().ListAllPetsAsync();
            break;
        default:
            Console.WriteLine("Comando inválido!");
            break;
    }
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