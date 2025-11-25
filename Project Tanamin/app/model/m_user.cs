public class User
{
    public int IdUser { get; set; }
    public string NamaLengkap { get; set; }
    public string Username { get; set; }
    public string NoTelp { get; set; }
    public string Password { get; set; }
    public virtual bool IsAdmin { get; }
}

public class Admin : User
{
    public override bool IsAdmin => true;
}

public class Customer : User
{
    public override bool IsAdmin => false;
}
