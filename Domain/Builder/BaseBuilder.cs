namespace Domain.Builder
{
    public abstract class BaseBuilder<T> where T : class, new()
    {
        protected readonly T _entity = new T();

        public T Build()
        {
            return _entity;
        }
    }
}
