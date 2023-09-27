using Adopet.Console.Classes;

namespace Adopet.Console.Commands;

[DocCommand(instruction: "show",
    documentation: "adopet show <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.")]
public class Show : ICommand
{
    public Task ExecuteAsync(string[] args)
    {
        var listPets = new LeitorArquivo().LerArquivo(args[1]);

        foreach (var pet in listPets) System.Console.WriteLine(pet);

        return Task.CompletedTask;
    }
}