using Dominio.Simples.Model;
using System;
using System.Collections.Generic;

namespace PopulateApp.Repositorio.Simples
{
    public class MusicaRepositorio : IReositorio<Musica>
    {
        private const int MAX_QTD_MUSICA_POR_ALBUM = 30;
        private const int MIN_QTD_MUSICA_POR_ALBUM = 10;

        public void Inserir()
        {
            throw new NotImplementedException();
        }

        public int Contar(Func<Musica, bool> expression)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Func<Musica, bool> expression)
        {
            throw new NotImplementedException();
        }

        public Musica Editar(Func<Musica, bool> expression)
        {
            throw new NotImplementedException();
        }

        public List<Musica> Pesquisar(Func<Musica, bool> expression)
        {
            throw new NotImplementedException();
        }

        public static IList<Musica> GetMusicas(Album album)
        {
            var musicas = new List<Musica>();
            var random = new Random(DateTime.Now.Millisecond);
            var qtdMusicasInseridas = 0;
            var qtdMusicasInserir = random.Next(MIN_QTD_MUSICA_POR_ALBUM, MAX_QTD_MUSICA_POR_ALBUM);

            do
            {
                musicas.Add(new Musica
                {
                    Album = album,
                    Avaliacao = random.Next(10),
                    DuracaoSegundos = random.Next(90, 320),
                    Titulo = String.Format("Nome musica {0}", DateTime.Now.Ticks)
                });

                qtdMusicasInseridas++;
            } while (qtdMusicasInseridas < qtdMusicasInserir);

            return musicas;
        }
    }
}
