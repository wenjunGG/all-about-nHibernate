using Dominio.Simples.Model.Interfaces;

namespace Dominio.Simples.Model
{
    public class Estilo : IEstilo
    {
        public virtual int Id { set; get; }
        public virtual string Descricao { set; get; }
    }
}