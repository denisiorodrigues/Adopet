using Alura.Adopet.Console.Modelo;

namespace Alura.Adopet.Test.DataBuilder
{
    public static class PetBuilder
    {
        public static List<Pet> GetMock()
        { 
            return new List<Pet>()
            {
                new Pet( Guid.NewGuid(), "Lima Limão", TipoPet.Cachorro),
                new Pet( Guid.NewGuid(), "Spike", TipoPet.Cachorro)
            };
        }
    }
}
