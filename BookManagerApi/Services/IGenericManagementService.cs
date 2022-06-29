namespace BookManagerApi.Services
{
    public interface IGenericManagementService<T>
    {
        bool Create(T Object);
    }
}
