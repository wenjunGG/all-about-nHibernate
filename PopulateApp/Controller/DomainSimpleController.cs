using Dominio.Simples.Model;
using PopulateApp.Repositorio.Simples;
using System;
using System.Collections.Generic;

namespace PopulateApp.Controller
{
    public class DomainSimpleController
    {
        private EstiloRepositorio _repoEsitlo;
        private PessoaRepositorio _repoPessoa;
        private CidadeRepositorio _repoCidade;
        private ArtistaRepositorio _repoArtista;
        private AlbumRepositorio _repoAlbum;
        private MusicaRepositorio _repoMusica;

        public void Inserir<T>()
        {
            if (typeof(T) == typeof(Estilo))
            {
                InserirEstilo();
                return;
            };

            if (typeof(T) == typeof(Pessoa))
            {
                InserirPessoa();
                return;
            }

            if (typeof(T) == typeof(Cidade))
            {
                InserirCidade();
                return;
            }

            if (typeof(T) == typeof(Artista))
            {
                InserirArtista();
                return;
            }

            if (typeof(T) == typeof(Album))
            {
                InserirAlbum();
                return;
            }

            if (typeof(T) == typeof(Musica))
            {
                InserirMusica();
                return;
            }

            throw new NotImplementedException("Não Implementado para o tipo: " + typeof(T));
        }

        public int Contar<T>(Func<T, bool> expression)
        {
            throw new NotImplementedException("Não Implementado para o tipo: " + typeof(T));
        }

        public void Deletar<T>(Func<T, bool> expression)
        {
            throw new NotImplementedException("Não Implementado para o tipo: " + typeof(T));
        }


        public T Editar<T>(Func<T, bool> expressiona)
        {
            throw new NotImplementedException("Não Implementado para o tipo: " + typeof(T));
        }

        public List<T> Pesquisar<T>()
        {
            throw new NotImplementedException("Não Implementado para o tipo: " + typeof(T));
        }


        private void InitRepositorio<T>()
        {
            if (typeof(T) == typeof(Estilo) && _repoEsitlo == null)
            {
                _repoEsitlo = new EstiloRepositorio();
                return;
            }

            if (typeof(T) == typeof(Pessoa) && _repoPessoa == null)
            {
                _repoPessoa = new PessoaRepositorio();
                return;
            }

            if (typeof(T) == typeof(Cidade) && _repoCidade == null)
            {
                _repoCidade = new CidadeRepositorio();
                return;
            }

            if (typeof(T) == typeof(Artista) && _repoArtista == null)
            {
                _repoArtista = new ArtistaRepositorio();
                return;
            }

            if (typeof(T) == typeof(Album) && _repoAlbum == null)
            {
                _repoAlbum = new AlbumRepositorio();
                return;
            }

            if (typeof(T) == typeof(Musica) && _repoMusica == null)
            {
                _repoMusica = new MusicaRepositorio();
                return;
            }

            throw new NotImplementedException("Não Implementado para o tipo: " + typeof(T));
        }

        private void InserirPessoa()
        {
            InitRepositorio<Pessoa>();
            _repoPessoa.Inserir();
        }

        private void InserirEstilo()
        {
            InitRepositorio<Estilo>();
            _repoEsitlo.Inserir();
        }

        private int ContarEstilo(Func<Estilo, bool> expression)
        {
            InitRepositorio<Estilo>();
            return _repoEsitlo.Contar(expression);
        }

        private int ContarPessoa(Func<Pessoa, bool> expresssion)
        {
            InitRepositorio<Pessoa>();
            return _repoPessoa.Contar(expresssion);
        }

        private void InserirCidade()
        {
            InitRepositorio<Cidade>();
            _repoCidade.Inserir();
        }

        private void InserirMusica()
        {
            throw new NotImplementedException();
        }

        private void InserirAlbum()
        {
            throw new NotImplementedException();
        }

        private void InserirArtista()
        {
            InitRepositorio<Artista>();
            _repoArtista.Inserir();
        }
    }
}