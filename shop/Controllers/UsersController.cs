using shop.Models.Users;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace shop.Controllers
{
    public class UsersController : Controller
    {
        public UsersController() { }

        [HttpGet]
        public async Task<ActionResult> SignIn(CancellationToken cancellationToken)
        {
            return View(new SignInViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> SignIn(SignInViewModel model, CancellationToken cancellationToken)
        {
            //redirect to home.

            return View();
        }
    }
}