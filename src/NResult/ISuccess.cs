namespace NResult
{
    /// <summary>
    /// The base interface for all success types.
    /// </summary>
    public interface ISuccess : IResult
    {
    }

    /// <summary>
    /// The base interface for all success types providing a value.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    public interface ISuccess<T> : ISuccess, IResult<T>
    {
        /// <summary>
        /// Gets the result value.
        /// </summary>
        T Value { get; }
    }
}
