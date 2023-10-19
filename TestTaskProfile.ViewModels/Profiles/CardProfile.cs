using AutoMapper;
using TestTaskProfile.Data.Models;
using TestTaskProfile.ViewModels.Models;

namespace TestTaskProfile.ViewModels.Profiles
{
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            CreateMap<AddCardModel, Card>()
                .ForMember(x => x.Id, options => options.MapFrom(x => Guid.NewGuid()))
                .ForMember(x => x.Number, options => options.MapFrom(x => x.Number))
                .ForMember(x => x.CVV, options => options.MapFrom(x => x.CVV))
                .ForMember(x => x.CardHolderName, options => options.MapFrom(x => x.CardHolderName));

            CreateMap<Card, GetCardModel>()
                .ForMember(x => x.Id, options => options.MapFrom(x => x.Id))
                .ForMember(x => x.Number, options => options.MapFrom(x => x.Number))
                .ForMember(x => x.CVV, options => options.MapFrom(x => x.CVV))
                .ForMember(x => x.CardHolderName, options => options.MapFrom(x => x.CardHolderName));
        }
    }
}
