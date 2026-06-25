using Microsoft.AspNetCore.Mvc;

namespace KavenegarSmsSender.Interface
{
    public interface ISMSSender
    {
        Task SendPublic(string phoneNumber, string message);
        Task SendByPattern(string phoneNumber, string templateName, string token1, string? token2 = "", string? token3 = "");

    }
}
