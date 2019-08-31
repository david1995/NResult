namespace NResult
{
    public class Success : ISuccess
    {
    }

    public class Success<T> : ISuccess<T>
    {
        public Success(T value)
        {
            Value = value;
        }

        public T Value { get; }
    }
}
