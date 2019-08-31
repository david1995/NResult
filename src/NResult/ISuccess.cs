namespace NResult
{
    public interface ISuccess : IResult
    {
    }

    public interface ISuccess<T> : ISuccess, IResult<T>
    {
        T Value { get; }
    }
}
