using FastFoodApp.Core.Entities;

namespace FastFoodApp.Core.Security;

public interface ITokenService
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken();
}
