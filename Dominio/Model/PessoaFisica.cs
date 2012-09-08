using System;

namespace Dominio.Model
{
    public class PessoaFisica : Pessoa
    {
        public virtual string Nome { set; get; }
        public virtual string Sobrenome { set; get; }
        public virtual char Sexo { set; get; }
        public virtual string Cpf { set; get; }
        public virtual DateTime DataNascimento { set; get; }
    }
}
