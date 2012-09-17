using Dominio.Simples.Model;
using Dominio.Simples.Util;
using NHibernate;
using System;
using System.Collections.Generic;

namespace PopulateApp.Repositorio.Simples
{
    class PessoaRepositorio : IReositorio<Pessoa>
    {
        private const int QTD_REGISTRO_INSERT = 500;
        private enum TipoPessoa { F = 1, J }

        private int _qtdPessoasInseridas;
        private Random _geradorRandmico;

        public void Inserir()
        {
            using (var session = NHibernateSession.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    try
                    {
                        reSeedGeradorRandomico();

                        do
                        {
                            InserirPessoaFisica(session);
                            InserirPessoaJuridica(session);
                        } while (podeInserirMaisPessoas());

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

        private bool podeInserirMaisPessoas()
        {
            return _qtdPessoasInseridas < QTD_REGISTRO_INSERT;
        }

        private void reSeedGeradorRandomico()
        {
            _geradorRandmico = new Random(DateTime.Now.Millisecond);
        }

        private TipoPessoa QualTipoPessoaInserir()
        {
            var maxRangeRandom = 100;

            var numero = _geradorRandmico.Next(maxRangeRandom);

            if (numero > 50)
                return TipoPessoa.F;

            return TipoPessoa.J;
        }

        private void InserirPessoaJuridica(ISession session)
        {
            if (QualTipoPessoaInserir() != TipoPessoa.J)
                return;

            _qtdPessoasInseridas++;

            var pessoa = new PessoaJuridica
            {
                Cnpj = DateTime.Now.Ticks.ToString().Substring(0, 14),
                DataAbertura = DateTime.Now.AddMonths(-1 * _geradorRandmico.Next(1,60)),
                Endereco = String.Format("Endereço pessoa juridica, {0}", DateTime.Now.Ticks),
                NomeFantasia = String.Format("Nome Fantasia {0}", DateTime.Now.Ticks),
                RazaoSocial = String.Format("Razao Social ", DateTime.Now.Ticks),
            };

            session.Save(pessoa);
        }

        private void InserirPessoaFisica(ISession session)
        {

            if (QualTipoPessoaInserir() != TipoPessoa.F)
                return;

            _qtdPessoasInseridas++;

            var pessoa = new PessoaFisica
            {
                Cpf = DateTime.Now.Ticks.ToString().Substring(0, 11),
                DataNascimento = DateTime.Now.AddMonths(-1 * _geradorRandmico.Next(1, 60)),
                Endereco = String.Format("Endereço pessoa fisica, {0}", DateTime.Now.Ticks),
                Nome = String.Format("Nome {0}", DateTime.Now.Ticks),
                Sobrenome = String.Format("Sobremone ", DateTime.Now.Ticks),
            };

            session.Save(pessoa);
 
        }        
    }
}
