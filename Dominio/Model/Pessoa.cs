namespace Dominio.Model
{
    public abstract class Pessoa
    {
        public virtual int Id { set; get; }
        public virtual string Endereco { set; get; }
        public virtual Contato Contato { set; get; }
    }
}
