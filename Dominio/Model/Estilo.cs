using Dominio.Model.Interfaces;

namespace Dominio.Model
{
    public class Estilo : IEstilo
    {
        public virtual int Id { set; get; }
        public virtual string Descricao { set; get; }
    }
}