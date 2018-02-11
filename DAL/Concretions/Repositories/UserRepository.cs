using DAL.Abstractions.Helpers;
using DAL.Abstractions.Repositories;
using DAL.DataModels;
using SharedResources;
using System;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Concretions.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ICurrentContext _currentContext;

        public UserRepository(ICurrentContext currentContext)
        {
            _currentContext = currentContext ?? throw new ArgumentNullException();

            if (_currentContext.Context == null) _currentContext.Create();
        }

        public async Task<Result<User>> GetUserByEmailAddressAndPassword(string emailAddress, string password, CancellationToken cancellationToken)
        {
            if (cancellationToken == null || emailAddress == null || password == null) throw new ArgumentNullException();

            var user = await _currentContext.Context.Users.SingleOrDefaultAsync(x => x.EmailAddress == emailAddress && x.Password == password, cancellationToken);

            if (user == null) return new Result<User>("Invalid email address or password.");

            return new Result<User>(user);
        }
    }
}