using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Dominio.Model;

namespace Dominio.Mapeamento
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

            //ManyToOne(pessoa => pessoa.Contato, map => {
            //    map.Cascade(Cascade.All);
            //    map.Lazy(LazyRelation.NoLazy);
            //    map.Unique(true);
            //});

            OneToOne(pessoa => pessoa.Contato, map =>
            {
                //map.Cascade(Cascade.Persist);
                //map.Constrained(true);
                //map.Lazy(LazyRelation.Proxy); // or .NoProxy, .NoLazy
                //map.PropertyReference(typeof(Contato).GetPropertyOrFieldMatchingName("Pessoa"));
                //map.OptimisticLock(true);
                ////map.Formula("arbitrary SQL expression");
                //map.Access(Accessor.Field);

                map.Lazy(LazyRelation.NoLazy);
                map.Cascade(Cascade.Persist);
            });

            Discriminator(map => map.Column("TIPO"));
        }
    }
}
