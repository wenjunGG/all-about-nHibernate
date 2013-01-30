using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Dominio.Model;
using System.Collections.Generic;

namespace Persistence.Nh.MapByCode
{
    public class ArtistaMap : ClassMapping<Artista>
    {
        public ArtistaMap()
        {
            Table("ARTISTA");
            Id(artista => artista.Id, map => {
                map.Column("ID");
                map.Generator(Generators.Identity);
            });

            Property(artista => artista.Nome, map => map.Column("NOME"));
            Property(artista => artista.Sobrenome, map => map.Column("SOBRENOME"));
            Property(artista => artista.DataNascimento, map => map.Column("DATANASCIMENTO"));

            ManyToOne(artista => artista.Cidade, map => {
                map.Column("CIDADE_ID");
                map.Lazy(LazyRelation.NoLazy);
                map.Fetch(FetchKind.Join);
                map.Cascade(Cascade.None);
            });

            Bag(artista => artista.Albuns, map => {
                map.Key(foreignKey => foreignKey.Column("ARTISTA_ID"));
                map.Cascade(Cascade.All);
                map.Lazy(CollectionLazy.NoLazy);
                map.Fetch(CollectionFetchMode.Join);
                map.Inverse(true);
                map.BatchSize(100);
            }, relacao => relacao.OneToMany());

            Bag(artista => artista.Estilos, map => {
                map.Table("ESTILOARTISTA");
                map.Key(fk => fk.Column("ARTISTA_ID"));
                map.Cascade(Cascade.All);
                map.Fetch(CollectionFetchMode.Join);
                map.Lazy(CollectionLazy.NoLazy);
            }, relacao => relacao.ManyToMany(estilo => estilo.Column("ESTILO_ID")));
        }
    }
}
