using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DisasterReliefHub.Domain.Models;
using DisasterReliefHub.Domain.Repository;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DisasterReliefHub.Tests.Domain
{
    [TestClass]
    public class RepositoryTests
    {
        public IRepository GetRepository()
        {
            string connection =
               @"Data Source=IMARKOV\SQLEXPRESS;Initial Catalog=DisasterReliefHub;Integrated Security=True";
            return new Repository(new DataContext(connection));
        }

        [TestMethod]
        public void TestCreatingRepository()
        {
            var repository = this.GetRepository();
            Assert.IsNotNull(repository);
        }

        [TestMethod]
        public void TestGetQuery()
        {
            var repository = this.GetRepository();
            var queriable = repository.Query<Agency>();
            Assert.IsNotNull(queriable);
            Assert.IsTrue(queriable.Count() == 0 || queriable.Any());
        }

        [TestMethod]
        public void TestGetById()
        {
            var repository = this.GetRepository();
            var agency = repository.Get<Agency>(1);
            Assert.IsNotNull(agency);
        }

        [TestMethod]
        public void TestSave()
        {
            var repository = this.GetRepository();
            Agency newAgency = new Agency();
            var agency = repository.Save(newAgency);

            var fromDb = repository.Get<Agency>(agency.Id);
            Assert.IsTrue(agency.Id == fromDb.Id);
        }
    }
}
