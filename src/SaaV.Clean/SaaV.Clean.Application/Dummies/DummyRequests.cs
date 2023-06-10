using MediatR;
using SaaV.Clean.Application.Dummies.Responses;

namespace SaaV.Clean.Application.Dummies.Requests
{
    public record struct CreateDummyRequest(string Name) : IRequest<GetDummyResponse>;
    
    public record struct DeleteDummyRequest(int Id) : IRequest;

    public record struct GetAllDummiesRequest : IRequest<GetAllDummiesResponse>;

    public record struct GetDummyByIdRequest(int Id) : IRequest<GetDummyResponse>;

    public record struct UpdateDummyRequest(int Id, string Name) : IRequest<GetDummyResponse>;
}
