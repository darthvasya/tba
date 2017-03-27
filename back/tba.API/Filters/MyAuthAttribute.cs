using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Ninject.Activation;

namespace tba.API.Filters
{
    public class MyAuthAttribute : Attribute, IAuthorizationFilter
    {
        public bool AllowMultiple { get; }

        private string[] usersList;
        public MyAuthAttribute(params string[] users)
        {
            this.usersList = users;
        }

        public Task < HttpResponseMessage > ExecuteAuthorizationFilterAsync ( HttpActionContext actionContext, CancellationToken cancellationToken,
            Func < Task < HttpResponseMessage > > continuation )
        {
 

            ClaimsPrincipal principal = actionContext.RequestContext.Principal as ClaimsPrincipal;
            if (principal == null || !usersList.Contains(principal.Claims.FirstOrDefault(c => c.Type == "name").Value))
            {
                return Task.FromResult<HttpResponseMessage>(
                       actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized));
            }
            else
            {
                return continuation();
            }
        }
    }
}