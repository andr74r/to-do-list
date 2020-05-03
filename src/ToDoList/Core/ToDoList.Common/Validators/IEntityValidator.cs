namespace ToDoList.Common
{
    public interface IEntityValidator<TEntity>
    {
        bool IsValid(TEntity entity);
    }
}
