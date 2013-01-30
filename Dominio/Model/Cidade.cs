using Dominio.Model.Interfaces;

namespace Dominio.Model
{
    public class Cidade : ICidade
    {
        public virtual int Id { get; set; }
        public virtual string Nome { set; get; }
        public virtual string Uf { set; get; }
    }
}