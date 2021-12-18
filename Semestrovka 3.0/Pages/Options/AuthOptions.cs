using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Semestrovka_3._0.Pages.Options
{
    public class AuthOptions
    {
        public string TokenCreator { get; set; } 

        public string TokenUser { get; set; }
        public string TokenSecret { get; set; }

        public int TokenLifeTime { get; set; }

        public SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenSecret));
    }
}
