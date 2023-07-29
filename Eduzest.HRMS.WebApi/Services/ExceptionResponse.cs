namespace Eduzest.HRMS.WebApi.Services
{
    public class ExceptionResponse
    {
        public string? Message { get; set; }
        public int? Response { get; set; }
    }
    public class MsgType
    {
        public static string FailureOnException = "Some Exception Occured";
        public static string LoginSuccess = "Valid User";
        public static string UnAuthenticatedRequest = "Invalid Token";

    }
    public enum ResType
    {
        InternalServerError = 500,   
    }
}
