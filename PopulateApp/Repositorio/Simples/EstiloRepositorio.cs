using NHibernate;
using Dominio.Simples.Util;
using Dominio.Simples.Model;
using System.Collections.Generic;
using NHibernate.Linq;
using System.Linq;
using System;

namespace PopulateApp.Repositorio.Simples
{
    public class EstiloRepositorio : IReositorio<Estilo>
    {
        private void InsertEstilo()
        {
            using (var session = NHibernateSession.OpenSession())
            {
                var tran = session.BeginTransaction();

                try
                {
                    if (!TemEstiloCadastrado(session))
                        GetEstiloParaCadastrar().ForEach(estilo => session.Save(estilo));

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                }

            }
        }

        private List<Estilo> GetEstiloParaCadastrar()
        {
            return new List<Estilo>
            {
                  new Estilo{ Descricao = "Rock and Roll" }
                , new Estilo{ Descricao = "Samba" }
                , new Estilo{ Descricao = "Jazz" }
                , new Estilo{ Descricao = "Blues" }
                , new Estilo{ Descricao = "Salsa" }
                , new Estilo{ Descricao = "Latina" }
                , new Estilo{ Descricao = "Metal Progressivo" }
                , new Estilo{ Descricao = "Rumba" }
                , new Estilo{ Descricao = "World Music" }
                , new Estilo{ Descricao = "Country" }
            };
        }

        private bool TemEstiloCadastrado(ISession session)
        {
            var qtd = session.Query<Estilo>().Count();
            return qtd > 0;
        }

        public void Inserir()
        {
            InsertEstilo();
        }

        public int Contar(Func<Estilo, bool> expression)
        {
            using (var session = NHibernateSession.OpenSession())
            {
                var qtd = session.Query<Estilo>().Count(expression);
                return qtd;
            }
        }

        public void Deletar(Func<Estilo, bool> expression)
        {
            throw new NotImplementedException();
        }

        public Estilo Editar(Func<Estilo, bool> expression)
        {
            throw new NotImplementedException();
        }

        public List<Estilo> Pesquisar(Func<Estilo, bool> expression)
        {
            throw new NotImplementedException();
        }
    }
}