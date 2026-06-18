using GestionGanadera.Abstractions;

namespace GestionGanadera.WebApiV2.Configurations
{
    public class TokenParameters : ITokensParameters
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PaswordHash { get; set; }
        public string Id { get; set; }
    }
}
