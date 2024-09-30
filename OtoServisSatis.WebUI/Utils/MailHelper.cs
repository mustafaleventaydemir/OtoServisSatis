using OtoServisSatis.Entities;
using System.Net; // bu iki kütüphaneyi ekledik
using System.Net.Mail; // iki kütüphane ekledik

namespace OtoServisSatis.WebUI.Utils
{
    public class MailHelper
    {
        public static async Task SendMailAsync(Musteri musteri)
        {
            SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com", 587);//host(site adresi), port
            smtpClient.Credentials = new NetworkCredential("leayneihsmtp@outlook.com", "biurE4Vi0pY3JdxWw67YxWGLAfMrB8Ver"); //email ve şifre
            smtpClient.EnableSsl = true; //gmail vsgöndereceksek true olması lazım
            MailMessage message = new MailMessage();
            message.From = new MailAddress("leayneihsmtp@outlook.com"); //mesaj kimden gidecek
            message.To.Add("leayneih@gmail.com"); //mesaj kime gidecek
            //message.To.Add("bilgi@siteadi.com"); //mesaj kime gidecek
            message.Subject = "Siteden mesaj geldi"; //mesajın konusu nedir
            message.Body = $"Mail Bilgileri <hr/> Ad Soyad : {musteri.Adi} {musteri.Soyadi} <hr/> " +
                $"Araç Id : {musteri.AracId} <hr/> " +
                $"Email : {musteri.Email} <hr/> " +
                $"Telefon : {musteri.Telefon} <hr/> " +
                $"Notlar : {musteri.Notlar}"; //mailin bilgileri
            message.IsBodyHtml = true; //mesajın html olarak görünmesini sağlar

            //  smtpClient.Send(message); //mesajı bu şekilde gönderebiliyoruz.
            await smtpClient.SendMailAsync(message); //bu şekildede gönderebiliriz.
            smtpClient.Dispose(); //isteği yok ettik
        }
    }
}
