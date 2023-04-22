namespace HRBMSWEBAPP.Service
{
    public interface IUserService
    {
        string GetUserId();
        bool isAuthenticated();
    }
}
