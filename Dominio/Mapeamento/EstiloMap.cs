using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Dominio.Model;

namespace Dominio.Mapeamento
{
    public class EstiloMap : ClassMapping<Estilo>
    {
        public EstiloMap()
        {
            Table("ESTILO");
            Id(estilo => estilo.Id, map => {
                map.Column("ID");
                map.Generator(Generators.Identity);
            });

            Property(estilo => estilo.Descricao, map => map.Column("DESCRICAO"));
        }
    }
}
