using BLL.Models;
using SharedResources;
using System.Threading;
using System.Threading.Tasks;

namespace BLL.Abstractions.Services
{
    public interface ISignInService
    {
        Task<Result> SignIn(SignInRequest request, CancellationToken cancellationToken);
    }
}