using AutoMapper;
using FootballAPI.Data.Entities;
using FootballAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAPI.Data
{
    public class AtomapperProfile: Profile
    {
        public AtomapperProfile()
        {
            this.CreateMap<TeamModel, TeamEntity>()
                //.ForMember(tm => tm.Name, te => te.MapFrom(m => m.Name))
                .ReverseMap();

            this.CreateMap<PlayerModel, PlayerEntity>()
                .ReverseMap();

            this.CreateMap<TeamWithPlayerModel, TeamEntity>()
                .ReverseMap();
        }
    }
}
