namespace ToDoList.Security.Core.Services.Hash
{
    public interface IHashProvider
    {
        string GetHash(string input);
    }
}
