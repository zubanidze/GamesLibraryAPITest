using AutoMapper;
using GamesLibrary.Infrastructure.Db.Entities;
using GamesLibrary.Infrastructure.Dto;

namespace GamesLibrary.Infrastructure.Mappers
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<GameModel, Game>().AfterMap(
            (s, d) =>
            {
                s.Id = d.Id;
                s.Name = d.Name;
                s.Developer = d.Developer;

            });
            CreateMap<Game, GameModel>().AfterMap(
           (s, d) =>
           {
               s.Id = d.Id;
               s.Name = d.Name;
               s.Developer = d.Developer;

           });
        }
    }
}
