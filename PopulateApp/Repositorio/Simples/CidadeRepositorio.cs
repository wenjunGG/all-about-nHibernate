using Dominio.Simples.Model;
using System;
using System.Collections.Generic;

namespace PopulateApp.Repositorio.Simples
{
    public class CidadeRepositorio : IReositorio<Cidade>
    {
        public void Inserir()
        {
            throw new NotImplementedException();
        }

        public int Contar(Func<Cidade, bool> expression)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Func<Cidade, bool> expression)
        {
            throw new NotImplementedException();
        }

        public Cidade Editar(Func<Cidade, bool> expression)
        {
            throw new NotImplementedException();
        }

        public List<Cidade> Pesquisar(Func<Cidade, bool> expression)
        {
            throw new NotImplementedException();
        }
    }
}
