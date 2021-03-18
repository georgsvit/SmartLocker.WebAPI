using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SmartLocker.WebAPI.Options
{
    public class JwtOptions
    {
        public const string SectionName = "JwtOptions";

        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int LifeTime { get; set; }
        public string Key { get; set; }

        public SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new(Encoding.ASCII.GetBytes(Key));
    }
}
