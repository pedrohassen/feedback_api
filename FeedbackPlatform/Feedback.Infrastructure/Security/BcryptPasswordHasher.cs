using FeedbackApp.Domain.Security;
using static BCrypt.Net.BCrypt;

namespace FeedbackApp.Infrastructure.Security
{
    public class BcryptPasswordHasher : IPasswordHasher
    {
        private const int WorkFactor = 12;

        public string Hash(string password)
        {
            return HashPassword(password, WorkFactor);
        }

        public bool Verify(string password, string hashed)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashed);
        }
    }
}
