﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio.Util;

namespace EstudoNHTest
{
    [TestClass]
    public class SessionFactoryTests
    {
        [TestMethod]
        public void OpenSessionTest()
        {
            var session = NHibernateSession.OpenSession();
            Assert.IsTrue(true);
        }
    }
}