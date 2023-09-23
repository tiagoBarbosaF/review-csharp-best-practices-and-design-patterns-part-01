namespace Adopet.Console.Classes;

public class Help
{
    public void CallHelpCommandList(string[] command)
    {
        System.Console.WriteLine("== Command lists ==\n");
        switch (command.Length)
        {
            // se não passou mais nenhum argumento mostra help de todos os comandos
            case 1:
                System.Console.WriteLine($"- adopet help <parametro> ou simplemente adopet help " +
                                         "comando que exibe informações de ajuda dos comandos.\n\n" +
                                         "Adopet (1.0) - Aplicativo de linha de comando (CLI).\n" +
                                         "- Realiza a importação em lote de um arquivos de pets.\n\n" +
                                         "Comandos possíveis:\n" +
                                         "- adopet import <arquivo> comando que realiza a importação do arquivo de pets.\n" +
                                         "- adopet show <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.\n" +
                                         "- Execute 'adopet.exe help [comando]' para obter mais informações sobre um comando.\n");
                // System.Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
                // System.Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");
                // System.Console.WriteLine("Comando possíveis:");
                // System.Console.WriteLine($"adopet import <arquivo> comando que realiza a importação do arquivo de pets.");
                // System.Console.WriteLine(
                //     $"adopet show   <arquivo> comando que exibe no terminal o conteúdo do arquivo importado." +
                //     "\n\n\n\n");
                // System.Console.WriteLine("Execute 'adopet.exe help [comando]' para obter mais informações sobre um comando." +
                //                          "\n\n\n");
                break;
            // exibe o help daquele comando específico
            case 2:
            {
                if (command[1].Equals("import"))
                    System.Console.WriteLine("Import commands:\n" +
                                             "- adopet import <arquivo> : comando que realiza a importação do arquivo de pets.");

                if (command[1].Equals("show"))
                    System.Console.WriteLine("Show commands:\n" +
                                             "- adopet show <arquivo> : comando que exibe no terminal o conteúdo do arquivo importado.");

                break;
            }
        }
    }
}