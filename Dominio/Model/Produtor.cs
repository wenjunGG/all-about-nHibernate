
namespace Dominio.Model
{
    public class Produtor
    {
        public virtual int Id { set; get; }
        public virtual string Cargo { set; get; }
        public virtual decimal Comissao { set; get; }
        public virtual decimal Salario { set; get; }
        public virtual string Tipo { set; get; }
        public virtual Pessoa Pessoa { set; get; }
    }
}