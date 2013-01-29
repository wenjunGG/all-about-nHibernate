using Dominio.Simples.Util;
using Dominio.Simples.Model;
using System.Linq;
using NHibernate.Linq;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;

namespace EstudoNHTest.Simples
{
    /// <summary>
    /// Summary description for PessoaCrudTests
    /// </summary>
    [TestClass]
    public class PessoaCrudTests
    {
        public PessoaCrudTests()
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

        private int GetRandonSkipNumber<T>(ISession session)
        {
            var random = new Random(DateTime.Now.Millisecond);
            var total = session.Query<T>().Count();

            return random.Next(total);
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
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CreatePessoaFisica()
        {
            using (var session = NHibernateSession.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    var pessoa = new PessoaFisica();
                    pessoa.Nome = "Jackson";
                    pessoa.Sobrenome = "Pinto";
                    pessoa.DataNascimento = new DateTime(1975, 11, 22);
                    pessoa.Cpf = "12362543625";
                    pessoa.Endereco = "Rua das Coves";
                    pessoa.Sexo = 'M';

                    session.Save(pessoa);
                    tran.Rollback();
                }
            }
        }

        [TestMethod]
        public void CreatePessoaJuridica()
        {
            using (var session = NHibernateSession.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    var pessoa = new PessoaJuridica();
                    pessoa.RazaoSocial = "Emrpesa do Zé";
                    pessoa.DataAbertura = DateTime.Today;
                    pessoa.Cnpj = "52346852316587";
                    pessoa.Endereco = "Ruas das Coves, 45";
                    pessoa.NomeFantasia = "Maria Chiquinha Delivery";

                    session.Save(pessoa);
                    tran.Rollback();
                }
            }
        }

        [TestMethod]
        public void EditPessoaFisica()
        {
            using (var session = NHibernateSession.OpenSession())
            {
                var tran = session.BeginTransaction();
                var nome = "João";
                var sobrenome = "Pinto";
                var pessoa = session.Query<PessoaFisica>().Skip(GetRandonSkipNumber<PessoaFisica>(session)).First();

                pessoa.Nome = nome;
                pessoa.Sobrenome = sobrenome;
                session.Update(pessoa);
                tran.Commit();

                session.Evict(pessoa);
                var pessoaEditada = session.Get<PessoaFisica>(pessoa.Id);

                Assert.AreEqual(nome, pessoa.Nome);
                Assert.AreEqual(sobrenome, pessoa.Sobrenome);
            }
        }

        [TestMethod]
        public void EditPessoaJuridica()
        {
            using (var session = NHibernateSession.OpenSession())
            {
                var tran = session.BeginTransaction();
                var razaoSocial = "Casa de Carne";
                var nomeFantasia = "Churras do Zé";
                var pessoa = session.Query<PessoaJuridica>().Skip(GetRandonSkipNumber<PessoaJuridica>(session)).First();

                pessoa.RazaoSocial = razaoSocial;
                pessoa.NomeFantasia = nomeFantasia;
                session.Update(pessoa);
                tran.Commit();

                session.Evict(pessoa);
                var pessoaEditada = session.Get<PessoaJuridica>(pessoa.Id);

                Assert.AreEqual(razaoSocial, pessoa.RazaoSocial);
                Assert.AreEqual(nomeFantasia, pessoa.NomeFantasia);
            }
        }

        [TestMethod]
        public void EditPessoa()
        {
            using (var session = NHibernateSession.OpenSession())
            {
                var tran = session.BeginTransaction();
                //var razaoSocial = "Casa de Carne";
                //var nomeFantasia = "Churras do Zé";
                var pessoas = session.Query<Pessoa>().Skip(GetRandonSkipNumber<Pessoa>(session)).Take(5);

                //var complemento = DateTime.Now.Millisecond.ToString();
                //pessoas.ForEach(p => p.Endereco = "Novo endereço" + complemento);
                //pessoas.ForEach(p => session.Save(p));

                var ids = pessoas.Select(p => p.Id).ToList();

                tran.Commit();

                //pessoas.ForEach(p => session.Evict(p));

                var query = from p in session.Query<Pessoa>() where ids.Contains(p.Id) select p;
                var d = query.ToList();

                var x = session.Query<Pessoa>().Where(p => ids.Contains(p.Id)).ToList();
                //var d = session.Query<PessoaFisica>().;

            }
        }
    }
}
