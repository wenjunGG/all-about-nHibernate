using Dominio.Simples.Util;
using Dominio.Simples.Model;
using System.Linq;
using NHibernate.Linq;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            using(var session = NHibernateSession.OpenSession())
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
    }
}
