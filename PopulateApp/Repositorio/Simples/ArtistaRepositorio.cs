using Dominio.Simples.Model;
using Dominio.Simples.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
using NHibernate;
using Dominio.Simples.Model.Interfaces;

namespace PopulateApp.Repositorio.Simples
{
    public class ArtistaRepositorio : IReositorio<Artista>
    {
        private const int QTD_ARTISTA_INSERT = 500;
        private Random _geradorRandom;

        public void Inserir()
        {
            using (var session = NHibernateSession.OpenSession())
            {
                var tran = session.BeginTransaction();
                var qtdArtistasInseridos = 0;
                _geradorRandom = new Random(DateTime.Now.Millisecond);

                try
                {
                    do
                    {
                        List<Estilo> estilos = EstiloRepositorio.GetEstilos(session);
                        Cidade cidade = CidadeRepositorio.GetCidade(session);

                        var artista = new Artista
                        {
                            Cidade = cidade,
                            DataNascimento = DateTime.Now.AddMonths(_geradorRandom.Next(240) * -1),
                            Estilos = (IList<IEstilo>)estilos,
                            Nome = String.Format("Artista Nome {0}", DateTime.Now.Ticks),
                            Sobrenome = String.Format("Artista Sobrenome {0}", DateTime.Now.Ticks)
                        };

                        artista.Albuns = (List<IAlbum>)AlbumRepositorio.GetAlbuns(artista);

                        session.Save(artista);
                        qtdArtistasInseridos++;
                        Console.WriteLine(String.Format("QTD ARTISTA: {0}", qtdArtistasInseridos));
                    } while (qtdArtistasInseridos < QTD_ARTISTA_INSERT);

                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        public int Contar(Func<Artista, bool> expression)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Func<Artista, bool> expression)
        {
            throw new NotImplementedException();
        }

        public Artista Editar(Func<Artista, bool> expression)
        {
            throw new NotImplementedException();
        }

        public List<Artista> Pesquisar(Func<Artista, bool> expression)
        {
            throw new NotImplementedException();
        }

        public static Artista GetArtista(ISession session)
        {
            throw new NotImplementedException();
        }

        public static int Count(ISession session)
        {
            throw new NotImplementedException();
        }
    }
}
