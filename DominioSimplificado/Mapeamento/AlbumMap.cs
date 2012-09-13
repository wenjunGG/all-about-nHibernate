﻿using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Dominio.Simples.Model;

namespace Dominio.Simples.Mapeamento
{
    public class AlbumMap : ClassMapping<Album>
    {
        public AlbumMap()
        {
            Table("ALBUM");
            Id(album => album.Id, map => {
                map.Column("ID");
                map.Generator(Generators.Identity);
            });

            ManyToOne(album => album.Artista, map => {
                map.Column("artista_id");
                map.Cascade(Cascade.None);
                map.Lazy(LazyRelation.Proxy);
                map.Fetch(FetchKind.Select);
            });
            
            Property(album => album.Avaliacao, map => map.Column("AVALIACAO"));
            Property(album => album.Capa, map => map.Column("CAPA"));
            Property(album => album.DataLancamento, map => map.Column("DATALANCAMENTO"));
            Property(album => album.Titulo, map => map.Column("TITULO"));

            Bag(album => album.Musicas, map => {
                map.Key(k => k.Column("ALBUM_ID"));
                map.Cascade(Cascade.All);
                map.Inverse(true);
                map.Lazy(CollectionLazy.NoLazy);
                map.Fetch(CollectionFetchMode.Join);
                map.BatchSize(100);
            }, relacao => relacao.OneToMany());
        }
    }
}