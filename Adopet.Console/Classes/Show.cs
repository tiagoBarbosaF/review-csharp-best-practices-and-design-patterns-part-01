namespace Adopet.Console.Classes;

public class Show
{
    public void FilePathToShow(string filePathToShow)
    {
        using (StreamReader sr = new StreamReader(filePathToShow))
        {
            System.Console.WriteLine("----- Serão importados os dados abaixo -----");
            while (!sr.EndOfStream)
            {
                var propriedades = sr.ReadLine().Split(';');
                var pet = new Pet(Guid.Parse(propriedades[0]),
                    propriedades[1],
                    TipoPet.Cachorro
                );
                System.Console.WriteLine(pet);
            }
        }
    }
}