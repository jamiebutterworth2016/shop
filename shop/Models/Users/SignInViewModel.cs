namespace shop.Models.Users
{
    public class SignInViewModel
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        public string Error { get; set; }
    }
}