using GitHubAPI.Model.Dto;
using System.Net.Http;
using System.Threading.Tasks;

namespace GitHubAPI.Services
{
    public interface IGitHubService
    {
        public IHttpClientFactory _httpClientFactory { get; set; }

        public Task<GithubUserDto> GetUserInfoAsync(string githubUsername);
    }
}