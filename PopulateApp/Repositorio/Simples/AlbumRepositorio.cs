using Dominio.Simples.Model;
using System;
using System.Collections.Generic;

namespace PopulateApp.Repositorio.Simples
{
    public class AlbumRepositorio : IReositorio<Album>
    {
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
    }
}
