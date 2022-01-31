using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MierzepAPIv2.Application.Common.Mappings
{
    public interface IMapFrom<T>
    {
        //Tworzenie mapy dla source - T generyczne, dal implementiwanych GetType
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());

    }
}
