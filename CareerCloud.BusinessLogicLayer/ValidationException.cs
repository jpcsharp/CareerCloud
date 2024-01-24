namespace CareerCloud.BusinessLogicLayer
{
    public class ValidationException: Exception
    {
        public int Code;
        public string? Message;
        public ValidationException(int code, string? message)
        {
            this.Code = code;
            this.Message = message;
        }

    }
}