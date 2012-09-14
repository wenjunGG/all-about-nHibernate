using Dominio.Simples.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulateApp.Repositorio.Simples
{
    class PessoaRepositorio : IReositorio<Pessoa>
    {
        public void Inserir()
        {
            throw new NotImplementedException();
        }

        public int Contar(Func<Pessoa, bool> expression)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Func<Pessoa, bool> expression)
        {
            throw new NotImplementedException();
        }

        public Pessoa Editar(Func<Pessoa, bool> expression)
        {
            throw new NotImplementedException();
        }

        public List<Pessoa> Pesquisar(Func<Pessoa, bool> expression)
        {
            throw new NotImplementedException();
        }
    }
}
