public class LoginResponse
{
    public TokenData Token { get; set; }
    public UserModel User { get; set; }
}

public class TokenData
{
    public string Id { get; set; }
    public string Issuer { get; set; }
    public string SecurityKey { get; set; }
    public string SigningKey { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
}

public class UserModel
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public bool IsAdmin { get; set; }
}
