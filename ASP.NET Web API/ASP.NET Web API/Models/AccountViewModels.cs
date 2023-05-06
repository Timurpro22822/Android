namespace ASP.NET_Web_API.Models
{
    public class RegisterUserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ImageBase64 { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
