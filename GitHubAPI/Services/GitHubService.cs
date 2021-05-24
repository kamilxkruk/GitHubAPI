using AutoMapper;
using GitHubAPI.Model.Dto;
using GitHubAPI.Model.JsonResponse;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAPI.Services
{

    public class GitHubService : IGitHubService
    {
        public IHttpClientFactory _httpClientFactory { get; set; }
        
        private readonly IMapper _mapper;

        public GitHubService(IHttpClientFactory clientFactory, IMapper mapper )
        {
            _httpClientFactory = clientFactory;
            _mapper = mapper;
        }


        public async Task<GithubUserDto> GetUserInfoAsync(string githubUsername)
        {
            string GetUserURL = @$"users/{githubUsername}";

            var httpClient = _httpClientFactory.CreateClient("GitHub");
            var jsonResponse = await httpClient.GetStringAsync(GetUserURL);
            GithubUserJsonResponse deserializedResponse = JsonConvert.DeserializeObject<GithubUserJsonResponse>(jsonResponse);
            GithubUserDto userDto = _mapper.Map<GithubUserDto>(deserializedResponse);
            return userDto;
        }

    }
}
