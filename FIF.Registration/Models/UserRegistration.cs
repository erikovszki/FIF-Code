namespace FIF.Registration.Models
{
    public class UserRegistration
    {
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value.Replace(" ",""); }
        }

        public string Email { get; set; }
        public string PasswordFirst { get; set; }
        public string PasswordSecond { get; set; }
    }
}
