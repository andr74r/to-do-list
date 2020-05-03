namespace ToDoList.Common.Validators
{
    public interface IEntityValidator<TEntity>
    {
        bool IsValid(TEntity entity);
    }
}
