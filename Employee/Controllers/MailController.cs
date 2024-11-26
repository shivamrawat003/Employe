using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Employee.Controllers
{
    public class MailController : Controller
    {
        private readonly EmailService _emailService;

        public MailController()
        {
            // Replace with your actual SMTP settings
            _emailService = new EmailService("smtp.office365.com", 587, "shivam.rawat@apsidatasolutions.com", "R(259897816859an");
        }
        [HttpPost]
        public async Task<ActionResult> SendEmail(string ToEmail, string FromEmail, string Subject, string Body, HttpPostedFileBase Attachment)
        {
            await _emailService.SendEmailAsync(ToEmail, FromEmail, Subject, Body, Attachment);
            return Json(new { success = true });
        }

    }
}