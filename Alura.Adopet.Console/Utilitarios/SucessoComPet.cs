using Alura.Adopet.Console.Modelo;
using FluentResults;

namespace Alura.Adopet.Console.Utilitarios;

public class SucessoComPet : Success
{
    public IEnumerable<Pet> Data { get; set; }

    public SucessoComPet(IEnumerable<Pet> listaDePets)
    {
        Data = listaDePets;
    }

    public SucessoComPet(IEnumerable<Pet> listaDePets, string mensagemDeRetorno)
        :base(mensagemDeRetorno)
    {
        Data = listaDePets;
    }
}
