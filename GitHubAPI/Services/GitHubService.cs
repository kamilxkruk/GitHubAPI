using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAPI.Services
{
    
    class GitHubService
    {
        public IHttpClientFactory HttpClientFactory { get; set; }

        public bool CheckGithubAPIConnection()
        {
            var httpClient = HttpClientFactory.CreateClient("GitHub");

            //TODO Implement API call

            return false;
        }
    
    }
}
