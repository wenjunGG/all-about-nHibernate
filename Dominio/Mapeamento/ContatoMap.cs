using Dominio.Model;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Dominio.Mapeamento
{
    public class ContatoMap : ClassMapping<Contato>
    {
        public ContatoMap()
        {
            Table("CONTATO");
            Id(contato => contato.Id, map => {
                map.Column("ID");
                map.Generator(Generators.Foreign<Contato>(c => c.Pessoa));
            });

            Property(contato => contato.Celular, map => map.Column("CELULAR"));
            Property(contato => contato.Email, map => map.Column("EMAIL"));
            Property(contato => contato.Fone, map => map.Column("FONE"));
            Property(contato => contato.Site, map=>map.Column("SITE"));

            OneToOne(contato => contato.Pessoa, map =>
            {
                map.Lazy(LazyRelation.NoLazy);
                map.Cascade(Cascade.None);
                map.Constrained(true);
            });
        }
    }
}
