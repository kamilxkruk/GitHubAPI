using AutoMapper;
using GitHubAPI.Model.Dto;
using GitHubAPI.Model.JsonResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAPI.Automapper
{
    class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<GithubUserJsonResponse, GithubUserDto>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(source => source.id))
                .ForMember(dest => dest.Username, opts => opts.MapFrom(source => source.login))
                .ForMember(dest => dest.RepositoryUrl, opts => opts.MapFrom(source => source.html_url))
                .ForMember(dest => dest.NumberOfFollowers, opts => opts.MapFrom(source => source.followers))
                .ForMember(dest => dest.NumberOfFollowing, opts => opts.MapFrom(source => source.following))
                .ForMember(dest => dest.AccountCreationDate, opts => opts.MapFrom(source => source.created_at));
        }
    }
}
