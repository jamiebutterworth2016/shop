using BLL.Abstractions.Services;
using BLL.Models;
using DAL.Abstractions.Repositories;
using SharedResources;
using System.Threading;
using System.Threading.Tasks;

namespace BLL.Concretions.Services
{
    public class SignInService : ISignInService
    {
        private readonly IUserRepository _userRepository;

        public SignInService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result> SignIn(SignInRequest request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetUserByEmailAddressAndPassword(request.EmailAddress, request.Password, cancellationToken);

            if (!result.Success) return new Result(result.Error);

            //if yes, create a session with a timeout.

            return new Result();
        }
    }
}