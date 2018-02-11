using AutoMapper;
using BLL.Abstractions.Services;
using BLL.Models;
using shop.Models.Users;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace shop.Controllers
{
    public class UsersController : Controller
    {
        private readonly ISignInService _signInService;
        private readonly IMapper _mapper;

        public UsersController(ISignInService signInService, IMapper mapper)
        {
            _signInService = signInService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> SignIn(CancellationToken cancellationToken)
        {
            return View(new SignInViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> SignIn(SignInViewModel model, CancellationToken cancellationToken)
        {
            var signInRequest = _mapper.Map<SignInRequest>(model);

            var result = await _signInService.SignIn(signInRequest, cancellationToken);

            if (!result.Success)
            {
                model.EmailAddress = "";
                model.Password = "";
                model.Error = result.Error;
            }

            return View(model);
        }
    }
}