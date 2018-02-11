using DAL.DataModels;
using SharedResources;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<Result<User>> GetUserByEmailAddressAndPassword(string emailAddress, string password, CancellationToken cancellationToken);
    }
}