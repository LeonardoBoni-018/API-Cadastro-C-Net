public interface IUserRepository
{
    Task<User> GetUserByIdAsync(int id);
    Task<User> SaveUserAsync(User user);
}