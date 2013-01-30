using Dominio.Model;
using Dominio.Model.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Exceptions;
using Persistence.Nh.MapByCode;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominio.Test
{
    /// <summary>
    /// Summary description for PessoaCrudTests
    /// </summary>
    [TestClass]
    public class ArtistaCrudTests
    {
        private Cidade _cidade;
        private Artista _artista;
        private Album _album;
        private Musica _musica;
        private Estilo _estilo;

        public ArtistaCrudTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void TestInit() 
        {
            _cidade = new Cidade { Nome = "Nome Cidade", Uf= "PR" };
            
            _artista = new Artista { 
                DataNascimento = DateTime.Today,
                Nome = "Nome do Artista",
                Sobrenome = "Sobrenome do Artista"
            };

            _album = new Album { 
                Avaliacao = 5,
                Capa = "capa do album",
                DataLancamento = DateTime.Today,
                Titulo = "Titulo do album",
            };

            _musica = new Musica {
                Avaliacao = 3,
                DuracaoSegundos = 160,
                Titulo = "Tituloa da Musica"
            };

            _estilo = new Estilo { Descricao = "Estilo" };
        }
        
        //
        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void TestClean() 
        {
            _cidade = null;
            _artista = null;
            _album = null;
            _musica = null;
        }

        //
        #endregion

        [TestMethod]
        public void CreateArtitstaSaveSeparado()
        {
            using (var session = NHibernateSession.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    var cidade = _cidade;
                    session.Save(cidade);

                    var artista = _artista;
                    artista.Cidade = cidade;
                    
                    session.Save(artista);

                    Assert.IsTrue(cidade.Id > 0);
                    Assert.IsTrue(artista.Id > 0);

                    tran.Rollback();
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(GenericADOException))]
        public void CreateArtitstaSaveUnico()
        {
            using (var session = NHibernateSession.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    var artista = _artista;
                    artista.Cidade = _cidade;

                    session.Save(artista);
                    tran.Rollback();
                }
            }
        }

        [TestMethod]
        public void CreateAlbumSaveSeparado()
        {
            using (var session = NHibernateSession.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    var cidade = _cidade;
                    session.Save(cidade);

                    var artista = _artista;
                    artista.Cidade = _cidade;
                    session.Save(artista);

                    var album = _album;
                    _album.Artista = artista;
                    session.Save(album);

                    Assert.IsTrue(cidade.Id > 0);
                    Assert.IsTrue(artista.Id > 0);
                    Assert.IsTrue(album.Id > 0);
                    tran.Rollback();
                }
            }
        }

        [TestMethod]
        public void CreateAlbumSaveUnico()
        {
            using (var session = NHibernateSession.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    var cidade = _cidade;
                    session.Save(cidade);

                    var artista = _artista;
                    artista.Cidade = cidade;

                    artista.Albuns = new List<IAlbum>();
                    artista.Albuns.Add(_album);
                    _album.Artista = artista;

                    session.Save(artista);

                    Assert.IsTrue(cidade.Id > 0);
                    Assert.IsTrue(artista.Id > 0);
                    Assert.IsTrue(artista.Albuns.First().Id > 0);

                    tran.Rollback();
                }
            }
        }

        [TestMethod]
        public void CreateMusicaSaveSeparado()
        {
            using (var session = NHibernateSession.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    var cidade = _cidade;
                    session.Save(cidade);

                    var artista = _artista;
                    artista.Cidade = cidade;
                    session.Save(artista);

                    var album = _album;
                    artista.Albuns = new List<IAlbum> { album };
                    album.Artista = artista;
                    session.Save(album);

                    var muscia = _musica;
                    muscia.Album = album;
                    album.Musicas = new List<Musica> { muscia };
                    session.Save(muscia);

                    Assert.IsTrue(cidade.Id > 0);
                    Assert.IsTrue(artista.Id > 0);
                    Assert.IsTrue(artista.Albuns.First().Id > 0);
                    Assert.IsTrue(artista.Albuns.FirstOrDefault().Musicas.First().Id > 0);

                    tran.Rollback();
                }
            }
        }

        [TestMethod]
        public void AddEstiloToArtistaSaveUnico()
        {
            using (var session = NHibernateSession.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    var cidade = _cidade;
                    session.Save(cidade);

                    var estilo = _estilo;
                    session.Save(estilo);

                    var artista = _artista;
                    artista.Cidade = cidade;

                    var album = _album;
                    artista.Albuns = new List<IAlbum> { album };
                    album.Artista = artista;

                    var muscia = _musica;
                    muscia.Album = album;
                    album.Musicas = new List<Musica> { muscia };

                    artista.Estilos = new List<IEstilo>();
                    artista.Estilos.Add(estilo);

                    session.Save(artista);

                    Assert.IsTrue(estilo.Id > 0);
                    Assert.IsTrue(cidade.Id > 0);
                    Assert.IsTrue(artista.Id > 0);
                    Assert.IsTrue(artista.Albuns.First().Id > 0);
                    Assert.IsTrue(artista.Albuns.FirstOrDefault().Musicas.First().Id > 0);

                    tran.Rollback();
                }
            }
        }

        [TestMethod]
        public void CreateMusicaSaveUnico()
        {
            using (var session = NHibernateSession.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    var cidade = _cidade;
                    session.Save(cidade);

                    var artista = _artista;
                    artista.Cidade = cidade;

                    artista.Albuns = new List<IAlbum>();
                    artista.Albuns.Add(_album);
                    _album.Artista = artista;

                    var muscia = _musica;
                    muscia.Album = (IAlbum)artista.Albuns.FirstOrDefault();
                    artista.Albuns.FirstOrDefault().Musicas = new List<Musica> { muscia };                    

                    session.Save(artista);
                    
                    Assert.IsTrue(cidade.Id > 0);
                    Assert.IsTrue(artista.Id > 0);
                    Assert.IsTrue(artista.Albuns.First().Id > 0);

                    tran.Rollback();
                }
            }
        }
    }
}
