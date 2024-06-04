using AutoMapper;
using DevEvents.API.Entities;
using DevEvents.API.Models;

namespace DevEvents.API.Mappers
{
    public class DevEventProfile : Profile
    {
        public DevEventProfile() 
        {            
            CreateMap<DevEvent, DevEventViewModel>();
            CreateMap<DevEventSpeaker, DevEventSpeakerViewModel>();

            CreateMap<DevEventInputModel, DevEvent>();
            CreateMap<DevEventSpeakerInputModel, DevEventSpeaker>();
        }
    }
}
