using MediatR;
using SaaV.Clean.Application.Dummies.Requests;
using SaaV.Clean.Application.Shared.Exceptions;
using SaaV.Clean.Application.Shared.Interfaces;
using SaaV.Clean.Domain.Dummies;
using SaaV.Clean.Domain.Shared;

namespace SaaV.Clean.Application.Dummies.Handlers
{
    public class DeleteDummyHandler : IRequestHandler<DeleteDummyRequest>
    {
        private readonly IDummyRepository _dummyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICredentialProvider _credentialProvider;

        public DeleteDummyHandler(IDummyRepository dummyRepository, IUnitOfWork unitOfWork, ICredentialProvider credentialProvider)
        {
            _dummyRepository = dummyRepository;
            _unitOfWork = unitOfWork;
            _credentialProvider = credentialProvider;
        }

        public async Task Handle(DeleteDummyRequest deleteDummyRequest, CancellationToken cancellationToken)
        {
            Dummy dummy = await _dummyRepository.GetByIdAsync(deleteDummyRequest.Id) 
                ?? throw new ItemNotFoundException(typeof(Dummy), deleteDummyRequest.Id);
            
            dummy.MarkAsDeleted(_credentialProvider.Credential.UserId, _credentialProvider.Credential.UserName);
            
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
