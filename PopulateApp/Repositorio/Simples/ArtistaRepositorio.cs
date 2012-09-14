using Dominio.Simples.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulateApp.Repositorio.Simples
{ 
    public class ArtistaRepositorio : IReositorio<Artista>
    {
        public void Inserir()
        {
            throw new NotImplementedException();
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
    }
}
