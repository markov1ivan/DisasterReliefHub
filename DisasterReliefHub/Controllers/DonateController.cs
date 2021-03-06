﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AutoMapper;

using Autofac;

using DisasterReliefHub.App_Start;
using DisasterReliefHub.Domain.Models;
using DisasterReliefHub.Domain.Repository;
using DisasterReliefHub.Libraries;
using DisasterReliefHub.Models;

namespace DisasterReliefHub.Controllers
{
    public class DonateController : Controller
    {
        //
        // GET: /Donate/
        [HttpGet]
        public ActionResult Index(int agencyId = -1)
        {
            if (agencyId < 0)
            {
                ModelState.AddModelError("Agency", "Invalid Agency");
            }
            var repo = DependencyInjection.Container.Resolve<IRepository>();
            var agency = repo.Get<Agency>(agencyId);
            var disaster = new Disaster(){Id = 1};
            DwollaDonation donation = new DwollaDonation();
            donation.Agency = agency;
            donation.Disaster = disaster;
            return View("Donate", donation);
        }

        [HttpPost]
        public ActionResult Index(DwollaDonation model)
        {
            if (ModelState.IsValid)
            {
                var repo = DependencyInjection.Container.Resolve<IRepository>();
                var agency = repo.Get<Agency>(model.Agency.Id);
                var disaster = repo.Get<Disaster>(model.Disaster.Id);
                if (model.IsAnonymously)
                {
                    model.FirstName = "Anonymous";
                    model.LastName = "Anonymous";
                }
                var dwolla = DependencyInjection.Container.Resolve<Dwolla>();
                var result = dwolla.Send(agency.Email, model.Email, model.Amount, model.FirstName, model.LastName, model.RoutingNumber, model.BankAccount, model.AccountType, model.Notes);
                model.ResultMessage = result.Message;
                model.Agency = agency;
                model.Transaction = result.Response;

                SaveDonation(model, repo);

                var mail = DependencyInjection.Container.Resolve<SendGrid>();
                String subject = "Thank you for making a donation!";
                string text = string.Format("Thank you for a making a donation to {0} of {1}", agency.Description, model.Amount);
                String html = string.Format("<p>{0}</p>",text);
                mail.Send(model.Email, string.Format("{0} {1}", model.FirstName, model.LastName),subject,html, text);
                return View("ProccessedDonate", model);
            }

            return View("Donate",model);
            
        }

        private static void SaveDonation(DwollaDonation model, IRepository repo)
        {
            Donation donation = new Donation();
            donation.FirstName = model.FirstName;
            donation.LastName = model.LastName;
            donation.Email = model.Email;
            donation.Amount = model.Amount;
            donation.BankAccount = model.BankAccount;
            donation.RoutingNumber = model.RoutingNumber;
            donation.AccountType = model.AccountType;
            donation.IsAnonymously = model.IsAnonymously;
            donation.Notes = model.Notes;
            donation.Transaction = model.Transaction;
            repo.Save<Donation>(donation);
        }
    }
}
