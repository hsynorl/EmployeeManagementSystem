

namespace EmployeeManagementSystem.Common.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T Result, string message) : base(Result, false, message)
        {
        }
        public ErrorDataResult(T Result) : base(Result, false)
        {
        }
        public ErrorDataResult(string message) : base(default, false, message)
        {
        }
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
