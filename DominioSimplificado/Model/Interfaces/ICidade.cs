
namespace Dominio.Simples.Model.Interfaces
{
    public interface ICidade : IEntityId
    {
        string Nome { get; set; }
        string Uf { get; set; }
    }
}
