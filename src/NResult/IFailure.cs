﻿namespace NResult
{
    public interface IFailure : IResult
    {
    }

    public interface IFailure<T> : IFailure, IResult<T>
    {
    }
}
