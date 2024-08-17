using System.Text.Json.Serialization;

namespace EmployeeManagementSystem.Common.Results
{
    public class Result : IResult
    {
        [JsonConstructor]
        public Result(bool success,string message):this(success)
        {
            Message=message;
        }
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
