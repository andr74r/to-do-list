namespace ToDoList.Security.Core.Dto
{
    public class FindUserByPasswordDto : FindUserDto
    {
        public string Password { get; set; }
    }
}
