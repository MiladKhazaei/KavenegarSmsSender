using KavenegarSmsSender.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace KavenegarSmsSender.Controllers
{
    public class SendSmsController(ISMSSender _SmsSender) : Controller
    {
        public IActionResult MainView()
        {
            return View();
        }
        private readonly string SecureOTP = SecureRandomNumber();
        public async Task<IActionResult> SendPublic()
        {
            // In real app, phone number comes from the authenticated usee's profile (user.PhoneNumber)
            var phoneNumber = "01234567890";
            // The message that you want to send to the end-user
            var message = "Test Message"; 
            try
            {
                await _SmsSender.SendPublic(phoneNumber, message);
                TempData["SuccessMessage"] = "پیام با موفقیت ارسال شد.";
                return Redirect("/");
            }
            catch (Exception ex)
            {
                // You could redirect to specific page
                TempData["ErrorMessage"] = "Error Sending SMS...";
                return Redirect("/");
            }
        }

        public async Task<IActionResult> SendByPattern()
        {
            // In real app, phone number comes from the authenticated usee's profile (user.PhoneNumber)
            var phoneNumber = "01234567890";
            // Generate OTP code
            var secureOTP = SecureRandomNumber();
            try
            {
                await _SmsSender.SendByPattern(phoneNumber, "PatternName", SecureOTP, "token2", "token3");
                TempData["SuccessMessage"] = "Message Sends Successfully!";
                return Redirect("/");
            }
            catch (Exception ex)
            {
                // You could redirect to specific page
                TempData["ErrorMessage"] = "Error Sending SMS...";
                return Redirect("/");
            }
        }

        private static string SecureRandomNumber()
        {
            // Return 5 Random Number Into HexString like 5AC3F
            int secureNumber = RandomNumberGenerator.GetInt32(0, 100000);
            return secureNumber.ToString("D5");
        }
    }
}
