namespace Application.UserUseCases;

public class UserModel
{
    public UserModel(string? name, string? email, string? document)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Document = document;
        Active = true;
    }

    public Guid Id { get; private set; }
    public string? Name { get; private set; }
    public string? Email { get; private set; }
    public string? Document { get; private set; }
    public bool Active { get; private set; }

    public void ActiveUser () => Active = true;
    public void InactiveUser() => Active = false;
}