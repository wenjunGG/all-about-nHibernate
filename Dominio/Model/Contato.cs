namespace Dominio.Model
{
    public class Contato
    {
        public virtual Pessoa Pessoa { set; get; }
        public virtual int Id { set; get; }
        public virtual string Celular { set; get; }
        public virtual string Email { set; get; }
        public virtual string Fone { set; get; }
        public virtual string Site { set; get; }
    }
}