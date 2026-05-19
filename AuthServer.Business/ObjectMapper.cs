using AutoMapper;

namespace AuthServer.Business;

public static class ObjectMapper
{
    public static readonly Lazy<IMapper> _lazy = new Lazy<IMapper>(() =>
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MapProfile>();
        }, null);

        return configuration.CreateMapper();
    });

    public static IMapper Mapper => _lazy.Value;
}
