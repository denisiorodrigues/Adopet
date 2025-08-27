using System.Collections.ObjectModel;
using Alura.Adopet.Console.Modelo;

namespace Alura.Adopet.Console.Utilitarios;

public class LeitorDeArquivos
{
    public ICollection<Pet> RealizarLeitura(string caminhoDoArquivoASerLido)
    {
        var pets = new Collection<Pet>();
        
        using (StreamReader sr = new StreamReader(caminhoDoArquivoASerLido))
        {
            while (!sr.EndOfStream)
            {
                // separa linha usando ponto e vírgula
                string[] propriedades = sr.ReadLine().Split(';');
                Pet pet = new Pet(Guid.Parse(propriedades[0]),
                    propriedades[1],
                    TipoPet.Cachorro
                );
                pets.Add(pet);
            }

            return pets;
        }
    }
}