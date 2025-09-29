using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Cqs.Results
{
    public interface ICqsResult
    {
        bool IsSuccess { get; }
        bool IsFailure { get; }
        string ErrorMessage { get; }
    }

    public interface ICqsResult<TResult> 
    {
        bool IsSuccess { get; }
        bool IsFailure { get; }
        string ErrorMessage { get; }
        TResult Data { get; }
    }
}
