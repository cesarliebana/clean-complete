using Mapster;
using MediatR;
using SaaV.Clean.Application.Dummies.Requests;
using SaaV.Clean.Application.Dummies.Responses;
using SaaV.Clean.Application.Shared.Exceptions;
using SaaV.Clean.Domain.Dummies;

namespace SaaV.Clean.Application.Dummies.Handlers
{
    public class GetDummyByIdHandler : IRequestHandler<GetDummyByIdRequest, GetDummyResponse>
    {
        IDummyRepository _dummyRepository;

        public GetDummyByIdHandler(IDummyRepository dummyRepository)
        {
            _dummyRepository = dummyRepository;
        }

        public async Task<GetDummyResponse> Handle(GetDummyByIdRequest getDummyRequest, CancellationToken cancellationToken)
        {
            Dummy dummy = await _dummyRepository.GetByIdAsync(getDummyRequest.Id)
                ?? throw new ItemNotFoundException(typeof(Dummy), getDummyRequest.Id);

            return dummy.Adapt<GetDummyResponse>();
        }
    }
}
