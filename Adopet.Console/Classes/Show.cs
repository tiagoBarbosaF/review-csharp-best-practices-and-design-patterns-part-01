namespace Adopet.Console.Classes;

[DocCommand(instruction:"show",documentation:"adopet show <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.")]
public class Show
{
    public void FilePathToShow(string filePathToShow)
    {
        var listPets = new LeitorArquivo().LerArquivo(filePathToShow);

        foreach (var pet in listPets) System.Console.WriteLine(pet);
    }
}