using System.Reflection;
using Adopet.Console.Classes;

namespace Adopet.Console.Commands;

[DocCommand(instruction: "help", documentation: "adopet help <parametro> exibe informações de ajuda.\n" +
                                                "\t adopet help <nome_comando> para acessar o help de um comando específico.")]
public class Help : ICommand
{
    private readonly Dictionary<string, DocCommandAttribute> docs;
    
    public Help()
    {
        docs = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetCustomAttributes<DocCommandAttribute>().Any())
            .Select(t => t.GetCustomAttribute<DocCommandAttribute>()!)
            .ToDictionary(d => d.Instruction);
    }
    
    public Task ExecuteAsync(string[] args)
    {
        System.Console.WriteLine("== Command lists ==\n");
        switch (args.Length)
        {
            case 1:
                foreach (var doc in docs) System.Console.WriteLine($" - {doc.Key}: {doc.Value.Documentation}");
                break;
            case 2:
                var commandToShow = args[1];
                var commandList = docs[commandToShow];
                System.Console.WriteLine($"- {commandList.Instruction}: {commandList.Documentation}");
                break;
        }
        
        return Task.CompletedTask;
    }

}