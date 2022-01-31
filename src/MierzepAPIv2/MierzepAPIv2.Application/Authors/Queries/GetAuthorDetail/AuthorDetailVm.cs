using AutoMapper;
using MierzepAPIv2.Application.Common.Mappings;
using MierzepAPIv2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MierzepAPIv2.Application.Directors.Queries.GetAuthorDetail
{
    public class AuthorDetailVm : IMapFrom<Author>
    {
        public string FullName { get; set; }
        public string LastText { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Author, AuthorDetailVm>()
                .ForMember(d => d.FullName, map => map.MapFrom(src => src.PersonName.ToString()))
                .ForMember(d => d.LastText, map => map.MapFrom<LastAuthorResolver>());
        }

        private class LastAuthorResolver : IValueResolver<Author, object, string>
        {
            public string Resolve(Author source, object destination, string destMember, ResolutionContext context)
            {
                if (source.Texts != null && source.Texts.Any())
                {
                    var lastText = source.Texts.LastOrDefault();

                    return lastText.Content;
                }
                else
                {
                    return "Text no definition";
                }
            }
        }
    }
}
