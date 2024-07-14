namespace TonyNguyen.Net8.WebAPI.Infrastructure;

public interface IUserStore
{
    string GetUser();
}

public class Auth0UserStore : IUserStore
{
    public string GetUser()
    {
        return "This is from Auth0 User Store";
    }
}

public class ReplicatedUserStore : IUserStore
{
    public string GetUser()
    {
        return "This is from Replicated User Store";
    }
}