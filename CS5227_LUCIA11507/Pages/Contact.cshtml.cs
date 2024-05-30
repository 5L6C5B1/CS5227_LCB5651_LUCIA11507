using CS5227_LUCIA11507.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CS5227_LUCIA11507.Pages.Shared
{
	public class ContactModel : PageModel
    {
		[BindProperty]
		public ContactForm Contacts { get; set; }
		public class ContactForm
		{
			[Required]
			public string Forename { get; set; }
			[Required]
			public string Surname { get; set; }
			[Required]
			public string Email { get; set; }
			[Required]
			public string Country { get; set; }
			[Required]
			public string Phone { get; set; }
			[Required]
			public string Message { get; set; }
		}

		
		public void OnGet()
		{
			
		}
		private async void SendMail(string mailbody)
		{
			using (var message = new MailMessage(Contacts.Email, "5651@laksamanacollege.edu.bn"))
			{
				message.To.Add(new MailAddress("5651@laksamanacollege.edu.bn"));
				message.From = new MailAddress(Contacts.Email);
				message.Subject = "New E-Mail from Old World Delights";
				message.Body = mailbody;

				using (var smtpClient = new SmtpClient("smtp.gmail.com"))
				{
					smtpClient.Port = 587;
					smtpClient.UseDefaultCredentials = true;
					smtpClient.EnableSsl = true;
					smtpClient.Credentials = new System.Net.NetworkCredential(Contacts.Email, "password");
					/*await smtpClient.SendMailAsync(message);*/
					ViewData["Message"] = "Mail has been sent to " + message.To;
				}
			}
		}
		public async Task OnPost()
		{
			if (!ModelState.IsValid)
			{
				return;
			}

			var mailbody = $@"Hello website owner,

			This is a new contact request from your website:

			First Name: {Contacts.Forename}
			Last Name: {Contacts.Surname}
			Email: {Contacts.Email}
			Country: {Contacts.Country}
			Phone: {Contacts.Phone}
			Message: ""{Contacts.Message}""


			Cheers,
			The websites contact form";

			SendMail(mailbody);
		}
	}
}
