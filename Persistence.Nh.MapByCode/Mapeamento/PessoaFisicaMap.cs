﻿using Dominio.Model;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Persistence.Nh.MapByCode
{
    public class PessoaFisicaMap : SubclassMapping<PessoaFisica>
    {
        public PessoaFisicaMap()
        {
            DiscriminatorValue("F");
            Property(pessoa => pessoa.Cpf, map => map.Column("CPF"));
            Property(pessoa => pessoa.DataNascimento, map => map.Column("DATANASCIMNENTO"));
            Property(pessoa => pessoa.Nome, map => map.Column("NOME"));
            Property(pessoa => pessoa.Sobrenome, map => map.Column("SOBRENOME"));
            Property(pessoa => pessoa.Sexo, map => map.Column("SEXO"));
        }
    }
}