using AutoMapper;
using Microsoft.Extensions.Logging.Abstractions;

namespace AuthServer.Business;

public static class ObjectMapper
{
    public static readonly Lazy<IMapper> _lazy = new Lazy<IMapper>(() =>
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MapProfile>();
        }, NullLoggerFactory.Instance);

        configuration.AssertConfigurationIsValid();

        return configuration.CreateMapper();
    });

    public static IMapper Mapper => _lazy.Value;
}
