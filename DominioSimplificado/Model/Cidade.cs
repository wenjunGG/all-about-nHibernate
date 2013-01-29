using Dominio.Simples.Model.Interfaces;

namespace Dominio.Simples.Model
{
    public class Cidade : ICidade
    {
        public virtual int Id { get; set; }
        public virtual string Nome { set; get; }
        public virtual string Uf { set; get; }
    }
}