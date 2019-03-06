using RPlay.DTO.Authentication;

namespace RPlay.Business.Services.Users
{
    public interface IdentityService<T>
        where T : Identity
    {
        T TryParse(Identity identity);
    }
}