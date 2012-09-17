using Dominio.Simples.Model;
using Dominio.Simples.Util;
using System;
using System.Collections.Generic;

namespace PopulateApp.Repositorio.Simples
{
    public class AlbumRepositorio : IReositorio<Album>
    {
        private const int MAX_QTD_ALBUNS_INSERIR_POR_ARTISTA = 50;

        public void Inserir()
        {
            throw new NotImplementedException();
        }

        public int Contar(Func<Album, bool> expression)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Func<Album, bool> expression)
        {
            throw new NotImplementedException();
        }

        public Album Editar(Func<Album, bool> expression)
        {
            throw new NotImplementedException();
        }

        public List<Album> Pesquisar(Func<Album, bool> expression)
        {
            throw new NotImplementedException();
        }

        public static IList<Album> GetAlbuns(Artista artista)
        {
            var qtdAlubunsInseridos = 0;
            var random = new Random(DateTime.Now.Millisecond);
            var qtdAlbunsInsert = random.Next(1, MAX_QTD_ALBUNS_INSERIR_POR_ARTISTA);
            var albuns = new List<Album>();

            do
            {
                var album = new Album
                {
                    Artista = artista,
                    Avaliacao = random.Next(1, 10),
                    Capa = String.Format("path-capa-album-{0}", DateTime.Now.Ticks),
                    DataLancamento = DateTime.Today.AddMonths(random.Next(1, 240)),
                    Titulo = String.Format("Titulo do Album {0}", DateTime.Now.Ticks)
                };

                album.Musicas = MusicaRepositorio.GetMusicas(album);
                albuns.Add(album);
                qtdAlubunsInseridos++;

            } while (qtdAlubunsInseridos < qtdAlbunsInsert);

            return albuns;
        }
    }
}
