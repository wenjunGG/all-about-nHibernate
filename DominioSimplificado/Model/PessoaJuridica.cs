using System;

namespace Dominio.Simples.Model
{
    public class PessoaJuridica : Pessoa
    {
        public virtual string RazaoSocial { set; get; }
        public virtual string NomeFantasia { set; get; }
        public virtual string Cnpj { set; get; }
        public virtual DateTime DataAbertura { set; get; }
    }
}