using Dominio.Model;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Persistence.Nh.MapByCode
{
    public class PessoaJuridicaMap : SubclassMapping<PessoaJuridica>
    {
        public PessoaJuridicaMap()
        {
            DiscriminatorValue("J");
            Property(pessoa => pessoa.Cnpj, map => map.Column("CNPJ"));
            Property(pessoa => pessoa.DataAbertura, map =>map.Column("DATAABERTURA"));
            Property(pessoa => pessoa.NomeFantasia, map => map.Column("NOMEFANTASIA"));
            Property(pessoa => pessoa.RazaoSocial, map => map.Column("RAZAOSOCIAL"));
        }
    }
}
