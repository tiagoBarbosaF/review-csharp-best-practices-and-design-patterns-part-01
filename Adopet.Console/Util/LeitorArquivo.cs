namespace Adopet.Console.Classes;

public class LeitorArquivo
{
    public List<Pet> LerArquivo(string filePath)
    {
        var listPets = new List<Pet>();
        using (StreamReader sr = new StreamReader(filePath))
        {
            System.Console.WriteLine("----- Serão importados os dados abaixo -----");
            while (!sr.EndOfStream)
            {
                var propriedades = sr.ReadLine().Split(';');
                var pet = new Pet(Guid.Parse(propriedades[0]),
                    propriedades[1],
                    TipoPet.Cachorro
                );
                listPets.Add(pet);
            }
        }

        return listPets;
    }
}