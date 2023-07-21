using Microsoft.AspNetCore.Mvc;
using SendEmail.Models;
using System.Net;
using System.Net.Mail;

namespace SendEmail.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Email model)
        {
            MailMessage mailim= new MailMessage();
            mailim.To.Add("bkarakaya0707@gmail.com");
            mailim.From = new MailAddress("bkarakaya0707@gmail.com");
            mailim.Subject ="Bize Ulaşın Sayfasından mesajınız var."+ model.Baslik;
            mailim.Body ="Sayın Yetkili,"+model.AdSoyad +"Kişisinden Gelen Mesajınızın içeriği aşağıdaki gibidir. <br>"+ model.İcerik;
            mailim.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials =  new NetworkCredential("bkarakaya0707@gmail.com","Adaorganik1*");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(mailim);
                TempData["Message"] = "Mesajınız İletilmiştir.En Kısa Zamanda Size Geri Dönüş Sağlanacaktır.";

            }
            catch (Exception ex)
            {
                TempData["Message"]="Mesaj Gönderilemedi Hata Nedeni :"+ex.Message;
            }
            return View();
        }
    }
}
