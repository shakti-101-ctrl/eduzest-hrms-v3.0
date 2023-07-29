namespace Eduzest.HRMS.WebApi.Services
{
    public interface IFileUploadService
    {
        Task<string> UploadFile(IFormFile file);
    }
}
