using MediatR;
using SaaV.Clean.Application.Dummies.Requests;
using SaaV.Clean.Application.Dummies.Responses;
using SaaV.Clean.Domain.Dummies;

namespace SaaV.Clean.Application.Dummies.Handlers
{
    public class GetAllDummiesHandler : IRequestHandler<GetAllDummiesRequest, GetAllDummiesResponse>
    {
        IDummyRepository _dummyRepository;

        public GetAllDummiesHandler(IDummyRepository dummyRepository)
        {
            _dummyRepository = dummyRepository;
        }

        public async Task<GetAllDummiesResponse> Handle(GetAllDummiesRequest getAllDummiesRequest, CancellationToken cancellationToken)
        {
            IList<DummyItem> dummies = await _dummyRepository.GetAllAsync();
            
            return new GetAllDummiesResponse(dummies);
        }
    }
}
