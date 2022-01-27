namespace NResult
{
    /// <summary>
    /// The base interface for all failure results.
    /// </summary>
    public interface IFailure : IResult
    {
    }

    /// <summary>
    /// The base interface for all failure results where a value should be returned on success.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    public interface IFailure<T> : IFailure, IResult<T>
    {
    }
}
