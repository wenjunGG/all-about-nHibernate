using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Dominio.Simples.Model;

namespace Dominio.Simples.Mapeamento
{
    public class MusicaMap : ClassMapping<Musica>
    {
        public MusicaMap()
        {
            Table("MUSICA");
            Id(musica => musica.Id, map => {
                map.Column("ID");
                map.Generator(Generators.Identity);
            });

            ManyToOne(musica => musica.Album, map => {
                map.Column("album_id");
                map.Cascade(Cascade.None);
                map.Lazy(LazyRelation.NoLazy);
                map.Fetch(FetchKind.Join);
            });

            Property(musica => musica.Avaliacao, map => map.Column("AVALIACAO"));
            Property(musica => musica.DuracaoSegundos, map => map.Column("DURACAOSEGUNDOS") );
            Property(musica => musica.Titulo, map => map.Column("TITULO"));
        }
    }
}
