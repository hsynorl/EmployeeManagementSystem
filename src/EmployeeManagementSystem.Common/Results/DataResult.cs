
namespace EmployeeManagementSystem.Common.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T result, bool success, string message) : base(success, message)
        {
            Result = result;
        }
        public DataResult(T result, bool success) : base(success)
        {
            Result = result;
        }
        public T Result { get; }
    }
}
