using Dominio.Simples.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulateApp.Repositorio.Simples
{
    public class MusicaRepositorio : IReositorio<Musica>
    {
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
    }
}
