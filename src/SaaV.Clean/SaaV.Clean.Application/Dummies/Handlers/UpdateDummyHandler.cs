using Mapster;
using MediatR;
using SaaV.Clean.Application.Dummies.Requests;
using SaaV.Clean.Application.Dummies.Responses;
using SaaV.Clean.Application.Shared.Exceptions;
using SaaV.Clean.Application.Shared.Interfaces;
using SaaV.Clean.Domain.Dummies;
using SaaV.Clean.Domain.Shared;

namespace SaaV.Clean.Application.Dummies.Handlers
{
    public class UpdateDummyHandler : IRequestHandler<UpdateDummyRequest, GetDummyResponse>
    {
        private readonly IDummyRepository _dummyRepository;
        private readonly ICredentialProvider _credentialProvider;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDummyHandler(IDummyRepository dummyRepository, IUnitOfWork unitOfWork, ICredentialProvider credentialProvider)
        {
            _dummyRepository = dummyRepository;
            _unitOfWork = unitOfWork;
            _credentialProvider = credentialProvider;
        }

        public async Task<GetDummyResponse> Handle(UpdateDummyRequest updateDummyRequest, CancellationToken cancellationToken)
        {
            Dummy dummy = await _dummyRepository.GetByIdAsync(updateDummyRequest.Id)
                ?? throw new ItemNotFoundException(typeof(Dummy), updateDummyRequest.Id);

            dummy.Update(updateDummyRequest.Name);
            dummy.MarkAsModified(_credentialProvider.Credential.UserId, _credentialProvider.Credential.UserName);
            await _unitOfWork.SaveChangesAsync();

            return dummy.Adapt<GetDummyResponse>();
        }
    }
}
