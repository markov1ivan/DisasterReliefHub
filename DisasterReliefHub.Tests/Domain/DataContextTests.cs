using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DisasterReliefHub.Domain.Models;
using DisasterReliefHub.Domain.Repository;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DisasterReliefHub.Tests
{
    [TestClass]
    public class DataContextTests
    {
        private DataContext DataContext { get; set; }
        public void InitializeContext()
        {
            string connection =
                @"Data Source=(LocalDb)\v11.0;Initial Catalog=DisasterReliefHub;Integrated Security=SSPI;AttachDBFilename=C:\WC\Projects\Hackathon\DisasterReliefHub\DisasterReliefHub\App_Data\DisasterReliefHub.mdf";
            DataContext = new DataContext(connection);
        }

        [TestMethod]
        public void TestInitializeContext()
        {
            string connection =
                @"Data Source=(LocalDb)\v11.0;Initial Catalog=DisasterReliefHub;Integrated Security=SSPI;AttachDBFilename=C:\WC\Projects\Hackathon\DisasterReliefHub\DisasterReliefHub\App_Data\DisasterReliefHub.mdf";
            DataContext = new DataContext(connection);
            Assert.IsNotNull(DataContext);
        }

        [TestMethod]
        public void TestInitializeDatabase()
        {
            InitializeContext();
            DataContext.Database.CreateIfNotExists();

          var result = DataContext.Entities<Agency>().ToList();

            Assert.IsTrue(result.Count == 0 || result.Count  > 0);
        }
    }
}
