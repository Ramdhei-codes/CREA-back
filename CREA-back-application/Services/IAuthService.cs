public interface IAuthService
{
    bool ValidateUser(string email, string password);
}

public class AuthService : IAuthService
{

    private const string ValidEmail = "administrador.crea@ucaldas.edu.co";
    private const string ValidPassword = "administrador";

    public bool ValidateUser(string email, string password)
    {
        return email == ValidEmail && password == ValidPassword;
    }
}
