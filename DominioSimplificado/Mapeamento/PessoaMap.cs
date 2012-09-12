using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Dominio.Simples.Model;

namespace Dominio.Simples.Mapeamento
{
    public class PessoaMap : ClassMapping<Pessoa>
    {
        public PessoaMap()
        {
            Table("PESSOA");
            Id(pessoa => pessoa.Id, map =>

            {
                map.Generator(Generators.Identity);
                map.Column("ID");
            });

            Property(pessoa => pessoa.Endereco, map => map.Column("ENDERECO"));
            Discriminator(map => map.Column("TIPO"));
        }
    }
}
