namespace HRBMSWEBAPP.Service
{
    public interface IUserService
    {
        string GetUserId();
        string GetUserFirstName();
        bool isAuthenticated();
    }
}
