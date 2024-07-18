public class Password
{
    private readonly string _userName;
    private readonly string _value;

    public Password(string value, string userName)
    {
        _value = value;
        _userName = userName;
    }
    public Password()
    {
        _userName = "username";
        _value = "password";
    }

    // Optional methods for password management

    public bool CheckUserName(string attemptedUserName)
    {
        return _userName == attemptedUserName;
    }
    public bool CheckPassword(string attemptedPassword)
    {
        return _value == attemptedPassword; // Compares passwords
    }
}
