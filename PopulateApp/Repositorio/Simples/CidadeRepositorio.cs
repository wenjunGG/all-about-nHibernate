using Dominio.Simples.Model;
using Dominio.Simples.Util;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Linq;
using System.Collections.Generic;

namespace PopulateApp.Repositorio.Simples
{
    public class CidadeRepositorio : IReositorio<Cidade>
    {
        private const int QTD_CIDADES_INSERT = 100;
        private enum UF { PR, SC, SP, RS, BA, MG, AM, PE, PB, AC }
        private Random _geradorRandom;

        public void Inserir()
        {
            using (var session = NHibernateSession.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    _geradorRandom = new Random(DateTime.Now.Millisecond);

                    try
                    {
                        var qtdInseridos = 0;
                        var UFs = Enum.GetNames(typeof(UF));

                        do
                        {
                            var cidade = new Cidade
                            {
                                Nome = String.Format("Cidade {0}", DateTime.Now.Ticks),
                                Uf = UFs[_geradorRandom.Next(UFs.Length)]
                            };

                            session.Save(cidade);
                            qtdInseridos++;

                        } while (qtdInseridos < QTD_CIDADES_INSERT);

                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        throw;
                    }
                }

            }
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

        public static Cidade GetCidade(ISession session)
        {
            var query = session.Query<Cidade>();
            var random = new Random(DateTime.Now.Millisecond);
            var minId = query.Min(cidade => cidade.Id);
            var maxId = query.Max(cidade => cidade.Id);

            do
            {
                var cidade = query.FirstOrDefault(c => c.Id == random.Next(minId, maxId));

                if (cidade == null)
                    continue;

                return cidade;
                
            } while (true);
        }
    }
}
