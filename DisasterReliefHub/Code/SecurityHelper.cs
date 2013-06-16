using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

using Autofac;

using DisasterReliefHub.App_Start;
using DisasterReliefHub.Domain.Models;
using DisasterReliefHub.Domain.Repository;

using WebMatrix.WebData;

namespace DisasterReliefHub.Code
{
    public class SecurityHelper
    {
        public static User CurrentUser()
        {
            
            var repo = DependencyInjection.Container.Resolve<IRepository>();
            var user = repo.Query<User>()
                .FirstOrDefault(u => u.Username.ToLower() == WebSecurity.CurrentUserName.ToLower());
            if (user != null)
            {
                user = repo.Get<User>(user.Id);
            }
            return user;
        }

        public static bool IsCurrentUserAdmin()
        {
            var user = CurrentUser();
            return user != null ? user.IsAdministrator : false;
        }
    }
}