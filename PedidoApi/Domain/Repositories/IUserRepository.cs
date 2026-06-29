public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);
    Task<User> SaveAsync(User user);
}