using SaaV.Clean.Application.Dummies.Responses;
using SaaV.Clean.WebApi.Authentication;
using SaaV.Clean.WebApi.Dummies;
using Swashbuckle.AspNetCore.Annotations;

namespace SaaV.Clean.WebApi.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void MapDummyEndpoints(this WebApplication app)
        {
            app.MapGet("/dummies", DummiesEndpoints.GetAllDummies)
                .RequireAuthorization()
                .WithName("GetAllDummies")
                .WithMetadata(new SwaggerOperationAttribute(summary: "Get all dummies", description: ""))
                .Produces<GetAllDummiesResponse>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status401Unauthorized)
                .Produces(StatusCodes.Status500InternalServerError);

            app.MapGet("/dummies/{id}", DummiesEndpoints.GetDummyById)
                .RequireAuthorization()
                .WithName("GetDummyById")
                .WithMetadata(new SwaggerOperationAttribute(summary: "Get a dummy by id", description: ""))
                .Produces<GetDummyResponse>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .Produces(StatusCodes.Status401Unauthorized)
                .Produces(StatusCodes.Status500InternalServerError);

            app.MapPost("/dummies", DummiesEndpoints.CreateDummy)
                .RequireAuthorization()
                .WithName("CreateDummy")
                .WithMetadata(new SwaggerOperationAttribute(summary: "Create a new dummy", description: ""))
                .Accepts<CreateDummyModel>("application/json")
                .Produces<GetDummyResponse>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status401Unauthorized)
                .Produces(StatusCodes.Status500InternalServerError);


            app.MapPut("/dummies/{id}", DummiesEndpoints.UpdateDummy)
                .RequireAuthorization()
                .WithName("UpdateDummy")
                .WithMetadata(new SwaggerOperationAttribute(summary: "Update a dummy", description: ""))
                .Accepts<UpdateDummyModel>("application/json")
                .Produces<GetDummyResponse>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status401Unauthorized)
                .Produces(StatusCodes.Status500InternalServerError);

            app.MapDelete("/dummies/{id}", DummiesEndpoints.DeleteDummy)
                .RequireAuthorization()
                .WithName("DeleteDummy")
                .WithMetadata(new SwaggerOperationAttribute(summary: "Delete a dummy", description: ""))
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status401Unauthorized)
                .Produces(StatusCodes.Status500InternalServerError);

        }

        public static void MapAuthenticationEndpoints(this WebApplication app)
        {
            app.MapGet("/auth", AuthenticationEndpoints.GetBearerToken)
                .WithName("GetBearerToken")
                .WithMetadata(new SwaggerOperationAttribute(summary: "Get a bearer token", description: ""))
                .Produces<GetBearerTokenResponse>(StatusCodes.Status200OK);

        }
    }
}
