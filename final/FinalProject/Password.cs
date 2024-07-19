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

    // Checks if the userName is right and returns a true if it is
    public bool CheckUserName(string attemptedUserName)
    {
        return _userName == attemptedUserName;
    }
    // Checks if the password is right and returns a true if it is
    public bool CheckPassword(string attemptedPassword)
    {
        return _value == attemptedPassword; 
    }
}
