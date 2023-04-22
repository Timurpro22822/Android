namespace ASP.NET_Web_API.Data.Entites
{
    public interface IEntity<T>
    {
        T Id { get; set; }
        bool isDeleted { get; set; }
        DateTime DateCreated { get; set; }
    }
    public abstract class BaseEntity<T> : IEntity<T>
    {
        public T Id { get; set; }
        public bool isDeleted { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
