using AutoMapper;
using Core.Domain.TileWidgets;
using Web.Presentation.ViewModels.DashboardViewModels;

namespace Infrastructure.AutoMapper.Profiles
{
    public class TileWidgetProfile : Profile
    {
        public TileWidgetProfile()
        {
            CreateMap<TileWidget, DashboardWidgetViewModel>()
                .ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.Icon.Name))
                .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Bookmark.Url));

            CreateMap<WidgetBookmark, DashboardWidgetBookmarkViewModel>(MemberList.None);
        }
    }
}
