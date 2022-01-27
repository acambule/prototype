using Codewrinkles.MinimalApi.SmartModules;
using prototype.Application;
using prototype.infrastructure.Services;

namespace prototype.api.Modules
{
    public class PrototypeModule : SmartModule
    {
        private const string apiRoute = "/api/prototype";
        
        private readonly IServiceProvider _serviceProvider;

        public PrototypeModule(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public override IEndpointRouteBuilder MapEndpointDefinitions(IEndpointRouteBuilder app)
        {
            using var scope = _serviceProvider.CreateScope();
            var prototypeService = scope.ServiceProvider.GetRequiredService<PrototypeService>();

            app.MapGet(apiRoute, () => prototypeService.ReadPrototypes())
                .WithName("GetPrototypes")
                .WithDisplayName("Get Prototypes");


            app.MapGet(apiRoute+ "/{Id}", (Guid Id) => prototypeService.ReadPrototype(Id))
                .WithName("GetPrototype")
                .WithDisplayName("Get Prototype");

            app.MapPost(apiRoute, (PrototypeDto prototypeDto) => prototypeService.WritePrototype(prototypeDto))
                .WithName("PostPrototype")
                .WithDisplayName("Post Prototype");


            return app;
        }
    }
}
