using System;

namespace Dominio.Model
{
    public class Usuario
    {
        public virtual int Id { set; get; }
        public virtual string Login { set; get; }
        public virtual string Senha { set; get; }
        public virtual DateTime UltimoAcesso { set; get; }
        public virtual Pessoa Pessoa { set; get; }
    }
}
