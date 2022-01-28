using Codewrinkles.MinimalApi.SmartModules;
using prototype.Application;
using prototype.Application.Interfaces;

namespace prototype.api.Modules
{
    public class PrototypeModule : SmartModule
    {
        private const string apiRoute = "/api/prototype";

        public override IEndpointRouteBuilder MapEndpointDefinitions(IEndpointRouteBuilder app)
        {

            app.MapGet(apiRoute, async (IPrototypeService prototypeService)
                => await prototypeService.ReadPrototypes())
                .WithName("GetPrototypes")
                .WithDisplayName("Get Prototypes");


            app.MapGet(apiRoute + "/{Id}", (Guid Id, IPrototypeService prototypeService)
                => prototypeService.ReadPrototype(Id))
                .WithName("GetPrototype")
                .WithDisplayName("Get Prototype");

            app.MapPost(apiRoute, (PrototypeDto prototypeDto, IPrototypeService prototypeService)
                => prototypeService.WritePrototype(prototypeDto))
                .WithName("PostPrototype")
                .WithDisplayName("Post Prototype");


            return app;
        }
    }
}
