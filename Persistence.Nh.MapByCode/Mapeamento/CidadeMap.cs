using Dominio.Model;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Persistence.Nh.MapByCode
{
    public class CidadeMap : ClassMapping<Cidade>
    {
        public CidadeMap()
        {
            Table("CIDADE");
            Id(cidade => cidade.Id, map =>
                {
                    map.Column("ID");
                    map.Generator(Generators.Identity);
                });

            Property(cidade => cidade.Nome, map => map.Column("NOME"));
            Property(cidade => cidade.Uf, map => map.Column("UF"));
        }
    }
}
