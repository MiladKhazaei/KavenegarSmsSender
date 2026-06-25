using KavenegarSmsSender.Interface;
using KavenegarSmsSender.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace KavenegarSmsSender.Service
{
    public class SMSSender : ISMSSender
    {
        private readonly KavenegarSettings _kavenegar;
        private readonly ILogger<SMSSender> _logger;
        public SMSSender(IOptions<KavenegarSettings> kavenegar, ILogger<SMSSender> logger)
        {
            _kavenegar = kavenegar.Value;
            _logger = logger;
        }
        public async Task SendPublic(string phoneNumber, string message)
        {
            try
            {
                var api = new Kavenegar.KavenegarApi(_kavenegar.ApiKey);
                var result = await api.Send(_kavenegar.Sender, phoneNumber, message);
                _logger.LogInformation("Standard SMS dispatched successfully to {PhoneNumber}", phoneNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to dispatch Standard SMS to {PhoneNumber}. Reason: {Message}", phoneNumber, ex.Message);
                throw;
            }
        }
        public async Task SendByPattern(string phoneNumber, string templateName, string token1, string? token2 = "", string? token3 = "")
        {
            try
            {
                var api = new Kavenegar.KavenegarApi(_kavenegar.ApiKey);
                var result = await api.VerifyLookup(phoneNumber, token1, token2, token3, templateName);
                _logger.LogInformation("Pattern SMS (OTP) dispatched successfully to {PhoneNumber}", phoneNumber);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to dispatch Pattern SMS to {PhoneNumber} using template {TemplateName}", phoneNumber, templateName);
                throw;
            }
        }

    }
}
