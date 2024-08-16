

namespace EmployeeManagementSystem.Common.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T Result, string message) : base(Result, true, message)
        {
        }
        public SuccessDataResult(T Result) : base(Result, true)
        {
        }
        public SuccessDataResult(string message) : base(default,true, message)
        {
        }
        public SuccessDataResult():base(default,true)
        {
                
        }
    }
}
