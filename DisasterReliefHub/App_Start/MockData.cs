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
            var agency = repo.Get<Agency>().FirstOrDefault(a => a.Name == "American Red Cross");
            if (agency == null)
            {
                agency = new Agency()
                             {
                                 Name = @"American Red Cross",
                                 Description = "The American Red Cross exists to provide compassionate care to those in need. Our network of generous donors, volunteers and employees share a mission of preventing and relieving suffering, here at home and around the world.<br/><br/>The Red Cross responds to approximately 70,000 disasters in the United States every year, ranging from home fires that affect a single family to hurricanes that affect tens of thousands, to earthquakes that impact millions. In these events, the Red Cross provides shelter, food, health and mental health services to help families and entire communities get back on their feet. Although the Red Cross is not a government agency, it is an essential part of the response when disaster strikes. We work in partnership with other agencies and organizations that provide services to disaster victims.",
                                 Email = "disasterhub+redrcross@gmail.com",
                                 FirstName = "Anonymous",
                                 LastName = "Anonymous",
                                 Image = "http://a6e6fad2d184a3bcfa10-5c7e44dc9162544fc5faee10623905da.r26.cf1.rackcdn.com/agency_1.png"
                             };
                repo.Save(agency);
            }
            agency = repo.Get<Agency>().FirstOrDefault(a => a.Name == "Heart to Heart International");
            if (agency == null)
            {
                agency = new Agency()
                             {
                                 Name = "Heart to Heart International",
                                 Description = "Heart to Heart International has been creating a healthier world since 1992. Our mission is to improve global health through initiatives that connect people and resources to a world in need. Through our mobilization efforts, we provide medical education, deliver medical aid, respond to people in crisis and address community-health concerns around the globe.",
                                 Email = "disasterhub+emergencyrelief@gmail.com",
                                 FirstName = "Anonymous",
                                 LastName = "Anonymous",
                                 Image = "http://a6e6fad2d184a3bcfa10-5c7e44dc9162544fc5faee10623905da.r26.cf1.rackcdn.com/agency_2.png"
                             };
                repo.Save(agency);
            }
            agency = repo.Get<Agency>().FirstOrDefault(a => a.Name == "Salvation Army");
            if (agency == null)
            {
                agency = new Agency()
                             {
                                 Name = "Salvation Army",
                                 Description = "Founded more than 130 years ago by William Booth, The Salvation Army is a religious and social service organization, a branch of the Christian Church dedicated to the battle against sin and despair.<br/>There is an integrated ministry to body, mind and soul. The Army seeks not only to improve the physical environment and provide for material needs, but also to reveal the power of Christ's love. Its social services programs assist children, the elderly, families, and those battling addiction.",
                                 Email = "disasterhub+salvationarmy@gmail.com",
                                 FirstName = "Anonymous",
                                 LastName = "Anonymous",
                                 Image = "http://a6e6fad2d184a3bcfa10-5c7e44dc9162544fc5faee10623905da.r26.cf1.rackcdn.com/agency_3.gif"
                             };
                repo.Save(agency);
            }
        }
    }
}