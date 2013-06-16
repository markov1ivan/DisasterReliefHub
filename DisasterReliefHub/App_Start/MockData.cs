using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Autofac;

using DisasterReliefHub.Domain.Models;
using DisasterReliefHub.Domain.Repository;

namespace DisasterReliefHub.App_Start
{
    public class MockData
    {
        public static void Setup()
        {
            var repo = DependencyInjection.Container.Resolve<IRepository>();
            CreateAgencies(repo);
        }

        private static void CreateAgencies(IRepository repo)
        {
            var agency = repo.Get<Agency>().FirstOrDefault(a => a.Name == "American Red Cross Pikes Peak Chapter");
            if (agency == null)
            {
                agency = new Agency()
                             {
                                 Name = "American Red Cross Pikes Peak Chapter",
                                 Description = "American Red Cross Pikes Peak Chapter",
                                 Email = "disasterhub+redrcross@gmail.com",
                                 FirstName = "Anonymous",
                                 LastName = "Anonymous"
                             };
                repo.Save(agency);
            }
            agency = repo.Get<Agency>().FirstOrDefault(a => a.Name == "Pikes Peak Community Foundation's Emergency Relief Fund");
            if (agency == null)
            {
                agency = new Agency()
                             {
                                 Name = "Pikes Peak Community Foundation's Emergency Relief Fund",
                                 Description = "Pikes Peak Community Foundation's Emergency Relief Fund",
                                 Email = "disasterhub+emergencyrelief@gmail.com",
                                 FirstName = "Anonymous",
                                 LastName = "Anonymous"
                             };
                repo.Save(agency);
            }
            agency = repo.Get<Agency>().FirstOrDefault(a => a.Name == "Pikes Peak Community Foundation's Emergency Relief Fund");
            if (agency == null)
            {
                agency = new Agency()
                             {
                                 Name = "Salvation Army - Intermountain",
                                 Description = "Salvation Army - Intermountain",
                                 Email = "disasterhub+salvationarmy@gmail.com",
                                 FirstName = "Anonymous",
                                 LastName = "Anonymous"
                             };
                repo.Save(agency);
            }
        }
    }
}