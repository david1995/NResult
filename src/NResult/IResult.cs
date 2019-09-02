namespace NResult
{
    /// <summary>
    /// The base interface for all action results.
    /// </summary>
    public interface IResult
    {
    }

    /// <summary>
    /// The base interface for all results providing a value on success.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    public interface IResult<T>
    {
    }
}
