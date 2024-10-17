using AutoMapper;
using SmartLearn.Data;
using SmartLearn.Models;

namespace SmartLearn
{
    public static class AutoMapperConfig
    {
        public static IMapper Mapper { get; private set; }

        public static void Init()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //mapping from dto to model
                cfg.CreateMap<Category, CategoryModel>()
                   .ForMember(dst => dst.Id, src => src.MapFrom(e => e.ID))
                   .ForMember(dst => dst.ParentId, src => src.MapFrom(e => e.Category2.Parent_Id))
                   .ForMember(dst => dst.ParentName, src => src.MapFrom(e => e.Category2.Name))
                .ReverseMap();

                cfg.CreateMap<Trainer, TrainerModel>().ReverseMap();

                cfg.CreateMap<Course, CourseModel>()
                    .ForMember(dst => dst.TrainerName, src => src.MapFrom(e => e.Trainer.Name))
                    .ForMember(dst => dst.Category_Name, src => src.MapFrom(e => e.Category.Name))
                .ReverseMap();
            });

            Mapper = config.CreateMapper();

        }
    }
}