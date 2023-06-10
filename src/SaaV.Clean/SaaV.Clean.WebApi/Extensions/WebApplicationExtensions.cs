using SaaV.Clean.Application.Dummies.Responses;
using SaaV.Clean.WebApi.Authentication;
using SaaV.Clean.WebApi.Dummies;

namespace SaaV.Clean.WebApi.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void MapDummyEndpoints(this WebApplication app)
        {
            app.MapGet("/dummies", DummiesEndpoints.GetAllDummies)
                .RequireAuthorization()
                .WithName("GetAllDummies")
                .Produces<GetAllDummiesResponse>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status401Unauthorized)
                .Produces(StatusCodes.Status500InternalServerError);

            app.MapGet("/dummies/{id}", DummiesEndpoints.GetDummyById)
                .RequireAuthorization()
                .WithName("GetDummyById")
                .Produces<GetDummyResponse>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .Produces(StatusCodes.Status401Unauthorized)
                .Produces(StatusCodes.Status500InternalServerError);

            app.MapPost("/dummies", DummiesEndpoints.CreateDummy)
                .RequireAuthorization()
                .WithName("CreateDummy")
                .Accepts<CreateDummyModel>("application/json")
                .Produces<GetDummyResponse>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status401Unauthorized)
                .Produces(StatusCodes.Status500InternalServerError);


            app.MapPut("/dummies/{id}", DummiesEndpoints.UpdateDummy)
                .RequireAuthorization()
                .WithName("UpdateDummy")
                .Accepts<UpdateDummyModel>("application/json")
                .Produces<GetDummyResponse>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status401Unauthorized)
                .Produces(StatusCodes.Status500InternalServerError);

            app.MapDelete("/dummies/{id}", DummiesEndpoints.DeleteDummy)
                .RequireAuthorization()
                .WithName("DeleteDummy")
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status401Unauthorized)
                .Produces(StatusCodes.Status500InternalServerError);

        }

        public static void MapAuthenticationEndpoints(this WebApplication app)
        {
            app.MapGet("/auth", AuthenticationEndpoints.GetBearerToken)
                .WithName("GetBearerToken")
                .Produces<GetBearerTokenResponse>(StatusCodes.Status200OK);

        }
    }
}
