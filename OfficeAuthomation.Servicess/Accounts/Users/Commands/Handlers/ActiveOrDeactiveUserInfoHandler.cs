using MediatR;
using OfficeAuthomation.Domains.Accounts.Users.Commands;
using OfficeAuthomation.Domains.Accounts.Users.Repositories;
using OfficeAuthomation.Domains.Commons;
using OfficeAuthomation.Domains.Enums;
using System.Threading;
using System.Threading.Tasks;

namespace OfficeAuthomation.Servicess.Accounts.Users.Commands.Handlers
{
    public class ActiveOrDeactiveUserInfoHandler : IRequestHandler<ActiveOrDeactiveUserInfo, ResultStatusType>
    {
        private readonly IUserRepositoryCommand _userRepositoryCommand;
        private readonly IUnitOfWork _unitOfWork;

        public ActiveOrDeactiveUserInfoHandler(IUserRepositoryCommand userRepositoryCommand, IUnitOfWork unitOfWork)
        {
            _userRepositoryCommand = userRepositoryCommand;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultStatusType> Handle(ActiveOrDeactiveUserInfo request, CancellationToken cancellationToken)
        {
            await _userRepositoryCommand.ActiveOrDeactiveUser(request.UserId);
            await _unitOfWork.Save();

            return ResultStatusType.success;
        }
    }
}