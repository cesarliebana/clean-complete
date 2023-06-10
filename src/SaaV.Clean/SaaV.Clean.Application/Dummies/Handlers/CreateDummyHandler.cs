using Mapster;
using MediatR;
using SaaV.Clean.Application.Dummies.Requests;
using SaaV.Clean.Application.Dummies.Responses;
using SaaV.Clean.Application.Shared.Interfaces;
using SaaV.Clean.Domain.Dummies;
using SaaV.Clean.Domain.Shared;

namespace SaaV.Clean.Application.Dummies.Handlers
{
    public class CreateDummyHandler : IRequestHandler<CreateDummyRequest, GetDummyResponse>
    {
        private readonly IDummyRepository _dummyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICredentialProvider _credentialProvider;

        public CreateDummyHandler(IDummyRepository dummyRepository, IUnitOfWork unitOfWork, ICredentialProvider credentialProvider)
        {
            _dummyRepository = dummyRepository;
            _unitOfWork = unitOfWork;
            _credentialProvider = credentialProvider;
        }

        public async Task<GetDummyResponse> Handle(CreateDummyRequest createDummyRequest, CancellationToken cancellationToken)
        {
            Dummy dummy = new Dummy(
                createDummyRequest.Name, 
                _credentialProvider.Credential.TenantId,
                _credentialProvider.Credential.UserId,
                _credentialProvider.Credential.UserName);

            _dummyRepository.Add(dummy);
            
            await _unitOfWork.SaveChangesAsync();

            return dummy.Adapt<GetDummyResponse>();
        }
    }
}
